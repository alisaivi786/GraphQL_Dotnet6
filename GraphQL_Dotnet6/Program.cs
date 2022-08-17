using EntityGraphQL.AspNet;
using GraphQL.Server.Ui.Altair;
using GraphQL_Dotnet6;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CibContext>(opt => opt.UseInMemoryDatabase("cib"));
builder.Services.AddGraphQLSchema<CibContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var cibContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<CibContext>();
await DatabaseSeeder.SeedAsync(cibContext);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
string graphUrl = "/graphql";
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();
    routeBuilder.MapGraphQL<CibContext>(); // default url: /graphql
    routeBuilder.MapGraphQLAltair("ui/altair");
});

app.Run();
