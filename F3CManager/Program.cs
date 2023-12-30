namespace F3CManager
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();
            //app.MapGet("/", () => "Hello World!");

            startup.Configure(app, app.Environment);
            app.Run();
        }
    }
}