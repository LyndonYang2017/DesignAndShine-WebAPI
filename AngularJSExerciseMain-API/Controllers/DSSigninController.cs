using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSExerciseMain_DB;

namespace AngularJSExerciseMain_API.Controllers
{
    public class DSSigninController : ApiController
    {
        public HttpResponseMessage Get(string IDNumber = "", string email = "")
        {
            if ((IDNumber == "" || IDNumber == null) && (email == "" || email == null))
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login user didn't found");

            using (DSEntities entities = new DSEntities())
            {
                Signin entity = null;

                if (IDNumber != "" && IDNumber != null)
                    entity = entities.Signins.FirstOrDefault(e => e.IDNumber == IDNumber);
                else
                    entity = entities.Signins.FirstOrDefault(e => e.Email == email);

                if (entity != null)
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login user didn't found");
            }
        }
    }
}
