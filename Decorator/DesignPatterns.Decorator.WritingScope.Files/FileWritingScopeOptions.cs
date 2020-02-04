using System.IO;

namespace DesignPatterns.Decorator.WritingScope.Files
{
	public class FileWritingScopeOptions
	{
		public FileMode FileMode { get; set; } = FileMode.CreateNew;

		public FileShare FileShare { get; set; } = FileShare.None;
	}
}