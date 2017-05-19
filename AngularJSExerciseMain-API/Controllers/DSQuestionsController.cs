using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSExerciseMain_DB;

namespace AngularJSExerciseMain_API.Controllers
{
    public class DSQuestionsController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (DSEntities entities = new DSEntities())
            {
                return Request.CreateResponse(HttpStatusCode.OK, entities.Questions.ToList());
            }
        }
    }
}
