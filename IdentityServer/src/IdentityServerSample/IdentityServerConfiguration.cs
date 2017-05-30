using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServerSample
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("API", "Api Resources")
            };
        }

        public static IEnumerable<Client> GetClientScope()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "79E0C2E2-D750-45BC-8FA3-1A9D5F9F82B5",
                    ClientName = "MVC Client Access",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("1234567890".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "API"
                    },
                    RedirectUris = { "http://localhost:19855/signin-oidc" },

                    PostLogoutRedirectUris = { "http://localhost:19855" }
                }
            };

        }

        public static IEnumerable<TestUser> GetUsers()
        {
            yield return new TestUser()
            {
                SubjectId = "AAF38B9A-4989-4B8E-B6F5-3B6928CF36C1",
                Username = "tester_user",
                Password = "123456789",
                Claims = new List<Claim>()
                {
                    new Claim("name", "Tester User"),
                },
                
            };
        }
    }
}
