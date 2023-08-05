using AspNetCore.Identity.CosmosDb;
using AspNetCore.Identity.CosmosDb.Containers;
using AspNetCore.Identity.CosmosDb.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("TafWebCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// The Cosmos connection string
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection")
    ?? throw new Exception("missing cosmos connection string");

// Name of the Cosmos database to use
var cosmosIdentityDbName = builder.Configuration.GetValue<string>("CosmosIdentityDbName")
    ?? throw new Exception("missing cosmos identity database name");

builder.Services.AddDbContext<TafWebDbContext>(options =>
{
    options.UseCosmos(connectionString, cosmosIdentityDbName);
});

builder.Services.AddCosmosIdentity<TafWebDbContext, TafUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
}
).AddDefaultUI().AddDefaultTokenProviders();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

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

// If this is set, the Cosmos identity provider will:
// 1. Create the database if it does not already exist.
// 2. Create the required containers if they do not already exist.
// IMPORTANT: Remove this setting if after first run. It will improve startup performance.
var setupCosmosDb = builder.Configuration.GetValue<string>("SetupCosmosDb");

// If the following is set, it will create the Cosmos database and
//  required containers.
if (bool.TryParse(setupCosmosDb, out var setup) && setup)
{
    using var serviceProvider = app.Services.CreateScope();
    var context = serviceProvider.ServiceProvider.GetRequiredService<TafWebDbContext>();
    var userManager = serviceProvider.ServiceProvider.GetRequiredService<UserManager<TafUser>>();

    await context.Database.EnsureDeletedAsync();
    await context.Database.EnsureCreatedAsync();
    await context.SeedDatabaseAsync(userManager);
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("TafWebCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
