using System;
using System.Security.Authentication;
using System.Security.Cryptography;

namespace DesignPatterns.Decorator
{
	[AttributeUsage(AttributeTargets.Property)]
	public class EncryptableAttribute : Attribute
	{
		public HashAlgorithmType HashAlgorithmType { get; }

		public EncryptableAttribute(HashAlgorithmType hashAlgorithmType = HashAlgorithmType.Md5)
		{
			HashAlgorithmType = hashAlgorithmType;
		}
	}
}