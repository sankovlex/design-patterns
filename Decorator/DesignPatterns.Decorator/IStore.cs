using System.Collections.Generic;

namespace DesignPatterns.Decorator
{
	public interface IStore
	{
		void Add(Entity entity);

		Entity GetById(int id);
	}
}
