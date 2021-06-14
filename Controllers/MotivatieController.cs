using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using motivatieservice.DTO;
using motivatieservice.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motivatieservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivatieController : Controller
    {
        private readonly CounterService _counterService;

        public MotivatieController(CounterService counterService)
        {
            _counterService = counterService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("motivatie")]
        public ActionResult<string> Motivatie(MotivatieDTO motievatieDTO)
        {
            System.Diagnostics.Process.Start("https://motivatiebutton20210611153721.azurewebsites.net/api/Motivatie?");
            string username = motievatieDTO.Username;
            string answer = _counterService.CountUp(username);
            return answer;
        }

      
    }
}
