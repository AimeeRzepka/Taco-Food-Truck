using FluentAssertions.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Taco_Food_Truck
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

     

        public void Configure(IApplicationBuilder app)
        { }
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TacoDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Data Source=AIMEERZEPKA;Initial Catalog=FastFoodTacoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")));

        }
    }
}
