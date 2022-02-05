using System;
namespace PetClinic.Services.NetworkService
{
    public static class ApiConstants
    {
        public static string GetLoginURL()
        {
            return "http://10.0.2.2:80/login";
        }

        public static string CustomerURL()
        {
            return "http://10.0.2.2:80/api/gateway/owners";
        }
    }
}
