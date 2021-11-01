using System.Linq;
using GraphQL_dotNet.Data;
using GraphQL_dotNet.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL_dotNet.GraphQL.Commands {
	public class CommandType : ObjectType<Command> {
		protected override void Configure(IObjectTypeDescriptor<Command> descriptor) {
			descriptor.Description("Represent any commands  that has a platform.");
			descriptor.Field(c => c.Platform).ResolveWith<Resolvers>(r => r.GetPlatform(default!, default!))
					.UseDbContext<AppDbContext>().Description("Show which platform commands below");
		}

		private class Resolvers {
			public Platform GetPlatform(Command command, [ScopedService] AppDbContext context) {
				return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
			}
		}
	}
}