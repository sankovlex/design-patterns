using System;
using System.IO;
using System.Security.Cryptography;

namespace DesignPatterns.Decorator.WritingScope.CheckSum
{
	/// <summary>
	/// Checksum writing scope.
	/// </summary>
	public abstract class ChecksumWritingScope : WritingScope
	{
		private readonly WritingScope _fileScope;
		private readonly IHashAlgorithmFactory _hashAlgorithmFactory;
		private readonly string _extension;

		/// <inheritdoc />
		protected ChecksumWritingScope(
			WritingScope fileScope,
			IHashAlgorithmFactory hashAlgorithmFactory,
			string extension)
			: base(string.Concat(fileScope.Filename, extension))
		{
			_fileScope = fileScope;

			_hashAlgorithmFactory = hashAlgorithmFactory 
				?? throw new ArgumentNullException(nameof(hashAlgorithmFactory));

			if (!IsValidExtension(extension))
			{
				throw new ArgumentException(
					paramName: nameof(extension),
					message: $"Value '{extension}' is not valid.");
			}

			_extension = extension;
		}

		private static bool IsValidExtension(string extension)
		{
			if (string.IsNullOrEmpty(extension))
			{
				return false;
			}
			
			if (!extension.StartsWith("."))
			{
				return false;
			}

			if (extension.EndsWith("."))
			{
				return false;
			}

			return true;
		}

		protected virtual void CreateCheckSum()
		{
			using (Stream reader = CreateReader(_fileScope.Filename))
			using (Stream writer = CreateWriter(_fileScope.Filename, _extension))
			using (HashAlgorithm hashAlgorithm = _hashAlgorithmFactory.Create())
			{
				GenerateCheckSumFile(reader, writer, hashAlgorithm);
			}
		}

		private static Stream CreateReader(string filename)
		{
			return new FileStream(filename, FileMode.Open);
		}

		private static Stream CreateWriter(string filename, string extension)
		{
			return new FileStream(
				path: string.Concat(filename, extension),
				mode: FileMode.Create,
				access: FileAccess.ReadWrite,
				share: FileShare.None);
		}
		
		private static void GenerateCheckSumFile(
			Stream reader,
			Stream writer,
			HashAlgorithm hashAlgorithm)
		{
			byte[] hash = hashAlgorithm.ComputeHash(reader);

			writer.Write(hash);
		}

		/// <inheritdoc />
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (_isCompleted)
			{
				this.CreateCheckSum();
			}
		}
	}
}