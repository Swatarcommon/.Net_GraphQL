using System.Linq;
using System.Threading.Tasks;
using GraphQL_dotNet.Data;
using GraphQL_dotNet.GraphQL.Platforms;
using GraphQL_dotNet.Models;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_dotNet.GraphQL {
	public class Mutation {
		[UseDbContext(typeof(AppDbContext))]
		public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input,
																[ScopedService] AppDbContext context) {
			var platform = new Platform() {
				Name = input.Name
			};

			context.Platforms.Add(platform);
			await context.SaveChangesAsync();
			return new AddPlatformPayload(platform);
		}

		[UseDbContext(typeof(AppDbContext))]
		public async Task<AddPlatformPayload> UpdatePlatformAsync(int platformId, AddPlatformInput input,
																[ScopedService] AppDbContext context) {
			var platform = context.Platforms.FirstOrDefault(p => p.Id == platformId);
			platform.Name = input.Name;
			context.Platforms.Update(platform);
			await context.SaveChangesAsync();
			return new AddPlatformPayload(platform);
		}
	}
}