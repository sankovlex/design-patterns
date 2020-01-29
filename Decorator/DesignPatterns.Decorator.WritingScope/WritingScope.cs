using System;
using System.IO;

namespace DesignPatterns.Decorator.WritingScope
{
	/// <inheritdoc />
	public abstract class WritingScope : IDisposable
	{
		protected bool _isCompleted;
		private const string CorruptedFileExtension = ".crp";

		/// <summary>
		/// Initialize instance of <see cref="WritingScope"/>.
		/// </summary>
		/// <param name="filename">Full file name</param>
		/// <exception cref="ArgumentException">
		///		File already exists.
		/// </exception>
		/// <exception cref="ArgumentNullException">
		/// 	Filename cannot be null.
		/// </exception>
		protected WritingScope(string filename)
		{
			if (filename == null)
			{
				throw new ArgumentNullException(nameof(filename));
			}

			if (File.Exists(filename))
			{
				throw new ArgumentException(
					paramName: filename,
					message: $"File {filename} already exists.");
			}

			Filename = filename;
		}

		/// <summary>
		/// Full file name.
		/// </summary>
		public string Filename { get; }

		/// <summary>
		/// Open output stream.
		/// </summary>
		public abstract Stream OpenOutputStream();

		/// <summary>
		/// Complete writing into file.
		/// </summary>
		public void Complete()
		{
			_isCompleted = true;
		}
		
		/// <summary>
		/// Dispose <see cref="WritingScope"/>
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (!_isCompleted)
				{
					this.MakeFileAsCorrupted();
				}
			}
		}

		/// <inheritdoc />
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void MakeFileAsCorrupted()
		{
			File.Move(
				sourceFileName: Filename,
				destFileName: string.Concat(Filename, CorruptedFileExtension));
		}
	}
}