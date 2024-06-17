namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class ZatvorskeJediniceController : ControllerBase
{

    [HttpGet("VratiSveZatvore")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult VratiSveZatvore()
    {
        var result = DataProvider.VratiSveZatvore();

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
        var result = DataProvider.VratiZatvoreZaFirmu(firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajZatvorskuJedinicu/{tip}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DodajZatvorskuJedinicu(string tip, [FromBody] ZatvorskaJedinicaPregled zatvorskaJedinica)
    {
        var result = DataProvider.DodajZatvorskuJedinicu(tip, zatvorskaJedinica);

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
        var result = await DataProvider.ObrisiZatvor(id);

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
        var result = await DataProvider.IzmeniZatvorskuJedinicu(zatvorskaJedinica);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiZatvorskuJedinicu/{id}/{tip}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult VratiZatvorskuJedinicu(int id, string tip)
    {
        var result = DataProvider.VratiZatvorskuJedinicu(id, tip);

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
        var result = DataProvider.VratiMoguceUpravnike(zatvorskaJedinicaId);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodeliUpravnika/{zaposleniJMBG}/{zatvorskaJedinicaId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DodeliUpravnika(string zaposleniJMBG, int zatvorskaJedinicaId)
    {
        var result = DataProvider.DodeliUpravnika(zaposleniJMBG, zatvorskaJedinicaId);

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
        var result = DataProvider.VratiUpravnika(zatvorskaJedinicaId);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
