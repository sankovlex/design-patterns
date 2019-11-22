using System;

namespace DesignPatterns.Decorator
{
	public class EncryptionStore : IStore
	{
		private readonly IStore _store;
		private readonly ICryptoProvider _cryptoProvider;

		/// <inheritdoc />
		public EncryptionStore(IStore store, ICryptoProvider cryptoProvider)
		{
			_store = store 
				?? throw new ArgumentNullException(nameof(store));
			_cryptoProvider = cryptoProvider 
				?? throw new ArgumentNullException(nameof(cryptoProvider));
		}

		/// <inheritdoc />
		public void Add(Entity entity)
		{
			Entity encrypt = _cryptoProvider.Encrypt(entity);
			
			_store.Add(encrypt);
		}

		/// <inheritdoc />
		public Entity GetById(int id)
		{
			Entity entity = _store.GetById(id);

			return _cryptoProvider.Decrypt(entity);
		}
	}
}