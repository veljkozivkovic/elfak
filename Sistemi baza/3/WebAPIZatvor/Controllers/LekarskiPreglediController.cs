using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class LekarskiPreglediController : Controller
    {

        [HttpGet("VratiLekarskePreglede")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<List<LekarskiPregledPregled>> VratiLekarskePreglede([FromQuery] string zaposleniJMBG)
        {
            var result = DTOManager.VratiLekarskePreglede(zaposleniJMBG);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpPost("DodajLekarskiPregled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<bool>> DodajLekarskiPregledAsync([FromBody] LekarskiPregledBasic lekarskiPregled, [FromQuery] string zaposleniJMBG)
        {
            var result = await DTOManager.DodajLekarskiPregledAsync(lekarskiPregled, zaposleniJMBG);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }





        [HttpPost("IzmeniLekarskiPregled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> IzmeniLekarskiPregled([FromBody] LekarskiPregledBasic lekarskiPregled)
        {
            var result = DTOManager.IzmeniLekarskiPregled(lekarskiPregled);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpDelete("ObrisiLekarskiPregled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> ObrisiLekarskiPregled([FromQuery] int id)
        {
            var result = DTOManager.ObrisiLekarskiPregled(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiLekarskiPregled")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<LekarskiPregledBasic> VratiLekarskiPregled([FromQuery] int id)
        {
            var result = DTOManager.VratiLekarskiPregled(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("VratiSveLekarskePreglede")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<List<LekarskiPregledBasic>> VratiSveLekarskePreglede()
        {
            var result = DTOManager.VratiSveLekarskePreglede();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }












    }
}
