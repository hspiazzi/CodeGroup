using System.Collections.Generic;
using System.Net;
using System.Web.Http;


namespace PM.Presentation.Web.Controller
{
    public class MembroController : ApiController
    {
        // GET api/<controller>
        [Route("api/membro")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        //[SwaggerRequestExample(typeof(UsuarioCriacaoRequest), typeof(ExemploUsuarioCriacao))]
        [Route("api/membro/{id}")]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}