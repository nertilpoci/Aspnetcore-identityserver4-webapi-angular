using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBasic
{


    }
    public class Config
    {
    public static string HOST_URL = "http://localhost:5000";

    public static IEnumerable<ApiResource> GetApiResources()
    {
        var api1 = new ApiResource("api1", "My API");
        api1.ApiSecrets = new List<Secret> { new Secret("secret".Sha256()) };
            return new List<ApiResource>
            {
               api1
            };
       
    }
    public static IEnumerable<Client> GetClients()
        {
        return new List<Client>
    {
        new Client
        {
                     ClientId = "demo-resource-owner",
                    ClientName = "JavaScript Resource Owner Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets=new List<Secret>{ new Secret( "secret".Sha256(), "2017 secret")},
                    RedirectUris = { "http://localhost:5000/login" },
                    PostLogoutRedirectUris = { "http://localhost:5000" },
                    AllowedCorsOrigins = { "http://localhost:5000/" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
    AllowOfflineAccess = true,AlwaysIncludeUserClaimsInIdToken=true
        },
        new Client
{
    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    ClientSecrets=new List<Secret>{ new Secret( "secret".Sha256(), "2017 secret")},

                    AllowAccessTokensViaBrowser = true,
                    RequireClientSecret=false,
                    RequireConsent=false,
                    RedirectUris = { "http://localhost:5000/login" },
                    PostLogoutRedirectUris = { "http://localhost:5000" },
                    AllowedCorsOrigins = { "http://localhost:5000/" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
    AllowOfflineAccess = true,AlwaysIncludeUserClaimsInIdToken=true
},

        


        };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
    {
        new TestUser
        {
            SubjectId = "1",
            Username = "username",
            Password = "password"
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "bob",
            Password = "password"
        }
    };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResources.Email()
    };
        }
    }

