using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Decorator
{
	public interface IDataSource
	{
		ICollection<Entity> Entities { get; }
	}
}