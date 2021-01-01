﻿using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurant.Backend.CommonApi.Utils
{
    public static class JwtCreationUtil
    {
        public static string CreateJwtToken(Claim[] claims, IConfiguration configuration)
        {
            var jwtKey = GetJwtToken(configuration);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public static string GetJwtToken(IConfiguration configuration)
        {
            var secret = configuration.GetSection("AppSettings:Jwt:Environment").Value;
            var jwtKey = configuration.GetSection("AppSettings:Jwt:Token").Value;

            if (secret.ToUpper() == "PRODUCTION")
            {
                var tenantId = configuration.GetSection("AppSettings:Jwt:TenantId").Value;
                var clientId = configuration.GetSection("AppSettings:Jwt:ClientId").Value;
                var clientSecret = configuration.GetSection("AppSettings:Jwt:ClientSecret").Value;
                var vaultUri = new Uri(configuration.GetSection("AppSettings:Jwt:VaultUri").Value);

                var client = new SecretClient(vaultUri: vaultUri, credential: new ClientSecretCredential(tenantId, clientId, clientSecret));
                var jwtKeySecret = (client.GetSecretAsync(secret).Result).Value;
                jwtKey = jwtKeySecret.Value;
            }

            return jwtKey;
        }
    }
}
