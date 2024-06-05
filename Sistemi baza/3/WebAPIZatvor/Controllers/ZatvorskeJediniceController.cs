using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class ZatvorskeJediniceController : Controller
    {
        [HttpGet("VratiSveZatvore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> VratiSveZatvore()
        {
            var result = DTOManager.VratiSveZatvore();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

   
        
        [HttpGet("VratiZatvoreZaFirmu/{firmaPIB}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult VratiZatvoreZaFirmu(int firmaPIB)
        {
            var result = DTOManager.VratiZatvoreZaFirmu(firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("DodajZatvorskuJedinicu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DodajZatvorskuJedinicu([FromQuery] string tip, [FromBody] ZatvorskaJedinicaPregled zatvorskaJedinica)
        {
            if (zatvorskaJedinica == null)
            {
                return BadRequest("Podaci o zatvorskoj jedinici nisu poslati.");
            }

            var result = DTOManager.DodajZatvorskuJedinicu(tip, zatvorskaJedinica);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpDelete("ObrisiZatvor/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> ObrisiZatvor(int id)
        {
            var result = await DTOManager.ObrisiZatvor(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpPut("IzmeniZatvorskuJedinicu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> IzmeniZatvorskuJedinicu([FromBody] ZatvorskaJedinicaPregled zatvorskaJedinica)
        {
            if (zatvorskaJedinica == null)
            {
                return BadRequest("Podaci o zatvorskoj jedinici nisu poslati.");
            }

            var result = await DTOManager.IzmeniZatvorskuJedinicu(zatvorskaJedinica);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpGet("VratiZatvorskuJedinicu/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult VratiZatvorskuJedinicu(int id, [FromQuery] string tip)
        {
            var result = DTOManager.VratiZatvorskuJedinicu(id, tip);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiMoguceUpravnike/{zatvorskaJedinicaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult VratiMoguceUpravnike(int zatvorskaJedinicaId)
        {
            var result = DTOManager.VratiMoguceUpravnike(zatvorskaJedinicaId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpPost("DodeliUpravnika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DodeliUpravnika(string zaposleniJMBG, int zatvorskaJedinicaId)
        {
            var result = DTOManager.DodeliUpravnika(zaposleniJMBG, zatvorskaJedinicaId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpGet("VratiUpravnika/{zatvorskaJedinicaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult VratiUpravnika(int zatvorskaJedinicaId)
        {
            var result = DTOManager.VratiUpravnika(zatvorskaJedinicaId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }








    }
}
