using System.IO;

namespace DesignPatterns.Decorator.WritingScope
{
	/// <summary>
	/// Simple file writing scope.
	/// </summary>
	public sealed class FileWritingScope : WritingScope
	{
		/// <inheritdoc />
		public FileWritingScope(string filename)
			: base(filename)
		{
		}

		/// <inheritdoc />
		public override Stream OpenOutputStream()
		{
			return new FileStream(
				Filename,
				FileMode.Create,
				FileAccess.ReadWrite,
				FileShare.None);
		}
	}
}