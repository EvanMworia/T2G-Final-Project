using ArtGalleryFrontend;
using ArtGalleryFrontend.Services.AuthServices;
using ArtGalleryFrontend.UtilityService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TheJitu_Commerce_Frontend.Services.AuthProvider;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<UserStateService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//-----REGISTER LOCAL STORAGE--------
builder.Services.AddBlazoredLocalStorage();

//-------REGISTER OUR BACKEND SERVICES -------------
builder.Services.AddScoped<IAuth, AuthService>();

//Configuration for AuthProvider
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvideService>();


await builder.Build().RunAsync();
