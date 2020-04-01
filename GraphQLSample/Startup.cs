using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLSample.DataAccess.Repositories;
using GraphQLSample.DataAccess.Repositories.Contracts;
using GraphQLSample.Database;
using GraphQLSample.Mutations;
using GraphQLSample.Queries;
using GraphQLSample.Schema;
using GraphQLSample.Types.Order;
using GraphQLSample.Types.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddDbContext<GraphQLSampleContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:MyDb"]));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<UserQuery>();
            services.AddScoped<UserType>();
            services.AddScoped<OrderType>();
            services.AddScoped<UserInputType>();

            services.AddScoped<UserMutation>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new GraphQLSampleSchema(new FuncDependencyResolver(type => sp.GetService(type))));
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQLSampleContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseGraphiQl();
            db.EnsureSeedData();
        }
    }
}
