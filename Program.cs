
using Serilog;

namespace ApiAziendaLogin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura Serilog per scrivere i log su file, nella cartella Logs
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console() // Scrivi i log anche sulla console
                .WriteTo.File(
                    path: "Logs/log-.txt", // I file di log saranno in "Logs/log-YYYYMMDD.txt"
                    rollingInterval: RollingInterval.Day, // Ogni giorno crea un nuovo file
                    fileSizeLimitBytes: 2 * 1024 * 1024, // Limite di dimensione del file a 2 MB
                    retainedFileCountLimit: 5, // Mantieni al massimo 5 file di log (per esempio)
                    rollOnFileSizeLimit: true // Ruota il file quando supera la dimensione
                )
                .CreateLogger();

            // Imposta Serilog come il logger predefinito
            builder.Host.UseSerilog();




            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
