using Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

var webApplicationOptions =
	new WebApplicationOptions
	{
		EnvironmentName =
			System.Diagnostics.Debugger.IsAttached ?
			Environments.Development
			:
			Environments.Production,
	};

var builder =
	Microsoft.AspNetCore.Builder
	.WebApplication.CreateBuilder(options: webApplicationOptions);

builder.Services.AddHttpContextAccessor();

builder.Services.AddRouting(options =>
{
	options.LowercaseUrls = true;
	options.LowercaseQueryStrings = true;

	options.AppendTrailingSlash = true;
	options.SuppressCheckForUnhandledSecurityMetadata = false;
});

builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.Configure<Infrastructure.Settings.ApplicationSettings>
	(builder.Configuration.GetSection(key: Infrastructure.Settings.ApplicationSettings.KeyName))
	.AddSingleton
	(implementationFactory: serviceType =>
	{
		var result =
			serviceType.GetRequiredService
			<Microsoft.Extensions.Options.IOptions
			<Infrastructure.Settings.ApplicationSettings>>().Value;

		return result;
	});

builder.Services
	.AddAuthentication(defaultScheme: Infrastructure.Security.Utility.AuthenticationScheme)
	.AddCookie(authenticationScheme: Infrastructure.Security.Utility.AuthenticationScheme);
// **************************************************

// **************************************************
//builder.Services
//	.AddAuthentication(defaultScheme: Infrastructure.Security.Utility.AuthenticationScheme)
//	.AddCookie(authenticationScheme: Infrastructure.Security.Utility.AuthenticationScheme)
//	.AddGoogle(authenticationScheme: Microsoft.AspNetCore.Authentication.Google.GoogleDefaults.AuthenticationScheme,
//	configureOptions: options =>
//	{
//		options.ClientId =
//			builder.Configuration["ApplicationSettings:Authentication:Google:ClientId"];

//		options.ClientSecret =
//			builder.Configuration["ApplicationSettings:Authentication:Google:ClientSecret"];

//		// MapJsonKey() -> using Microsoft.AspNetCore.Authentication;
//		options.ClaimActions.MapJsonKey
//			(claimType: "urn:google:picture", jsonKey: "picture", valueType: "url");
//	})
//	;
// **************************************************
// **************************************************
// **************************************************

var connectionString =
	builder.Configuration.GetConnectionString(name: "ConnectionString");

builder.Services.AddDbContext<Data.DatabaseContext>
	(optionsAction: options =>
	{
		options
			.UseLazyLoadingProxies();

		options
			.UseSqlServer(connectionString: connectionString);
	});

var app =
	builder.Build();

if (app.Environment.IsDevelopment())
{

	app.UseDeveloperExceptionPage();

}
else
{
	app.UseGlobalException();

	app.UseExceptionHandler("/Errors/Error");

	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseActivationKeys();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCultureCookie();
app.MapControllers();
app.MapRazorPages();
app.Run();
