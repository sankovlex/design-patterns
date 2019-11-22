using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Decorator
{
	/// <summary>
	/// Simple store
	/// </summary>
	public class Store : IStore
	{
		private readonly IDataSource _dataSource;

		/// <inheritdoc />
		public Store(IDataSource dataSource)
		{
			_dataSource = dataSource 
				?? throw new ArgumentNullException(nameof(dataSource));
		}

		/// <inheritdoc />
		public void Add(Entity entity)
		{
			_dataSource.Entities.Add(entity);
		}

		/// <inheritdoc />
		public Entity GetById(int id)
		{
			return _dataSource
				.Entities
				.SingleOrDefault(e => e.Id == id);
		}
	}
}