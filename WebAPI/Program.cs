using Application;
using JsonDataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddScoped<IForumDAO, ForumDAOImpl>();
builder.Services.AddScoped<IUserDAO, UserDAOImpl>();
builder.Services.AddScoped<JsonForumContext>();
builder.Services.AddScoped<JsonUserContext>();*/
builder.Services.AddScoped<IForumDAO, ForumSqliteDAO>();
builder.Services.AddDbContext<ForumContext>();

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