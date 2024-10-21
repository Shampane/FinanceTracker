using FinanceTracker.Api.DataAccess;
using FinanceTracker.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<
            ITransactionsRepository,
            TransactionsRepository
        >();
        builder.Services.AddDbContext<FinanceDbContext>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();

        await app.RunAsync();
    }
}
