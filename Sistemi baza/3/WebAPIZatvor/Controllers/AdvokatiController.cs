using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class AdvokatiController : Controller
    {
        [HttpGet("VratiSveAdvokate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<List<AdvokatPregled>> VratiSveAdvokate()
        {
            var result = DTOManager.VratiSveAdvokate();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpGet("VratiAdvokata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<AdvokatBasic> VratiAdvokata([FromQuery] string jmbg)
        {
            var result = DTOManager.VratiAdvokata(jmbg);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpPost("DodajAdvokata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<bool>> DodajAdvokata([FromBody] AdvokatBasic advokatBasic)
        {
            var result = await DTOManager.DodajAdvokataAsync(advokatBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpPost("IzmeniAdvokata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> IzmeniAdvokata([FromBody] AdvokatBasic advokatBasic)
        {
            var result = DTOManager.IzmeniAdvokata(advokatBasic);

            if (result.IsError)
            {
                if (result.Error.StatusCode == 404)
                {
                    return NotFound(result.Error.Message);
                }
                else
                {
                    return StatusCode(result.Error.StatusCode, result.Error.Message);
                }
            }

            return Ok(result.Data);
        }






        [HttpDelete("ObrisiAdvokata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> ObrisiAdvokata([FromQuery] string advokatJMBG)
        {
            var result = DTOManager.ObrisiAdvokata(advokatJMBG);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpPost("DodajZastupanje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> DodajZastupanje([FromQuery] int zatvorenikId, [FromQuery] string advokatJMBG)
        {
            var result = DTOManager.DodajZastupanje(zatvorenikId, advokatJMBG);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpPost("OtkaziZastupanje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> OtkaziZastupanje([FromQuery] int zatvorenikId)
        {
            var result = DTOManager.OtkaziZastupanje(zatvorenikId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }











    }
}
