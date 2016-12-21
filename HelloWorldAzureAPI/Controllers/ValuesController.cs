using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using HelloWorldAzureAPI.Models;
using System.Web.Script.Serialization;

namespace HelloWorldAzureAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [SwaggerOperation("GetAll")]
        public List<ValueModel> Get()
        {
            var cs = Properties.Settings.Default.PostgresConnection;
            return ValueCollectionModel.values;  
        }

        // GET api/values/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public ValueModel Get(int id)
        {
            return ValueCollectionModel.values[0];
        }

        // POST api/values
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public IEnumerable<string> Post([FromBody]ValueModel value)
        {
            ValueCollectionModel.values.Add(value);
            return new string[] { "Success" };
        }
        
        // PUT api/values/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IEnumerable<string> Put(int id, [FromBody]ValueModel value)
        {
            ValueCollectionModel.values[id - 1] = value;
            return new string[] { "Success" };
        }

        // DELETE api/values/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IEnumerable<string> Delete(int id)
        {
            ValueCollectionModel.values.RemoveAt(id - 1);
            return new string[] { "Success" };
        }
    }
}
