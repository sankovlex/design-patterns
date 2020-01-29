namespace DesignPatterns.Decorator.WritingScope
{
	/// <summary>
	/// Writing scope factory.
	/// </summary>
	public interface IWritingScopeFactory
	{
		/// <summary>
		/// Create instance of <see cref="WritingScope"/>
		/// </summary>
		WritingScope Create();
	}
}