using PacientesCitasSOAP.Data;
using PacientesCitasSOAP.Services;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PacientesCitasDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PacientesCitasConnection")
    )
);

builder.Services.AddScoped<PacienteCitaService>();

builder.Services
    .AddServiceModelServices()
    .AddServiceModelMetadata();

builder.Services.AddSingleton<IServiceBehavior,
    UseRequestHeadersForMetadataAddressBehavior>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder
        .AddService<PacienteCitaService>()
        .AddServiceEndpoint<PacienteCitaService, IPacienteCitaService>(
            new BasicHttpBinding(),
            "/PacienteCitaService.svc"
        );
});

var metadataBehavior =
    app.Services.GetRequiredService<ServiceMetadataBehavior>();

metadataBehavior.HttpGetEnabled = true;

app.Run();
