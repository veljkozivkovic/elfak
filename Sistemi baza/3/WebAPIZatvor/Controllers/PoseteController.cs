using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class PoseteController : Controller
    {
        [HttpGet("VratiPoseteZaZatvorenika")]
        public ActionResult<List<PosetaPregled>> VratiPoseteZaZatvorenika(int zatvorenikID)
        {
            var result = DTOManager.VratiPoseteZaZatvorenika(zatvorenikID);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpGet("VratiPoseteZaAdvokata")]
        public ActionResult<List<PosetaPregled>> VratiPoseteZaAdvokata(string advokatJMBG)
        {
            var result = DTOManager.VratiPoseteZaAdvokata(advokatJMBG);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost("DodajPosetu")]
        public async Task<ActionResult<bool>> DodajPosetu([FromBody] PosetaBasic posetaBasic)
        {
            var result = await DTOManager.DodajPosetu(posetaBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpPut("IzmeniPosetu")]
        public ActionResult<bool> IzmeniPosetu([FromBody] PosetaBasic posetaBasic)
        {
            var result = DTOManager.IzmeniPosetu(posetaBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpDelete("ObrisiPosetu/{id}")]
        public ActionResult<bool> ObrisiPosetu(int id)
        {
            var result = DTOManager.ObrisiPosetu(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet("VratiPosetu/{id}")]
        public ActionResult<PosetaBasic> VratiPosetu(int id)
        {
            var result = DTOManager.VratiPosetu(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpGet("VratiSvePosete")]
        public ActionResult<List<PosetaPregled>> VratiSvePosete()
        {
            var result = DTOManager.VratiSvePosete();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }









    }
}
