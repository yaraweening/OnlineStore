using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Interfaces;
using Services;
using DAL.Interfaces;
using DAL;

public class Program
{
    public static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
            .ConfigureServices(s =>
            {
                s.AddScoped<IProductDAL, ProductDAL>();
                s.AddScoped<IOrderDAL, OrderDAL>();
                s.AddScoped<IDepartmentDAL, DepartmentDAL>();
                s.AddScoped<IForumDAL, ForumDAL>();

                s.AddScoped<IOrderService, OrderService>();
                s.AddScoped<IProductService, ProductService>();
                s.AddScoped<IDepartmentService, DepartmentService>();
                s.AddScoped<IForumService, ForumService>();
            })
            .ConfigureOpenApi()
            .Build();

        host.Run();
    }
}