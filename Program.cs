using Microsoft.EntityFrameworkCore;
using CustomerOrderItem.Data;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<OrderItemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderItemContext") ?? throw new InvalidOperationException("Connection string 'OrderItemContext' not found.")));
builder.Services.AddDbContext<ORDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ORDContext") ?? throw new InvalidOperationException("Connection string 'ORDContext' not found.")));
builder.Services.AddDbContext<CUSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CUSContext") ?? throw new InvalidOperationException("Connection string 'CUSContext' not found.")));
builder.Services.AddDbContext<ProductionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionContext") ?? throw new InvalidOperationException("Connection string 'ProductionContext' not found.")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ProductionContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
