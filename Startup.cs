using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Voyager;
using GraphQL_dotNet.Data;
using GraphQL_dotNet.GraphQL;
using GraphQL_dotNet.GraphQL.Commands;
using GraphQL_dotNet.GraphQL.Platforms;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL_dotNet {
	public class Startup {
		private readonly IConfiguration Configuration;

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services) {
			services.AddPooledDbContextFactory<AppDbContext>(
				opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
			services.AddGraphQLServer().AddQueryType<Query>()
					.AddMutationType<Mutation>()
					.AddType<PlatformType>()
					.AddType<CommandType>()
					.AddFiltering().AddSorting();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });

			app.UseGraphQLVoyager();
		}
	}
}