using System;
using System.IO;
using System.IO.Compression;

namespace DesignPatterns.Decorator.WritingScope.GZip
{
	/// <summary>
	/// Compressed by GZip algorithm writing scope
	/// </summary>
	public sealed class DeflateWritingScope : WritingScope
	{
		/// <inheritdoc />
		public DeflateWritingScope(string filename, string extension)
			: base(filename: string.Concat(filename, extension))
		{
			if (!IsValidExtension(extension))
			{
				throw new ArgumentException(
					paramName: nameof(extension),
					message: $"Value '{extension}' is not valid.");
			}
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

		/// <inheritdoc />
		public override Stream OpenOutputStream()
		{
			var fileStream = new FileStream(
				Filename,
				FileMode.Create,
				FileAccess.ReadWrite,
				FileShare.None);
			
			return new GZipStream(
				fileStream,
				CompressionMode.Compress);
		}
	}
}