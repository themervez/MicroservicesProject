// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ECommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
             new IdentityResource[]
             {  new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.OpenId()
             };

        public static IEnumerable<ApiResource> ApiResources =>
           new ApiResource[]//It shows which APIs are allowed
           {
              new ApiResource("Resource_Catalog")    {Scopes={ "Catalog_FullPermission"}},
              //new ApiResource("Resource_Order")      {Scopes={ "Order_FullPermission" }},
              //new ApiResource("Resource_Discount")   {Scopes={ "Discount_FullPermission" }},
              //new ApiResource("Resource_Basket")     {Scopes={ "Basket_FullPermission" }},
              //new ApiResource("Resource_FakePayment"){Scopes={ "FakePayment_FullPermission" }},
              new ApiResource("Resource_PhotoStock"){Scopes={ "PhotoStock_FullPermission" }},
              new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
           };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
               new ApiScope("Catalog_FullPermission","Catalog API için tam yetkili erişim"),
               //new ApiScope("Order_FullPermission","Order API için tam yetkili erişim"),
               //new ApiScope("Discount_FullPermission","Discount API için tam yetkili erişim"),
               //new ApiScope("Basket_FullPermission","Basket API için tam yetkili erişim"),
               //new ApiScope("FakePayment_FullPermission","FakePayment API için tam yetkili erişim"),
               new ApiScope("PhotoStock_FullPermission","PhotoStock API için tam yetkili erişim"),
               new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client

                new Client //It will be run without authentication to the system
                {
                    ClientId = "mvcclient",
                    ClientName = "asp.netcoremvc",

                    AllowedGrantTypes = GrantTypes.ClientCredentials, //It will show which systems are allowed for the current client
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { "Catalog_FullPermission",
                                      //"Order_FullPermission",
                                      //"Discount_FullPermission",
                                      //"Basket_FullPermission",
                                      //"FakePayment_FullPermission",
                                      "PhotoStock_FullPermission",
                                       IdentityServerConstants.LocalApi.ScopeName
                                     }
                },

                // interactive client using code flow + pkce

                new Client //Client that after authentication
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    AccessTokenLifetime=900,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                },
            };
    }
}
//postman for token-body post request:https://localhost:5001/Connect/Token
//client_id:mvcclient
//client_secret:secret
//grant_type:client_credentials  
//jwt.io: for decode the token