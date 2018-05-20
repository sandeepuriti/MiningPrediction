using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiningPredictionAPI.Data;
using Flurl.Http;
using System.ComponentModel.DataAnnotations;

namespace MiningPredictionAPI.Controllers
{
    //[Produces("application/json")]
    [Route("api/[Controller]")]
    public class PriceController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<object> GetAsync([FromQuery]Token Tokens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                string[] parms = Tokens.Query.Split(new char[] { ',' }, 2);

                if (parms.Length >= 2)
                {
                    // public cryptocompare API
                    string clientUrl = string.Format("https://min-api.cryptocompare.com/data/price?fsym={0}&tsyms={1}", parms[0], parms[1]);

                    var results = await clientUrl
                        .GetJsonAsync();

                    return results;
                }
                else
                {
                    return "Comparision currency token not provided";
                }

            }

        }

        // GET api/values/5
        //[HttpGet("[id]")]
        //public string Get(int id)
        //{
        //    return "Under Construction....";
        //}

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                return CreatedAtAction("Get", new { Id = value }, value);
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
    }

    public class Token
    {
        [RegularExpression(@"BTC,LTC,DOGE,VTC,PPC,FTC,RDC,NXT,DASH,POT,BLK,EMC2")]
        private string query;

        [Required]
        public string Query { get => query; set => query = value; }
    }
}