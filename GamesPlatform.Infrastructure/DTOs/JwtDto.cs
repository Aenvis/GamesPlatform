﻿namespace GamesPlatform.Infrastructure.DTOs
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long Expires { get; set; }

        public JwtDto(string token, long expires)
        {
            Token = token;
            Expires = expires;
        }
    }
}
