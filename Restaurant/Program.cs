using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurnat.BLL.Mapper;
using Restaurnat.BLL.Services.Apstraction;
using Restaurnat.BLL.Services.Implementation;
using Restaurnat.DAL.Database;
using Restaurnat.DAL.Entities;
using Restaurnat.DAL.Repo.Apstraction;
using Restaurnat.DAL.Repo.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<EmailService>();
// Connection string
var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Auto Mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

// Repositories Registration
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ITableRepo, TableRepo>();
builder.Services.AddScoped<IReservedTableRepo, ReservedTableRepo>();
builder.Services.AddScoped<IReservedItemRepo, ReservedItemRepo>();
builder.Services.AddScoped<IReservationRepo, ReservationRepo>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddScoped<IMenuRepo, MenuRepo>();
builder.Services.AddScoped<IItemRepo, ItemRepo>();
builder.Services.AddScoped<IFeedbackRepo, FeedbackRepo>();
builder.Services.AddScoped<IEventRepo, EventRepo>();
builder.Services.AddScoped<IChefRepo, ChefRepo>();

// Services Registration
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IReservedTableService, ReservedTableService>();
builder.Services.AddScoped<IReservedItemService, ReservedItemService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IChefService, ChefService>();

// Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Configure Cookie Paths
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Login";
});

// Function to create roles & admin
async Task CreateRolesAndAdmin(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    // Create admin if not exists
    var adminUser = await userManager.FindByEmailAsync("admin@test.com");
    if (adminUser == null)
    {
        adminUser = new User("AdminFirst", "AdminLast", 30, "Country", "City", "Street")
        {
            UserName = "admin",
            Email = "admin@test.com"
        };

        var result = await userManager.CreateAsync(adminUser, "admin123456");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}

var app = builder.Build();

// Call role & admin creation after building the app
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await CreateRolesAndAdmin(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
