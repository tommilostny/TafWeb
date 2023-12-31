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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey
            (
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new Exception("missing JWT signing key"))
            )
        };
    });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AboutUs), typeof(AboutUsDetailModel), typeof(AboutUsMapperProfile));

builder.Services.AddScoped<IAboutUsService, AboutUsService>();
builder.Services.AddScoped<IClientFeedbackService, ClientFeedbackService>();
builder.Services.AddScoped<IOrderFormService, OrderFormService>();
builder.Services.AddScoped<IVideoCategoryService, VideoCategoryService>();
builder.Services.AddScoped<IVideoService, VideoService>();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("AboutUsMainPage", policy =>
    {
        policy.Expire(TimeSpan.FromHours(1));
        policy.Tag("AboutUs");
    });
    options.AddPolicy("AboutUsDetailPage", policy =>
    {
        policy.Expire(TimeSpan.FromMinutes(10));
        policy.Tag("AboutUs");
    });
});

var app = builder.Build();
app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGet("/seed", async (TafWebDbContext context, UserManager<TafUser> userManager) =>
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        await context.SeedDatabaseAsync(userManager);
        return Results.Ok();
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("TafWebCorsPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.UseOutputCache();

app.MapControllers();

app.Run();
