using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class FirmaTelefonController : Controller
    {





        [HttpGet("VratiTelefoneZaFirmu/{firmaPIB}")]
        public ActionResult<List<FirmaTelefonPregled>> VratiTelefoneZaFirmu(int firmaPIB)
        {
            var result = DTOManager.VratiTelefoneZaFirmu(firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiTelefon/{id}")]
        public ActionResult<FirmaTelefonBasic?> VratiTelefon(int id)
        {
            var result = DTOManager.VratiTelefon(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpPost("DodajTelefon")]
        public async Task<ActionResult<bool>> DodajTelefon([FromBody] FirmaTelefonBasic telefonBasic, int firmaPIB)
        {
            var result = await DTOManager.DodajTelefonAsync(telefonBasic, firmaPIB);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpPost("IzmeniTelefon")]
        public ActionResult<bool> IzmeniTelefon([FromBody]FirmaTelefonBasic telefonBasic)
        {
            var result = DTOManager.IzmeniTelefon(telefonBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpPost("ObrisiTelefon")]
        public ActionResult<bool> ObrisiTelefon(int id)
        {
            var result = DTOManager.ObrisiTelefon(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }





        [HttpGet("VratiSveTelefone")]
        public ActionResult<List<FirmaTelefonPregled>> VratiSveTelefone()
        {
            var result = DTOManager.VratiSveTelefone();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }





















    }
}
