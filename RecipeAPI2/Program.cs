using MongoDB.Driver;
using Recipe.Infrastructure.Recipe.Infrastructure.Repository.Interface;
using Recipe.Infrastructure.Recipe.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration.GetConnectionString("MongoDBConnection")));

builder.Services.AddScoped<IRecipeRepository, RecipeService> ();
builder.Services.AddScoped<IReviewRepository, ReviewService>();
builder.Services.AddScoped<IRatingRepository, RatingService>();




builder.Services.AddControllers();
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
