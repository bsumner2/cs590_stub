using BulletinBoard_Api.Data;
using BulletinBoard_Api.Services;
using Microsoft.EntityFrameworkCore;

namespace BulletinBoard_Api;
    
class Program {
        public static void Main(String[] args) {    
        var builder = WebApplication.CreateBuilder(args);

        string boardAllowSpecificOrigins = "_boardAllowSpecificOrigins";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: boardAllowSpecificOrigins, policy => {
                policy.WithOrigins(
                    builder.Configuration.GetValue<string[]>("AllowedOrigins") 
                            ?? (new string[1] {"https://localhost:7261"}));
                // Additional policy change, allows any origin to make 
                // state-altering http req's like POST, PUT, etc
                policy.AllowAnyHeader();
                
            });
        });

        builder.Services.AddDbContext<BulletinBoardContext>((
            opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("BulletinBoardCtx"))));

        // Add services to the container.
        
        builder.Services.AddControllers();

        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IPostService, PostService>();
        builder.Services.AddScoped<IAccountService, AccountService>();
        
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
