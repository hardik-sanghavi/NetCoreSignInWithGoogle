using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreSignInWithGoogle.Models;
using Newtonsoft.Json;

namespace NetCoreSignInWithGoogle.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        /// <returns></returns>
        [Route("SSO/Google")]
        public async Task<IActionResult> GoogleSSO(string credential)
        {
            if (string.IsNullOrWhiteSpace(credential))
                return RedirectToAction("Login", "Account");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var url = $"https://oauth2.googleapis.com/tokeninfo";
                    var json = JsonConvert.SerializeObject(new { id_token = credential });
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    //validate the token by the google api
                    var tokenResponse = await client.PostAsync(url, data);
                    string result = tokenResponse.Content.ReadAsStringAsync().Result;
                    if (result != null)
                    {
                        var tokenData = JsonConvert.DeserializeAnonymousType(result, new
                        {
                            email = string.Empty,
                            email_verified = false,
                            given_name = string.Empty,
                            family_name = string.Empty
                        });

                        if (tokenData != null && tokenData.email_verified && !string.IsNullOrWhiteSpace(tokenData.email))
                        {
                            // add your logic for register and login into your application
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Login", "Account");
        }
    }
}