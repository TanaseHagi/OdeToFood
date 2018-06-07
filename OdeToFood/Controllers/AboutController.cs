using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+1 234 567 8901";
        }

        [Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}
