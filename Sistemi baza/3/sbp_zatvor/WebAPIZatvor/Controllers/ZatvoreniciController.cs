namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class ZatvoreniciController : ControllerBase
{

    [HttpGet("VratiZatvorenikeZaZatvorskuJedinicu/{idZatvorskeJedinice}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<ZatvorenikPregled>> VratiZatvorenikeZaZatvorskuJedinicu(int idZatvorskeJedinice)
    {
        var result = DataProvider.VratiZatvorenikeZaZatvorskuJedinicu(idZatvorskeJedinice);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiZatvorenikeZaAdvokata/{advokatJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<ZatvorenikPregled>> VratiZatvorenikeZaAdvokata(string advokatJMBG)
    {
        var result = DataProvider.VratiZatvorenikeZaAdvokata(advokatJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiMoguceZatvorenikeZaAdvokata/{advokatJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<ZatvorenikPregled>> VratiMoguceZatvorenikeZaAdvokata(string advokatJMBG)
    {
        var result = DataProvider.VratiMoguceZatvorenikeZaAdvokata(advokatJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiZatvorenikeZaFirmu/{firmaPIB}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<ZatvorenikPregled>> VratiZatvorenikeZaFirmu(int firmaPIB)
    {
        var result = DataProvider.VratiZatvorenikeZaFirmu(firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiPotencijalneRadnike/{firmaPIB}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<ZatvorenikPregled>> VratiPotencijalneRadnike(int firmaPIB)
    {
        var result = DataProvider.VratiPotencijalneRadnike(firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajZatvorenika/{idZatvorskeJedinice}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<bool>> DodajZatvorenika([FromBody] ZatvorenikBasic zatvorenikBasic, int idZatvorskeJedinice)
    {
        var result = await DataProvider.DodajZatvorenikaAsync(zatvorenikBasic, idZatvorskeJedinice);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniZatvorenika/{idZatvorskeJedinice}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> IzmeniZatvorenika([FromBody] ZatvorenikBasic zatvorenikBasic, int idZatvorskeJedinice)
    {
        var result = DataProvider.IzmeniZatvorenika(zatvorenikBasic, idZatvorskeJedinice);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiZatvorenika/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<ZatvorenikBasic?> VratiZatvorenika(int id)
    {
        var result = DataProvider.VratiZatvorenika(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiZatvorenika/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiZatvorenika(int id)
    {
        var result = DataProvider.ObrisiZatvorenika(id);

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
        var result = DataProvider.VratiSveZatvorenike();

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
