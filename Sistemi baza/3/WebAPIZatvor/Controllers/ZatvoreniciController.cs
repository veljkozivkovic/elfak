using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class ZatvoreniciController : Controller
    {




        [HttpGet("VratiZatvorenikeZaZatvorskuJedinicu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ZatvorenikPregled>> VratiZatvorenikeZaZatvorskuJedinicu([FromQuery] int idZatvorskeJedinice)
        {
            var result = DTOManager.VratiZatvorenikeZaZatvorskuJedinicu(idZatvorskeJedinice);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiZatvorenikeZaAdvokata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ZatvorenikPregled>> VratiZatvorenikeZaAdvokata([FromQuery] string advokatJMBG)
        {
            var result = DTOManager.VratiZatvorenikeZaAdvokata(advokatJMBG);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiMoguceZatvorenikeZaAdvokata")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ZatvorenikPregled>> VratiMoguceZatvorenikeZaAdvokata([FromQuery] string advokatJMBG)
        {
            var result = DTOManager.VratiMoguceZatvorenikeZaAdvokata(advokatJMBG);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiZatvorenikeZaFirmu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ZatvorenikPregled>> VratiZatvorenikeZaFirmu([FromQuery] int firmaPIB)
        {
            var result = DTOManager.VratiZatvorenikeZaFirmu(firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiPotencijalneRadnike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ZatvorenikPregled>> VratiPotencijalneRadnike([FromQuery] int firmaPIB)
        {
            var result = DTOManager.VratiPotencijalneRadnike(firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpPost("DodajZatvorenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<bool>> DodajZatvorenika([FromBody] ZatvorenikBasic zatvorenikBasic, [FromQuery] int idZatvorskeJedinice)
        {
            var result = await DTOManager.DodajZatvorenikaAsync(zatvorenikBasic, idZatvorskeJedinice);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpPost("IzmeniZatvorenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> IzmeniZatvorenika([FromBody] ZatvorenikBasic zatvorenikBasic, [FromQuery] int idZatvorskeJedinice)
        {
            var result = DTOManager.IzmeniZatvorenika(zatvorenikBasic, idZatvorskeJedinice);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpGet("VratiZatvorenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<ZatvorenikBasic?> VratiZatvorenika(int id)
        {
            var result = DTOManager.VratiZatvorenika(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpDelete("ObrisiZatvorenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> ObrisiZatvorenika(int id)
        {
            var result = DTOManager.ObrisiZatvorenika(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("VratiSveZatvorenike")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<List<ZatvorenikPregled>> VratiSveZatvorenike()
        {
            var result = DTOManager.VratiSveZatvorenike();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }











    }
}
