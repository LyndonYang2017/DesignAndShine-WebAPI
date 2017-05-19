using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSExerciseMain_DB;


namespace AngularJSExerciseMain_API.Controllers
{
    public class DSLoginController : ApiController
    {
        public HttpResponseMessage Get(string iPadName = "",string stationName = "", string password = "")
        {
            using (DSEntities entities = new DSEntities())
            {
                var entity = entities.Logins.FirstOrDefault(e => e.iPadName == iPadName && e.password == password && e.stationName == stationName);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login user didn't found");
                }
            }
        }
    }
}