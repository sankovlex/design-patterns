using System;
using System.IO;
using NUnit.Framework;

namespace DesignPatterns.Decorator.WritingScope.Files.UnitTests
{
	public abstract class WritingScopeFixtureBase
	{
		protected string _filename;

		[SetUp]
		public virtual void SetUp()
		{
			_filename = Guid
				.NewGuid()
				.ToString();
		}
		
		[TearDown]
		public virtual void CleanUp()
		{
			if (File.Exists(_filename))
			{
				File.Delete(_filename);
			}

			string corruptedFilename = string.Concat(
				_filename,
				WritingScope.CorruptedFileExtension);
			
			if (File.Exists(corruptedFilename))
			{
				File.Delete(corruptedFilename);
			}
		}
	}
}