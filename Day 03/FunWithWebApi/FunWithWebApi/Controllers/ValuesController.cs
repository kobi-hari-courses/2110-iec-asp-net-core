using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithWebApi.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<int> GetSomeValues()
        {
            yield return 1;
            yield return 3;
            yield return 7;
            yield return 22;
            yield return 42;

        }

        [HttpGet("even")]
        public IEnumerable<int> GetEvenNumbers()
        {
            yield return 2;
            yield return 4;
            yield return 6;
            yield return 8;

        }

        [HttpGet("mult/{i}")]
        public int MultiplyByThree(int i)
        {
            return i * 3;
        }

        [HttpGet("mult/{i}/{j}")]
        public int Multiply(int i, int k, string blablabla)
        {
            return i * k;
        }


    }
}
