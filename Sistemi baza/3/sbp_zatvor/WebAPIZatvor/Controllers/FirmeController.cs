namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class FirmeController : ControllerBase
{

    [HttpGet("VratiSveFirme")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<FirmaPregled>> VratiSveFirme()
    {
        var result = DataProvider.VratiSveFirme();

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiFirmuZatvorenika/{zatvorenikId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public ActionResult<FirmaPregled?> VratiFirmuZatvorenika(int zatvorenikId)
    {
        var result = DataProvider.VratiFirmuZatvorenika(zatvorenikId);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiFirmeZaZatvorenika/{zatvorenikId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public ActionResult<List<FirmaPregled>> VratiFirmeZaZatvorenika(int zatvorenikId)
    {
        var result = DataProvider.VratiFirmeZaZatvorenika(zatvorenikId);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiFirmeZaZatvorskuJedinicu/{zatvorskaJedinicaId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public ActionResult<List<FirmaPregled>> VratiFirmeZaZatvorskuJedinicu(int zatvorskaJedinicaId)
    {
        var result = DataProvider.VratiFirmeZaZatvorskuJedinicu(zatvorskaJedinicaId);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiSveFirmeZaSaradnju/{zatvorskaJedinicaId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public ActionResult<List<FirmaPregled>> VratiSveFirmeZaSaradnju(int zatvorskaJedinicaId)
    {
        var result = DataProvider.VratiSveFirmeZaSaradnju(zatvorskaJedinicaId);

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
        var result = await DataProvider.DodajFirmu(firmaBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniFirmu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> IzmeniFirmu([FromBody] FirmaBasic firmaBasic)
    {
        var result = DataProvider.IzmeniFirmu(firmaBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiFirmu/{pib}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiFirmu(int pib)
    {
        var result = DataProvider.ObrisiFirmu(pib);

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
        var result = DataProvider.VratiFirmu(pib);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("ZaposliZatvorenika/{zatvorenikId}/{firmaPIB}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> ZaposliZatvorenika(int zatvorenikId, int firmaPIB)
    {
        var result = DataProvider.ZaposliZatvorenika(zatvorenikId, firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("DajOtkazZatvoreniku/{zatvorenikId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> DajOtkazZatvoreniku(int zatvorenikId)
    {
        var result = DataProvider.DajOtkazZatvoreniku(zatvorenikId);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok("Zatvoreniku je uspešno dat otkaz.");
    }

    [HttpPost("ZapocniSaradnju/{zatvorskaJedinicaId}/{firmaPIB}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> ZapocniSaradnju(int zatvorskaJedinicaId, int firmaPIB)
    {
        var result = DataProvider.ZapocniSaradnju(zatvorskaJedinicaId, firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok("Saradnja je uspešno započeta.");
    }

    [HttpDelete("OtkaziSaradnju/{zatvorskaJedinicaId}/{firmaPIB}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> OtkaziSaradnju(int zatvorskaJedinicaId, int firmaPIB)
    {
        var result = DataProvider.OtkaziSaradnju(zatvorskaJedinicaId, firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok("Saradnja je uspešno otkazana.");
    }

}
