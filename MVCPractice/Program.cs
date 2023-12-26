using Microsoft.Extensions.DependencyInjection.Extensions;
using MVCPractice;
using MVCPractice.Controllers;
using MVCPractice.Mappers;
using MVCPractice.Models.dbContext;
using MVCPractice.Presentation;
using MVCPractice.Processors;
using MVCPractice.Storers;
using MVCPractice.Utilities;
using MVCPractice.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.TryAddScoped(typeof(ILogger<HomeController>), typeof(Logger<HomeController>));
builder.Services.TryAddScoped(typeof(ItemsContext), typeof(ItemsContext));
builder.Services.TryAddScoped(typeof(IRecordPosterValidator), typeof(RecordPosterValidator));
builder.Services.TryAddScoped(typeof(IGuidCreator), typeof(GuidCreator));
builder.Services.TryAddScoped(typeof(IRecordPosterMapper), typeof(RecordPosterMapper));
builder.Services.TryAddScoped<IRecordPosterStorer>(c => new RecordPosterStorer(c.GetRequiredService<ItemsContext>()));
builder.Services.TryAddScoped<IRecordPosterProcessor>(c => new RecordPosterProcessor(c.GetRequiredService<IRecordPosterValidator>(), c.GetRequiredService<IGuidCreator>(), c.GetRequiredService<IRecordPosterMapper>(), c.GetRequiredService<IRecordPosterStorer>()));

builder.Services.TryAddScoped(typeof(IByIdRecordGetterValidator), typeof(ByIdRecordGetterValidator));
builder.Services.TryAddScoped(typeof(IByIdRecordGetterMapper), typeof(ByIdRecordGetterMapper));
builder.Services.TryAddScoped(typeof(IOnIdFilterer), typeof(OnIdFilterer));
builder.Services.TryAddScoped<IByIdRecordGetterGetDatabaseAccessor>(c => new ByIdRecordGetterDatabaseAccessor(c.GetRequiredService<ItemsContext>()));
builder.Services.TryAddScoped<IByIdRecordGetterProcessor>(c => new ByIdRecordGetterProcessor(c.GetRequiredService<IByIdRecordGetterValidator>(), c.GetRequiredService<IByIdRecordGetterMapper>(), c.GetRequiredService<IByIdRecordGetterGetDatabaseAccessor>(), c.GetRequiredService<IOnIdFilterer>()));
builder.Services.TryAddScoped(typeof(IStringAllRecordsIntoOneCreator), typeof(StringAllRecordsIntoOneCreator));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "index",
    pattern: "{controller=ByIdRecordGetter}/{action=index}");

app.MapControllerRoute(
    name: "GetByUserId",
    pattern: "{controller=ByIdRecordGetter}/{action=GetByUserId}");

app.MapControllerRoute(
    name: "PostUserRecord",
    pattern: "{controller=Home}/{action=PostUserRecord}");

app.Run();
