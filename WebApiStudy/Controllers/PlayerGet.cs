using Microsoft.AspNetCore.Mvc;
using WebApiStudy.ModelFolder;

namespace WebApiStudy.Controllers
{
	public class PlayerGet : ControllerBase
	{
		//public class PlayerGet
		//{
		//}
		ApplicationDB dB;
		public PlayerGet(ApplicationDB data)
		{
			this.dB = data ;

		}
		[HttpGet]
		[Route(template: "GetPlayer")]
		public IActionResult GetPlayer()
		{
			List<IplPlayer> list = dB.PlayersList.ToList();

			return Ok(list);
		}

	}
}
