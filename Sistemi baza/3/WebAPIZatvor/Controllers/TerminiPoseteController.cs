using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class TerminiPoseteController : Controller
    {


        [HttpGet("VratiTerminePosete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult VratiTerminePosete(int id)
        {
            var result = DTOManager.VratiTerminePosete(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }







        [HttpPost("DodajTerminPosete/{idZatvorskeJedinice}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DodajTerminPoseteAsync([FromBody] TerminPoseteBasic terminPoseteBasic, int idZatvorskeJedinice)
        {
            var result = await DTOManager.DodajTerminPoseteAsync(terminPoseteBasic, idZatvorskeJedinice);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpPost("IzmeniTerminPosete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult IzmeniTerminPosete([FromBody] TerminPoseteBasic terminPoseteBasic)
        {
            var result = DTOManager.IzmeniTerminPosete(terminPoseteBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpGet("VratiTerminPosete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult VratiTerminPosete(int id)
        {
            var result = DTOManager.VratiTerminPosete(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpDelete("ObrisiTerminPosete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult ObrisiTerminPosete(int id)
        {
            var result = DTOManager.ObrisiTerminPosete(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

















    }
}
