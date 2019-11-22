using System.Security.Authentication;

namespace DesignPatterns.Decorator
{
	public class Entity
	{
		/// <inheritdoc />
		public Entity(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; private set; }

		[Encryptable(HashAlgorithmType.Sha256)]
		public string Name { get; private set; }
	}
}