using DMCIT.Core.Interfaces;
using System;
using System.Text;

namespace DMCIT.Web.Configurations
{
    public class ApiConfiguration
    {
        public static string JWT_SECRET_KEY = "JWT_SECRET";
        public string JwtIssuer { get; set; }
        public int JwtExpireDays { get; set; }

        public static byte[] GetJWTSecretKey()
        {
            var keyString = Environment.GetEnvironmentVariable(JWT_SECRET_KEY);
            var key = Encoding.ASCII.GetBytes(keyString);
            return key;
        }
    }
}
