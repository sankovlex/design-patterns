using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace DesignPatterns.Decorator.WritingScope.Files.UnitTests
{
	[TestFixture]
	[Parallelizable]
	public class FileWritingScopeTests : FileWritingScopeFixture
	{
		[Test]
		public void Can_be_completed_writing()
		{
			// Arrange
			const string text = "This is simple file writing scope.";

			// Act
			this.WriteText(text);

			// Assert
			string actualText = File.ReadAllText(_filename);
			actualText.ShouldBe(text);
		}

		private void WriteText(string text)
		{
			using WritingScope scope = Factory.Create();
			using Stream outputStream = scope.OpenOutputStream();
			using var writer = new StreamWriter(outputStream);

			writer.Write(text);
			scope.Complete();
		}

		[Test]
		public void Can_be_corrupt_file()
		{
			// Arrange
			const string text = "This is simple file writing scope.";

			// Act & Assert
			Should.Throw<Exception>(() => this.ThrowExceptionWhenWriting(text));
			File.Exists(string.Concat(_filename, WritingScope.CorruptedFileExtension))
				.ShouldBeTrue();
		}

		private void ThrowExceptionWhenWriting(string text)
		{
			using WritingScope scope = Factory.Create();
			using Stream outputStream = scope.OpenOutputStream();
			using var writer = new StreamWriter(stream: outputStream);

			writer.Write(text);

			// Stop uncompleted
			throw new Exception("Unhandled exception");
		}
	}
}