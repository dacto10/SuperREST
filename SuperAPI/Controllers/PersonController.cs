using SuperAPI.Clases;
using SuperAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperAPI.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        [Route("api/person/{type}")]
        public async Task<ResponseValuesSchema<Person>> GetAsync(string type)
        {
            return await PersonService.getFromType(type);
        }

        [HttpPost]
        [Route("api/person")]
        public async Task<ResponseMessageSchema> PostAsync()
        {
            return await PersonService.updatePeopleFiles();
        }

        [HttpDelete]
        [Route("api/person/{type}")]
        public ResponseMessageSchema Delete(string type)
        {
            return PersonService.deleteFromType(type);
        }

        [HttpPut]
        [Route("api/person")]
        public async Task<ResponseValuesSchema<Person>> PutAsync([FromBody] Person person)
        {
            return await PersonService.updatePerson(person);
        }
    }
}
