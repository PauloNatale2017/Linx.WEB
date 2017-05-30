using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Linx.Web.webapi
{
    //[Authorize]
    public class LoginController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        //public Enumerable<Linx.Domain.Mapping.Entities.Users> GetUsers()
        //{ }

        [AcceptVerbs("GET")]
        public string Login(string Username, string Password)
        {
            Linx.Domain.Mapping.Entities.Users a = new Domain.Mapping.Entities.Users();
            try
            {
               
                //List<LogInOut> a = new List<LogInOut>();
                //a = Repository.GetAll().Where(d => d.Login == Login || d.Password == Password).ToList();
                //FormsAuthentication.SetAuthCookie("Paulo", true);
                return "";
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {

            }

            return "";
        }

    }
}