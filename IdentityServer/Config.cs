using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetAllIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetAllAPIResouces()
        {
            return new List<ApiResource>
            {
                new ApiResource("campus_api", "Campus API Resources")
            };
        }

        public static IEnumerable<Client> GetAllClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "campus_api" }
                },
                new Client
                {
                    ClientId = "angular",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    IdentityTokenLifetime = 60 * 60 * 24,

                    RedirectUris = { "http://localhost:4200/assets/signin-callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowedCorsOrigins = { "http://localhost:4200" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "campus_api"
                    }
                },
                new Client
                {
                    ClientId = "swagger",
                    ClientName = "Swagger Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:5001/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { "http://localhost:5001/swagger" },
                    AllowedCorsOrigins =     { "http://localhost:5001" },

                    AllowedScopes =
                    {
                        // IdentityServerConstants.StandardScopes.OpenId,
                        // IdentityServerConstants.StandardScopes.Profile,
                        "campus_api"
                    }
                }
            };
        }
    }
}
