using NUnit.Framework;

namespace DesignPatterns.Decorator.WritingScope.Files.UnitTests
{
	public abstract class FileWritingScopeFixture : WritingScopeFixtureBase
	{
		[SetUp]
		public override void SetUp()
		{
			base.SetUp();
			Factory = new WritingScopeFactory(_filename);
		}
		
		protected IWritingScopeFactory Factory { get; private set; }
	}
}
