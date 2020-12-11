**conexcion consola

Scaffold-DBContext "Server=localhost;Database=VentaReal;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models





*****app.settings.json


"ConnectionStrings": {

    "BancoContext": "Server=DESKTOP-TNJHFEP;Database=Atlantida;Trusted_Connection=True;" =>sacar de dbcontext
  },





*****Startup***  

   services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<AtlantidaContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("BancoContext"));
                });

