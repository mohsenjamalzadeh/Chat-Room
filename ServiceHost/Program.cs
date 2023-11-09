using _01_framework.Application;
using ChatRoomManagement.Infrastructure.Configuration;
using WebApiTest;

var builder = WebApplication.CreateBuilder(args);

var connectionString="Data source=.;Initial catalog=ChatRoomDB;Integrated security=true;Encrypt=True;TrustServerCertificate=True";
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
ChatRoomManagementBootStrapper.Configure(builder.Services,connectionString);


builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<ISecurity,Security>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
