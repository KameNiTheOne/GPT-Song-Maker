global using GPTSMShared;
using BlazorApp1;
using BlazorApp1.Components;
using Microsoft.EntityFrameworkCore;
class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddDbContext<GPTSMContext>(options =>
                options.UseSqlite("Data Source=GPTSMData.db"));

        builder.Services.AddScoped<IGPT, GPT>();
        builder.Services.AddScoped<IRepository, EfRepository>();

        var app = builder.Build();

        // Initialize the database
        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<GPTSMContext>();
            if (db.Database.EnsureCreated())
            {
                SeedData.Initialize(db);
            }
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
        }

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
