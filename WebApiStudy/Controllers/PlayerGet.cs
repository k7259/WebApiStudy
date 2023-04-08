using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System;
using WebApiStudy.ModelFolder;

namespace WebApiStudy.Controllers
{
//	1xx Request received and under processing
//2xx Successful
//3xx Redirection, an action must be taken by either user agent(browser) or user
//4xx Invalid Request by the client, might be because of incomplete and invalid data
//5xx Server Error
	public class PlayerGet : ControllerBase
	{
		
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
		//[HttpGet]
		//[Route(template: "GetPlayers")]
		//public async Task<ActionResult<IEnumerable<IplPlayer>>> GetPlayers()
		//{
		//	if (dB.PlayersList == null)
		//	{
		//		return BadRequest();
		//	}
		//	return await dB.PlayersList.ToListAsync();
		//}
		[HttpPatch]
		[Route(template: "UpdatePlayer")]
		public IActionResult UpdatePlayer(IplPlayer player)
			
		{
			var dbPlayer= dB.PlayersList.FirstOrDefault(p=>p.Id == player.Id);
			if (dbPlayer != null)
			{
				dbPlayer.Name = player.Name;
				dbPlayer.Team = player.Team;
				dB.SaveChanges();
				return Ok();
			}
			else
			{
				return NotFound();
			}
			
			
			
		}
		[HttpDelete]
		[Route(template: "DeletePlayer")]
		public IActionResult DeletePlayer(IplPlayer player1)
		{
			var dbPlayer = dB.PlayersList.SingleOrDefault(x => x.Id == player1.Id);
			
				dB.Remove(dbPlayer);
				dB.SaveChanges();
				return Ok();
			}
			//List<IplPlayer> list = dB.PlayersList.ToList();
			
			
		}
		
		

	}
