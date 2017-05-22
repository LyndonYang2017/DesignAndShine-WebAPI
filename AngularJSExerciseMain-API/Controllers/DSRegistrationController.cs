using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSExerciseMain_DB;

namespace AngularJSExerciseMain_API.Controllers
{
    public class DSRegistrationController : ApiController
    {
        public HttpResponseMessage Post([FromBody] Registration registration)
        {
            try
            {
                using (DSEntities entities = new DSEntities())
                {
                    entities.Registrations.Add(registration);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, registration);
                    message.Headers.Location = new Uri(Request.RequestUri + registration.ID.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Get()
        {
            using (DSEntities entities = new DSEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, entities.Registrations.ToList());
            }
        }
    }
}
