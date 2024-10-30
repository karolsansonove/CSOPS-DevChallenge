using CSOPS.DevChallenge;
using CSOPS.DevChallenge.Clients;
using CSOPS.DevChallenge.Components;
using CSOPS.DevChallenge.Context;
using CSOPS.DevChallenge.Context.Entities;
using CSOPS.DevChallenge.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
builder.Services.AddControllers();

builder.Services.AddDbContext<ChallengeContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("Default")!);
	options.EnableSensitiveDataLogging();
});


builder.Services.AddHttpClient<ITalkClient, TalkClient>((sp, client) =>
{
    var appSettings = sp.GetRequiredService<IOptions<AppSettings>>();
    client.BaseAddress = new Uri("https://rc-app-utalk.umbler.com/api/v1/");
    client.DefaultRequestHeaders.Authorization = new("Bearer", appSettings.Value.Talk2ApiToken);
});

builder.Services.AddScoped<IChatInfoService, ChatInfoService>();
builder.Services.AddScoped<IContactInfoService, ContactInfoService>();
builder.Services.AddScoped<ISearchHistoryInfoService, SearchHistoryInfoService>();
builder.Services.AddScoped<INoteInfoService, NoteInfoService>();
builder.Services.AddScoped<IScheduledMessageInfoService, ScheduledMessageInfoService>();
builder.Services.AddScoped<IContactService, ContactService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();  

app.Run();
