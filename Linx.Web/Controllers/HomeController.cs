using IdentityModel.Client;
using Linx.Web.Autorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Owin.Authorization.Mvc;

namespace Linx.Web.Controllers
{
    //[CustomAuthorize()]
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var user = User as ClaimsPrincipal;

            if (User.Identity.IsAuthenticated == true)
            {
                Linx.Web.Controllers.CallApiController call = new CallApiController();

                var contUser = call.ClientCredentials();

                var access = (User as ClaimsPrincipal).Claims;

                var userName = access.Select(d => d.Value).ToList();

                return View((User as ClaimsPrincipal).Claims);
            }         
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        
        [Authorize]
        public ActionResult SignIn()
        {
            return RedirectToAction("Index");
            // return View((User as ClaimsPrincipal).Claims);

            //var state = Guid.NewGuid().ToString("N");
            //var nonce = Guid.NewGuid().ToString("N");

            //var url = AuthorizeUri +
            //    "?client_id=Linx" +
            //    "&response_type=id_token" +
            //    "&scope=openid email profile" +
            //    "&redirect_uri=" + CallbackEndpoint +
            //    "&response_mode=form_post" +
            //    "&state=" + state +
            //    "&nonce=" + nonce;

            //this.SetTempCookie(state, nonce);

            //return this.Redirect(url);

            //http://localhost:51346/login?signin=992a561628a36cbdee3e5186bc46c25e
            //return this.Redirect("http://localhost:51346/login?signin=992a561628a36cbdee3e5186bc46c25e");
        }

        private void SetTempCookie(string state, string nonce)
        {
            var tempId = new ClaimsIdentity("TempCookie");
            tempId.AddClaim(new Claim("state", state));
            tempId.AddClaim(new Claim("nonce", nonce));

            this.Request.GetOwinContext().Authentication.SignIn(tempId);
        }

        private async Task<IEnumerable<Claim>> ValidateIdentityTokenAsync(string token, string state)
        {
            const string certString = "MIIDBTCCAfGgAwIBAgIQNQb+T2ncIrNA6cKvUA1GWTAJBgUrDgMCHQUAMBIxEDAOBgNVBAMTB0RldlJvb3QwHhcNMTAwMTIwMjIwMDAwWhcNMjAwMTIwMjIwMDAwWjAVMRMwEQYDVQQDEwppZHNydjN0ZXN0MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqnTksBdxOiOlsmRNd+mMS2M3o1IDpK4uAr0T4/YqO3zYHAGAWTwsq4ms+NWynqY5HaB4EThNxuq2GWC5JKpO1YirOrwS97B5x9LJyHXPsdJcSikEI9BxOkl6WLQ0UzPxHdYTLpR4/O+0ILAlXw8NU4+jB4AP8Sn9YGYJ5w0fLw5YmWioXeWvocz1wHrZdJPxS8XnqHXwMUozVzQj+x6daOv5FmrHU1r9/bbp0a1GLv4BbTtSh4kMyz1hXylho0EvPg5p9YIKStbNAW9eNWvv5R8HN7PPei21AsUqxekK0oW9jnEdHewckToX7x5zULWKwwZIksll0XnVczVgy7fCFwIDAQABo1wwWjATBgNVHSUEDDAKBggrBgEFBQcDATBDBgNVHQEEPDA6gBDSFgDaV+Q2d2191r6A38tBoRQwEjEQMA4GA1UEAxMHRGV2Um9vdIIQLFk7exPNg41NRNaeNu0I9jAJBgUrDgMCHQUAA4IBAQBUnMSZxY5xosMEW6Mz4WEAjNoNv2QvqNmk23RMZGMgr516ROeWS5D3RlTNyU8FkstNCC4maDM3E0Bi4bbzW3AwrpbluqtcyMN3Pivqdxx+zKWKiORJqqLIvN8CT1fVPxxXb/e9GOdaR8eXSmB0PgNUhM4IjgNkwBbvWC9F/lzvwjlQgciR7d4GfXPYsE1vf8tmdQaY8/PtdAkExmbrb9MihdggSoGXlELrPA91Yce+fiRcKY3rQlNWVd4DOoJ/cPXsXwry8pWjNCo5JD8Q+RQ5yZEy7YPoifwemLhTdsBz3hlZr28oCGJ3kbnpW0xGvQb3VHSTVVbeei0CfXoW6iz1";

            var cert = new X509Certificate2(Convert.FromBase64String(certString));

            var result = await this.Request
                .GetOwinContext()
                .Authentication
                .AuthenticateAsync("TempCookie");

            if (result == null)
            {
                throw new InvalidOperationException("No temp cookie");
            }

            if (state != result.Identity.FindFirst("state").Value)
            {
                throw new InvalidOperationException("invalid state");
            }

            var parameters = new System.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidAudience = "implicitclient",
                //ValidIssuer = IdServBaseUri,
                IssuerSigningToken = new X509SecurityToken(cert)
            };

            var handler = new JwtSecurityTokenHandler();
            System.IdentityModel.Tokens.SecurityToken jwt;
            var id = handler.ValidateToken(token, parameters, out jwt);

            if (id.FindFirst("nonce").Value != result.Identity.FindFirst("nonce").Value)
            {
                throw new InvalidOperationException("Invalid nonce");
            }

            this.Request.GetOwinContext().Authentication.SignOut("TempCookie");

            return id.Claims;
        }

        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                Request.GetOwinContext().Authentication.SignOut();
                return Redirect("/");
            }

            return RedirectToAction("Index");
        }

        public ActionResult SignOut()
        {
            this.Request.GetOwinContext().Authentication.SignOut();
            return this.Redirect("");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ResourceAuthorize("Admin", "ContactDetails")]
        public ActionResult LogOn()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ResourceAuthorize("Post", "LogOn")]
        public async Task<ActionResult> LogOn(Linx.Domain.Mapping.Entities.UsuarioAccess model)
        {

            var user = new Linx.Domain.Mapping.Entities.UsuarioAccess { Login = model.Login, Senha = model.Senha };

            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserClaimsConseg()
        {
            Linx.Domain.Core.Repository.UserClaimsConsegRepository _repository = new Domain.Core.Repository.UserClaimsConsegRepository();
            var model = _repository.GetAll().ToList();
            return View(model);
        }

        public ActionResult HistoricoDeAccess()
        {
              return View();
        }

        public ActionResult Clients()
        {
            Linx.Domain.Core.Repository.ClientRepository _repository = new Domain.Core.Repository.ClientRepository();
            var model = _repository.GetAll().ToList();
            return View(model);           
        }


        public ActionResult Tokens()
        {
            Linx.Domain.Core.Repository.TokenRepository _repository = new Domain.Core.Repository.TokenRepository();
            var model = _repository.GetAll().ToList();
            return View(model);
        }

        public ActionResult ClientSecret()
        {
            Linx.Domain.Core.Repository.ClientSecretRepository _repository = new Domain.Core.Repository.ClientSecretRepository();
            var model = _repository.GetAll().ToList();
            return View(model);
        }

        //var tokenacess = user.FindFirst("access_token").Value;
        //var id_token = user.FindFirst("id_token").Value;
        //var experiaton = user.FindFirst("expires_at").Value;
        //var client = new HttpClient();
        //var json = new TokenClient("http://localhost:37615/connect/token", "id_token", "secret");


    }
}