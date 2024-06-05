using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class ZaposleniController : Controller
    {

        [HttpGet("VratiZaposleneZaZatvorskuJedinicu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<List<ZaposleniPregled>> VratiZaposleneZaZatvorskuJedinicu([FromQuery] int idZatvorskeJedinice)
        {
            var result = DTOManager.VratiZaposleneZaZatvorskuJedinicu(idZatvorskeJedinice);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpPost("DodajZaposlenog")]
        public async Task<ActionResult<bool>> DodajZaposlenogAsyncAPI(string tipZaposlenog, [FromBody] ZaposleniBasic zaposleniBasic)
        {
            var result = await DTOManager.DodajZaposlenogAsyncAPI(tipZaposlenog, zaposleniBasic);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }




        [HttpGet("VratiSveZaposlene")]
        public ActionResult<List<ZaposleniPregled>> VratiSveZaposlene()
        {
            var result = DTOManager.VratiSveZaposlene();

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpGet("VratiZaposlenog")]
        public ActionResult<ZaposleniBasic> VratiZaposlenogAPI(string id)
        {
            var result = DTOManager.VratiZaposlenogAPI(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            if (result.Data == null)
            {
                return NotFound("Zaposleni nije pronađen.");
            }

            return Ok(result.Data);
        }





        [HttpGet("VratiZaposlenjaZaZaposlenog")]
        public ActionResult<List<RadiUPregled>> VratiZaposlenjaZaZaposlenog([FromQuery] string zaposleniJMBG)
        {
            var result = DTOManager.VratiZaposlenjaZaZaposlenog(zaposleniJMBG);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }






        [HttpPost("ZaposliRadnika")]
        public ActionResult<bool> ZaposliRadnika([FromQuery] string idZaposlenog, [FromBody] RadiUBasic radiU)
        {
            var result = DTOManager.ZaposliRadnika(idZaposlenog, radiU);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }


        [HttpPut("IzmeniRadnoMesto")]
        public async Task<ActionResult<bool>> IzmeniRadnoMesto([FromBody] IzmeniRadnoMestoDTO model)
        {
            var result = await DTOManager.IzmeniRadnoMesto(model.ZaposleniJMBG, model.ZatvorskaJedinicaId, model.StaroRadnoMesto, model.RadnoMestoNaziv, model.DatumZaposlenja);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }







        [HttpDelete("ObrisiRadnoMesto")]
        public ActionResult<bool> ObrisiRadnoMesto([FromBody] ObrisiRadnoMestoDTO model)
        {
            var result = DTOManager.ObrisiRadnoMesto(model.ZaposleniJMBG, model.ZatvorskaJedinicaId, model.RadnoMestoNaziv);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }





        [HttpPut("IzmeniZaposlenog")]
        public  ActionResult<bool> IzmeniZaposlenog([FromBody] ZaposleniIzmenaDTO zaposleniIzmenaDTO)
        {
            var zaposleniPregled = new ZaposleniPregled
            {
                JMBG = zaposleniIzmenaDTO.JMBG,
                Ime = zaposleniIzmenaDTO.Ime,
                Prezime = zaposleniIzmenaDTO.Prezime,
                DatumObuke = zaposleniIzmenaDTO.DatumObuke,
                TipZaposlenog = zaposleniIzmenaDTO.TipZaposlenog,
                Zanimanje = zaposleniIzmenaDTO.Zanimanje,
                StrucnaSprema = zaposleniIzmenaDTO.StrucnaSprema
            };

            var result =  DTOManager.IzmeniZaposlenog(zaposleniPregled);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }



        [HttpDelete("ObrisiZaposlenog/{id}")]
        public ActionResult<bool> ObrisiZaposlenog(string id)
        {
            var result = DTOManager.ObrisiZaposlenog(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }










    }
}
