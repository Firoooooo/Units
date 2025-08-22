
using Microsoft.EntityFrameworkCore;
using UnitTExamplesAPI.Data;

namespace UnitTExamplesAPI
{
    public class Program
    {
        public static void Main(string[] _aRgs)
        {
            var bUILDER = WebApplication.CreateBuilder(_aRgs);

            bUILDER.Services.AddDbContext<UnitTExamplesContext>(O =>
                O.UseMySql(
                            bUILDER.Configuration.GetConnectionString("DefaultConnection"),
                            ServerVersion.AutoDetect(bUILDER.Configuration.GetConnectionString("DefaultConnection"))));

            bUILDER.Services.AddControllers();
          
            bUILDER.Services.AddOpenApi();

            var wEBApp = bUILDER.Build();

            if (wEBApp.Environment.IsDevelopment())
            {
                wEBApp.MapOpenApi();
            }

            wEBApp.UseHttpsRedirection();
            wEBApp.UseAuthorization();
            wEBApp.MapControllers();
            wEBApp.Run();
        }
    }
}
