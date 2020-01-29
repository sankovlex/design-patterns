using NUnit.Framework;
using System.IO;

namespace DesignPatterns.Decorator.WritingScope.UnitTests2
{
	public class FileWritingScopeFixture
	{
		protected const string Filename = "test.txt";
		protected readonly IWritingScopeFactory _writingScopeFactory;

		[SetUp]
		public void SetUp()
		{
		}
		
		[TearDown]
		public void CleanUp()
		{
			File.Delete(Filename);
		}
	}
}
