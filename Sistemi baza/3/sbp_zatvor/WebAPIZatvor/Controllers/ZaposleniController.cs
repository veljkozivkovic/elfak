namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class ZaposleniController : ControllerBase
{

    [HttpGet("VratiZaposleneZaZatvorskuJedinicu/{idZatvorskeJedinice}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<ZaposleniPregled>> VratiZaposleneZaZatvorskuJedinicu(int idZatvorskeJedinice)
    {
        var result = DataProvider.VratiZaposleneZaZatvorskuJedinicu(idZatvorskeJedinice);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajZaposlenog/{tipZaposlenog}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DodajZaposlenogAsyncAPI(string tipZaposlenog, [FromBody] ZaposleniBasic zaposleniBasic)
    {
        var result = await DataProvider.DodajZaposlenogAsyncAPI(tipZaposlenog, zaposleniBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiSveZaposlene")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<ZaposleniPregled>> VratiSveZaposlene()
    {
        var result = DataProvider.VratiSveZaposlene();

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiZaposlenog/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<ZaposleniBasic> VratiZaposlenogAPI(string id)
    {
        var result = DataProvider.VratiZaposlenogAPI(id);

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

    [HttpGet("VratiZaposlenjaZaZaposlenog/{zaposleniJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<RadiUPregled>> VratiZaposlenjaZaZaposlenog(string zaposleniJMBG)
    {
        var result = DataProvider.VratiZaposlenjaZaZaposlenog(zaposleniJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("ZaposliRadnika/{idZaposlenog}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ZaposliRadnika(string idZaposlenog, [FromBody] RadiUBasic radiU)
    {
        var result = DataProvider.ZaposliRadnika(idZaposlenog, radiU);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniRadnoMesto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> IzmeniRadnoMesto([FromBody] IzmeniRadnoMestoDTO model)
    {
        var result = await DataProvider.IzmeniRadnoMesto(model.ZaposleniJMBG, model.ZatvorskaJedinicaId, model.StaroRadnoMesto, model.RadnoMestoNaziv, model.DatumZaposlenja);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiRadnoMesto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> ObrisiRadnoMesto([FromBody] ObrisiRadnoMestoDTO model)
    {
        var result = DataProvider.ObrisiRadnoMesto(model.ZaposleniJMBG, model.ZatvorskaJedinicaId, model.RadnoMestoNaziv);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniZaposlenog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        var result =  DataProvider.IzmeniZaposlenog(zaposleniPregled);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiZaposlenog/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiZaposlenog(string id)
    {
        var result = DataProvider.ObrisiZaposlenog(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
