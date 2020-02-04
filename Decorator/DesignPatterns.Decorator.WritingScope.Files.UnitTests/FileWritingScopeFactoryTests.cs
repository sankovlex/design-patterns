using System.IO;
using NUnit.Framework;
using Shouldly;

namespace DesignPatterns.Decorator.WritingScope.Files.UnitTests
{
	[TestFixture]
	[Parallelizable]
	public class FileWritingScopeFactoryTests : WritingScopeFixtureBase
	{
		[Test]
		public void Can_replace_file()
		{
			// Arrange
			File.Create(_filename);
			
			var options = new FileWritingScopeOptions
			{
				FileMode = FileMode.Create
			};

			// Act & Assert
			Should.NotThrow(() => TryWrite(_filename, options));
		}
		
		[Test]
		public void Cannot_replace_file()
		{
			// Arrange
			File.Create(_filename);
			
			var options = new FileWritingScopeOptions
			{
				FileMode = FileMode.CreateNew
			};

			// Act & Assert
			Should.Throw<IOException>(() => TryWrite(_filename, options));
		}
		
		[Test]
		public void Cannot_write_in_non_shared_file()
		{
			// Arrange
			var options = new FileWritingScopeOptions
			{
				FileShare = FileShare.None
			};

			// Act & Assert
			Should.Throw<IOException>(() =>
			{
				TryWrite(_filename, options);
				TryWrite(_filename, options);
			});
		}

		private static void TryWrite(string filename, FileWritingScopeOptions options)
		{
			const string text = "This is try write.";
			
			using (var scope = new FileWritingScope(filename, options))
			using (Stream stream = scope.OpenOutputStream())
			using (var writer = new StreamWriter(stream))
			{
				writer.Write(text);
				scope.Complete();
			}
		}
	}
}