using APBD_PJATK_Cw3.Mappers;
using APBD_PJATK_Cw3.Services;
using APBD_PJATK_Cw3.Utils;

namespace APBD_PJATK_Cw3;

public class Program
{
    public static void Main(string[] args)
    {
        ExampleDataUtil.InitializeData();
        
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddScoped<IRoomsService, RoomsService>();
        builder.Services.AddScoped<IRoomsMapper, RoomsMapper>();
        builder.Services.AddAuthorization();
        builder.Services.AddOpenApi();
        builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}