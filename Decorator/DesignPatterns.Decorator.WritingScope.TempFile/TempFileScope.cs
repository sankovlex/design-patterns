using System;
using System.IO;

namespace DesignPatterns.Decorator.WritingScope.TempFile
{
	/// <inheritdoc />
	public class TempFileScope : WritingScope
	{
		private readonly WritingScope _fileScope;
		private readonly string _extension;

		/// <inheritdoc />
		public TempFileScope(WritingScope fileScope, string extension)
			: base(string.Concat(fileScope.Filename, extension))
		{
			_fileScope = fileScope;

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
			return _fileScope.OpenOutputStream();
		}

		/// <inheritdoc />
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (_isCompleted)
			{
				this.MakeFileAsReady();
			}
		}

		private void MakeFileAsReady()
		{
			File.Move(
				sourceFileName: _fileScope.Filename,
				destFileName: _fileScope.Filename.TrimEnd(_extension.ToCharArray()));
		}
	}
}