namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class OdgovornaLicaController : ControllerBase
{

    [HttpGet("VratiOdgovornaLicaZaFirmu/{firmaPIB}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<OdgovornoLicePregled>> VratiOdgovornaLicaZaFirmu(int firmaPIB)
    {
        var result = DataProvider.VratiOdgovornaLicaZaFirmu(firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiOdgovornoLice/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<OdgovornoLiceBasic?> VratiOdgovornoLice(int id)
    {
        var result = DataProvider.VratiOdgovornoLice(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajOdgovornoLice/{firmaPIB}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DodajOdgovornoLiceAsync([FromBody] OdgovornoLiceBasic odgovornoLiceBasic, int firmaPIB)
    {
        var result = await DataProvider.DodajOdgovornoLiceAsync(odgovornoLiceBasic, firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniOdgovornoLice")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> IzmeniOdgovornoLice([FromBody] OdgovornoLiceBasic odgovornoLiceBasic)
    {
        var result = DataProvider.IzmeniOdgovornoLice(odgovornoLiceBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiOdgovornoLice/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiOdgovornoLice(int id)
    {
        var result = DataProvider.ObrisiOdgovornoLice(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiSvaOdgovornaLica")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<OdgovornoLiceBasic>> VratiSvaOdgovornaLica()
    {
        var result = DataProvider.VratiSvaOdgovornaLica();

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
