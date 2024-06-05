using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class TerminiSetnjeController : Controller
    {


        // na osnovu id zatvorske jedinice vraca sve termine setnje
        
        [HttpGet("VratiTermineSetnje/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<TerminSetnjePregled>> VratiTermineSetnje(int id)
        {
            var result = DTOManager.VratiTermineSetnje(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }
        


        
        [HttpPost("DodajTerminSetnje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> DodajTerminSetnje([FromBody] TerminSetnjeBasic terminSetnjeBasic, [FromQuery] int idZatvorskeJedinice)
        {
            var result = await DTOManager.DodajTerminSetnjeAsync(terminSetnjeBasic, idZatvorskeJedinice);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPut("IzmeniTerminSetnje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult IzmeniTerminSetnje([FromBody] TerminSetnjeBasic terminSetnjeBasic)
        {
            var result = DTOManager.IzmeniTerminSetnje(terminSetnjeBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiTerminSetnje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TerminSetnjeBasic> VratiTerminSetnje([FromQuery] int id)
        {
            var result = DTOManager.VratiTerminSetnje(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete("ObrisiTerminSetnje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ObrisiTerminSetnje([FromQuery] int id)
        {
            var result = await DTOManager.ObrisiTerminSetnjeAsync(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("VratiSveTermineSetnje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<TerminSetnjeBasic>> VratiSveTermineSetnje()
        {
            var result = DTOManager.VratiSveTermineSetnje();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }








    }
}
