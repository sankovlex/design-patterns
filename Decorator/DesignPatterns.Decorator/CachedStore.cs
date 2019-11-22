using System;
using System.Collections.Generic;

namespace DesignPatterns.Decorator
{
	public class CachedStore : IStore
	{
		private readonly IStore _store;
		private readonly IDictionary<int, Entity> _cache;

		/// <inheritdoc />
		public CachedStore(IStore store)
		{
			_store = store 
				?? throw new ArgumentNullException(nameof(store));
			
			_cache = new Dictionary<int, Entity>();
		}

		/// <inheritdoc />
		public void Add(Entity entity)
		{
			_cache[entity.Id] = entity;
			_store.Add(entity);
		}

		/// <inheritdoc />
		public Entity GetById(int id)
		{
			if (_cache.ContainsKey(id))
			{
				return _cache[id];
			}

			return _store.GetById(id);
		}
	}
}