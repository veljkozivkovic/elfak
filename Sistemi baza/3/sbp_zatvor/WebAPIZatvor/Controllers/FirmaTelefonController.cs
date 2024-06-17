namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class FirmaTelefonController : ControllerBase
{

    [HttpGet("VratiTelefoneZaFirmu/{firmaPIB}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<FirmaTelefonPregled>> VratiTelefoneZaFirmu(int firmaPIB)
    {
        var result = DataProvider.VratiTelefoneZaFirmu(firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiTelefon/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<FirmaTelefonBasic?> VratiTelefon(int id)
    {
        var result = DataProvider.VratiTelefon(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajTelefon/{firmaPIB}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DodajTelefon([FromBody] FirmaTelefonBasic telefonBasic, int firmaPIB)
    {
        var result = await DataProvider.DodajTelefonAsync(telefonBasic, firmaPIB);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniTelefon")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> IzmeniTelefon([FromBody] FirmaTelefonBasic telefonBasic)
    {
        var result = DataProvider.IzmeniTelefon(telefonBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiTelefon/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiTelefon(int id)
    {
        var result = DataProvider.ObrisiTelefon(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiSveTelefone")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<FirmaTelefonPregled>> VratiSveTelefone()
    {
        var result = DataProvider.VratiSveTelefone();

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
