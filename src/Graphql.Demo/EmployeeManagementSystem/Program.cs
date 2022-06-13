using EmployeeManagementSystem.DataAccess;
using EmployeeManagementSystem.Graphql;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options => 
    options.UseInMemoryDatabase("EmployeeManagementSystem"));
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IDepartmentRepository, DepartmentRepository>();

//Add Graphql services
builder.Services.AddSingleton<ISchema, EmployeeManagementSchema>(services 
    => new EmployeeManagementSchema(new SelfActivatingServiceProvider(services)));

builder.Services.AddGraphQL(builder =>
    {
        builder.AddApolloTracing(true)
            .AddHttpMiddleware<ISchema>()
            .AddSchema<EmployeeManagementSchema>()
            .AddGraphTypes(typeof(EmployeeManagementSchema).Assembly)
            .AddSystemTextJson(options =>
            {
                
            });
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLPlayground();
}

app.UseAuthorization();

app.MapControllers();

//Add Graphql 
app.UseGraphQL<ISchema>();

app.Run();
