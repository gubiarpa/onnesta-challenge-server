using AutoMapper;
using gubiarpa.onnesta.api.Controllers;
using gubiarpa.onnesta.api.Dtos;
using gubiarpa.onnesta.api.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<JobSeekerContext>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient<IMapper, Mapper>();

var app = builder.Build();

#region DocumentType
app.MapGet("document-type", async (IMapper mapper, JobSeekerContext context) =>
{
    var documentTypes = await context.DocumentTypes
        .Select(documentType => mapper.Map<DocumentTypeDto>(documentType))
        .ToListAsync();

    if (documentTypes is null || !documentTypes.Any())
        return Results.NotFound();

    return Results.Ok(documentTypes);
});
#endregion

#region Employer
app.MapGet("employer", async (IMapper mapper, JobSeekerContext context) =>
{
    var employers = await context.Employers
        .Select(employer => mapper.Map<EmployerDto>(employer))
        .ToListAsync();

    if (employers is null || !employers.Any())
        return Results.NotFound();

    return Results.Ok(employers);
});

app.MapGet("employer/{id}", async (IMapper mapper, JobSeekerContext context, Guid id) =>
{
    var employer = await context.Employers
        .FindAsync(id);

    if (employer is null)
        return Results.NotFound();

    return Results.Ok(mapper.Map<EmployerDto>(employer));
});
#endregion

#region Job
app.MapGet("job", async (IMapper mapper, JobSeekerContext context) =>
{
    var jobs = await context.Jobs
        .Select(job => mapper.Map<JobDto>(job))
        .ToListAsync();

    if (jobs is null || !jobs.Any())
        return Results.NotFound();

    return Results.Ok(jobs);
});
#endregion

app.Run();
