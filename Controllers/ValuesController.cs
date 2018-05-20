using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using MiningPredictionAPI.Models;
using Flurl.Http;

namespace MiningPredictionAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAnyOrigin")]
    //[Authorize]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<object> GetAsync([FromQuery]BToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else 
            {
                Exchange response = await "https://bittrex.com/api/v1.1/public/getmarkets"
                .GetJsonAsync<Exchange>();

                if (!string.IsNullOrEmpty(token.curr))
                {
                    List<Result> results = new List<Result>();
                    foreach (var r in response.Result)
                    {
                        if (r.MarketCurrency == token.curr)
                        {
                            results.Add(r);
                        }
                    }
                    if (results.Count() == 0)
                    {
                        return "Entered Token is not valid, Please correct and retry";
                    }
                    return results;
                }
                return response;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Value Get(int id)
        {
            return new Value { Id=id,Text="Value"};
        }

        // POST api/values
        [HttpPost]
        [Produces("application/Json", Type= typeof(Value))]
        public IActionResult Post([FromBody]Value value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return CreatedAtAction("Get", new { Id = value.Id }, value);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public class BToken
        {
            //[Required]
            //[MinLength(3)]
            public string curr { get; set; }
        }
    }

    public class Value
    {
        public  int Id { get; set; }

        [Required]
        public  string Text { get; set; }
    }
}
