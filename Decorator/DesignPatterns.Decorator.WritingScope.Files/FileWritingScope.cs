using System;
using System.IO;

namespace DesignPatterns.Decorator.WritingScope.Files
{
	/// <summary>
	/// Simple file writing scope.
	/// </summary>
	public sealed class FileWritingScope : WritingScope
	{
		private readonly FileWritingScopeOptions _options;
		private FileStream _fileStream;
		
		/// <inheritdoc />
		public FileWritingScope(string filename)
			: base(filename)
		{
			_options = new FileWritingScopeOptions();
		}

		/// <inheritdoc />
		public FileWritingScope(string filename, FileWritingScopeOptions options)
			: base(filename)
		{
			_options = options 
				?? throw new ArgumentNullException(nameof(options));
		}

		/// <inheritdoc />
		public override Stream OpenOutputStream()
		{
			_fileStream = new FileStream(
				Filename,
				_options.FileMode,
				FileAccess.ReadWrite,
				_options.FileShare);

			return _fileStream;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				try
				{
					_fileStream.Close();
				}
				finally
				{
					_fileStream.Dispose();
				}
			}
			
			base.Dispose(disposing);
		}
	}
}