using System.Security.Cryptography;

namespace DesignPatterns.Decorator.WritingScope.CheckSum
{
	public interface IHashAlgorithmFactory
	{
		HashAlgorithm Create();
	}
}