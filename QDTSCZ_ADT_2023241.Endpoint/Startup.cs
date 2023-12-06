using QDTSCZ_ADT_2023241.Logic;
using QDTSCZ_ADT_2023241.Repository;
using Microsoft.EntityFrameworkCore;

namespace QDTSCZ_ADT_2023241.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext, Context>();
            //services.AddDbContext<DbContext, BlogContext>(); // optional
            services.AddTransient<IInstrumentRepository, InstrumentRepository>();
            services.AddTransient<IBandRepository, BandRepository>();
            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();

            services.AddTransient<IInstrumentLogic, InstrumentLogic>();
            services.AddTransient<IBandLogic, BandLogic>();
            services.AddTransient<IManufacturerLogic, ManufacturerLogic>();
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
        }
    }
}