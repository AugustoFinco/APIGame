using API2.Model;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    public class PlayerController : ControllerBase
    {
        public static List<Player> players = new List<Player>() {
            { new Player { id = "1", Vida = 100, Item = 0, posX = 0f, posY = 0f, posZ = 0f } }
        };

        [HttpGet]
        [Route("usuariojogo")]
        public IActionResult GetPlayers()
        {
            return Ok(players);
        }

        [HttpGet]
        [Route("usuariojogo/{id}")]
        public IActionResult GetPlayerByID(string id)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        [Route("usuariojogo")]
        public IActionResult AddPlayer([FromBody] Player newPlayer)
        {
            players.Add(newPlayer);
            return Ok(newPlayer);
        }

        [HttpPut]
        [Route("usuariojogo/{id}")]
        public IActionResult UpdatePlayer(string id, [FromBody] Player updatedPlayer)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            player.Vida = updatedPlayer.Vida;
            player.Item = updatedPlayer.Item;
            player.posX = updatedPlayer.posX;
            player.posY = updatedPlayer.posY;
            player.posZ = updatedPlayer.posZ;
            return Ok(player);
        }

        [HttpDelete]
        [Route("usuariojogo/{Id}")]
        public IActionResult DeletePlayer(string id)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            players.Remove(player);
            return Ok();
        }
    }
}
