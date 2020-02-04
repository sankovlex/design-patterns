using System;

namespace DesignPatterns.Decorator.WritingScope.Files.UnitTests
{
	internal class WritingScopeFactory : IWritingScopeFactory
	{
		private readonly string _filename;

		public WritingScopeFactory(string filename)
		{
			_filename = filename 
				?? throw new ArgumentNullException(nameof(filename));
		}

		public WritingScope Create()
		{
			var fileScope = new FileWritingScope(_filename);

			return fileScope;
		}
	}
}