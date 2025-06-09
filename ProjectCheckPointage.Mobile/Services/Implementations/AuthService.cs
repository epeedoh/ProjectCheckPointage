using ProjectCheckPointage.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheckPointage.Mobile.Services.Implementations
{
    public class AuthService : IAuthService
    {
        public async Task<bool> LoginAsync(string username, string password)
        {
            // Appel API réel ici
            await Task.Delay(500); // Simule un appel
            return username == "admin" && password == "1234";
        }
    }
}
