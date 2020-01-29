using System.IO;
using NUnit.Framework;
using Shouldly;

namespace DesignPatterns.Decorator.WritingScope.UnitTests2
{
	[TestFixture]
	[Parallelizable]
	public class FileWritingScopeTests : FileWritingScopeFixture
	{
		[Test]
		public void Can_be_completed_writing()
		{
			// Arrange
			const string text = "test";
			
			// Act
			using (WritingScope writingScope = new FileWritingScope(Filename))
			using (Stream outputStream = writingScope.OpenOutputStream())
			using (var writer = new StreamWriter(outputStream))
			{
				writer.Write(text);
				writingScope.Complete();
			}

			// Assert
			string actualText = File.ReadAllText(Filename);
			actualText.ShouldBe(text);
		}
	}
}