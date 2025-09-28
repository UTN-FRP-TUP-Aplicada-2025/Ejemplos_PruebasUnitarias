
using Ejemplo1.DALs;
using Ejemplo1.DALs.List;
using Ejemplo1.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder()
.ConfigureServices((context, services) =>
{
    IConfiguration configuration = context.Configuration;

    services.AddSingleton<IFigurasDAL, FigurasListDAL>();

    services.AddSingleton<FigurasService>();

})
.Build();


//lo siguiente podría ser un metodo en un servicio - ver ejemplo3
//consiguiendo el formulario principal
var serviceDAL = host.Services.GetRequiredService<FigurasService>();
serviceDAL.Test();

