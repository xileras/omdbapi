
namespace Server.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

            var host = hostBuilder.Build();

            host.Run();
        }
    }
}