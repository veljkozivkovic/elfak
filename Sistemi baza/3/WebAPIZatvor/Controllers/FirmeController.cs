using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class FirmeController : Controller
    {


        [HttpGet("VratiSveFirme")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<List<FirmaPregled>> VratiSveFirme()
        {
            var result = DTOManager.VratiSveFirme();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpGet("VratiFirmuZatvorenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public ActionResult<FirmaPregled?> VratiFirmuZatvorenika(int zatvorenikId)
        {
            var result = DTOManager.VratiFirmuZatvorenika(zatvorenikId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpGet("VratiFirmeZaZatvorenika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public ActionResult<List<FirmaPregled>> VratiFirmeZaZatvorenika(int zatvorenikId)
        {
            var result = DTOManager.VratiFirmeZaZatvorenika(zatvorenikId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiFirmeZaZatvorskuJedinicu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public ActionResult<List<FirmaPregled>> VratiFirmeZaZatvorskuJedinicu(int zatvorskaJedinicaId)
        {
            var result = DTOManager.VratiFirmeZaZatvorskuJedinicu(zatvorskaJedinicaId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpGet("VratiSveFirmeZaSaradnju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        public ActionResult<List<FirmaPregled>> VratiSveFirmeZaSaradnju(int zatvorskaJedinicaId)
        {
            var result = DTOManager.VratiSveFirmeZaSaradnju(zatvorskaJedinicaId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpPost("DodajFirmu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<bool>> DodajFirmu([FromBody] FirmaBasic firmaBasic)
        {
            var result = await DTOManager.DodajFirmu(firmaBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("IzmeniFirmu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> IzmeniFirmu([FromBody] FirmaBasic firmaBasic)
        {
            var result = DTOManager.IzmeniFirmu(firmaBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpDelete("ObrisiFirmu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<bool> ObrisiFirmu([FromBody] int pib)
        {
            var result = DTOManager.ObrisiFirmu(pib);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpGet("VratiFirmu/{pib}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<FirmaBasic?> VratiFirmu(int pib)
        {
            var result = DTOManager.VratiFirmu(pib);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }





        [HttpPost("ZaposliZatvorenika")]
        public ActionResult<bool> ZaposliZatvorenika(int zatvorenikId, int firmaPIB)
        {
            var result = DTOManager.ZaposliZatvorenika(zatvorenikId, firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpPost("DajOtkazZatvoreniku")]
        public ActionResult<bool> DajOtkazZatvoreniku(int zatvorenikId)
        {
            var result = DTOManager.DajOtkazZatvoreniku(zatvorenikId);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok("Zatvoreniku je uspešno dat otkaz.");
        }



        [HttpPost("ZapocniSaradnju")]
        public ActionResult<bool> ZapocniSaradnju([FromQuery] int zatvorskaJedinicaId, [FromQuery] int firmaPIB)
        {
            var result = DTOManager.ZapocniSaradnju(zatvorskaJedinicaId, firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok("Saradnja je uspešno započeta.");
        }




        [HttpPost("OtkaziSaradnju")]
        public ActionResult<bool> OtkaziSaradnju([FromQuery] int zatvorskaJedinicaId, [FromQuery] int firmaPIB)
        {
            var result = DTOManager.OtkaziSaradnju(zatvorskaJedinicaId, firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok("Saradnja je uspešno otkazana.");
        }










    }
}
