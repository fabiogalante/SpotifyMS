using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using P4F.Spotify.Application.Handler;
using P4F.Spotify.Application.Interfaces;
using P4F.Spotify.Application.Playlist;
using P4F.Spotify.Application.Settings;
using Polly;
using Polly.Extensions.Http;
using Refit;

namespace P4F.Spotify.Application.DependencyResolver
{
    public static class DependencyResolverService
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(typeof(List.Handler).Assembly);

            services.AddTransient<AuthTokenHandler>();

            services.Configure<SpotifySettings>(configuration.GetSection(nameof(SpotifySettings)));
            var spotifySettings = services.BuildServiceProvider().GetRequiredService<IOptions<SpotifySettings>>().Value;

            


            services.AddRefitClient<IAuth>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(spotifySettings.UriToken))
                .AddPolicyHandler(GetRetryPolicy());


            services.AddRefitClient<IPlaylist>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(spotifySettings.Uri))
                .AddHttpMessageHandler<AuthTokenHandler>()
                .AddPolicyHandler(GetRetryPolicy());

        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                    retryAttempt)));
        }
    }
}
