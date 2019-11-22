namespace DesignPatterns.Decorator
{
	public interface ICryptoProvider
	{
		Entity Encrypt(Entity entity);

		Entity Decrypt(Entity entity);
	}
}