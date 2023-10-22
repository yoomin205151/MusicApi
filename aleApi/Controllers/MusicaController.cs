using aleApi.Date;
using aleApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace aleApi.Controllers
{
    [ApiController]
    [Route("api/musica")]
    public class MusicaController:ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Musica>>> Get()
        {
            var function = new DBmusica();
            var list = await function.ShowMusic();
            return list;
        }

        [HttpPost]
        public async Task Post([FromBody] Musica parametros)
        {
            var function = new DBmusica();
            await function.InsertMusic(parametros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Musica parametros)
        {
            var function = new DBmusica();
            parametros.id = id;
            await function.EditMusic(parametros);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var function = new DBmusica();
            var parametros = new Musica();
            parametros.id = id;
            await function.RemoveMusic(parametros);
            return NoContent();
        }
    }
}
