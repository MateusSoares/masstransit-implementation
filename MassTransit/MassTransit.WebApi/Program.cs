using MassTransit;
using MassTransit.WebApi.Consumers;
using MassTransit.WebApi.Messages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serviceBusConnection = builder.Configuration.GetConnectionString("ServiceBus");

builder.Services.AddMassTransit(x =>
{
    x.SetDefaultEndpointNameFormatter();

    x.AddConsumer<CreateOrderConsumer>();
    x.AddConsumer<CreateOrderBillingConsumer>();
    x.AddConsumer<UpdateOrderItemsConsumer>();

    x.UsingAzureServiceBus((context, cfg) => 
    {
        cfg.Host(serviceBusConnection);

        cfg.ConfigureEndpoints(context);
    });
});


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
