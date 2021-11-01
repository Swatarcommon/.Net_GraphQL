using System.Linq;
using GraphQL_dotNet.Data;
using GraphQL_dotNet.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQL_dotNet.GraphQL {
	public class Query {
		[UseFiltering]
		[UseSorting]
		[UseDbContext(typeof(AppDbContext))]
		public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context) {
			return context.Platforms;
		}

		[UseFiltering]
		[UseSorting]
		[UseDbContext(typeof(AppDbContext))]
		public IQueryable<Command> GetCommand([ScopedService] AppDbContext context) {
			return context.Commands;
		}
	}
}