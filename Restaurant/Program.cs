using Microsoft.AspNetCore.Authentication.Cookies;
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

// Enhancement ConnectionString
var connectionString = builder.Configuration.GetConnectionString("defaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));

// Auto Mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

// Repositries Registration
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ITableRepo, TableRepo>();
builder.Services.AddScoped<IRestaurantRepo, RestaurantRepo>();
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
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
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
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
	options =>
	{
		options.LoginPath = new PathString("/Account/Login");
		options.AccessDeniedPath = new PathString("/Account/Login");
	});

builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

// Password Configuration
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
	// Default Password settings.
	options.User.RequireUniqueEmail = true;
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	options.Password.RequiredLength = 6;
	options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
