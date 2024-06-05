using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class OdgovornaLicaController : Controller
    {



        [HttpGet("VratiOdgovornaLicaZaFirmu")]
        public ActionResult<List<OdgovornoLicePregled>> VratiOdgovornaLicaZaFirmu(int firmaPIB)
        {
            var result = DTOManager.VratiOdgovornaLicaZaFirmu(firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiOdgovornoLice")]
        public ActionResult<OdgovornoLiceBasic?> VratiOdgovornoLice(int id)
        {
            var result = DTOManager.VratiOdgovornoLice(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }





        [HttpPost("DodajOdgovornoLice")]
        public async Task<ActionResult<bool>> DodajOdgovornoLiceAsync([FromBody] OdgovornoLiceBasic odgovornoLiceBasic, int firmaPIB)
        {
            var result = await DTOManager.DodajOdgovornoLiceAsync(odgovornoLiceBasic, firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpPut("IzmeniOdgovornoLice")]
        public ActionResult<bool> IzmeniOdgovornoLice([FromBody]OdgovornoLiceBasic odgovornoLiceBasic)
        {
            var result = DTOManager.IzmeniOdgovornoLice(odgovornoLiceBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpDelete("ObrisiOdgovornoLice/{id}")]
        public ActionResult<bool> ObrisiOdgovornoLice(int id)
        {
            var result = DTOManager.ObrisiOdgovornoLice(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiSvaOdgovornaLica")]
        public ActionResult<List<OdgovornoLiceBasic>> VratiSvaOdgovornaLica()
        {
            var result = DTOManager.VratiSvaOdgovornaLica();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }





















    }
}
