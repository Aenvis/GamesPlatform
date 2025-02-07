﻿using GamesPlatform.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace GamesPlatform.Infrastructure.Options
{
    public class JwtSettingsSetup : IConfigureOptions<JwtSettings>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration _configuration;

        public JwtSettingsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(JwtSettings options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
