using Microsoft.AspNetCore.Mvc;
using WebApiStudy.ModelFolder;

namespace WebApiStudy.Controllers
{
    public class PlayerController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        ApplicationDB dB;
        public PlayerController(ApplicationDB dB)
        {this.dB = dB;
    
        }
        [HttpPost]
        [Route(template: "AddPlayer")]
        public IActionResult AddPlayer(IplPlayer player)
        {
            dB.PlayersList.Add(player);  
            dB.SaveChanges();
            return Ok();
        }

    }

}
