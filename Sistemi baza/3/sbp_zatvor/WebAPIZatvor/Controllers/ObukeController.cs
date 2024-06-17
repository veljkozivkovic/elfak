namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class ObukeController : ControllerBase
{

    [HttpGet("VratiObuke/{zaposleniJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<ObukaVatrenoOruzjePregled>> VratiObuke(string zaposleniJMBG)
    {
        var result = DataProvider.VratiObuke(zaposleniJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajObuku/{zaposleniJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DodajObuku([FromBody] ObukaVatrenoOruzjeBasic o, string zaposleniJMBG)
    {
        var result = await DataProvider.DodajObuku(o, zaposleniJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniObuku")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> IzmeniObuku([FromBody] ObukaVatrenoOruzjeBasic o)
    {
        var result = DataProvider.IzmeniObuku(o);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiObuku/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiObuku(int id)
    {
        var result = DataProvider.ObrisiObuku(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiObuku/{id}")]
    [ProducesResponseType(typeof(ObukaVatrenoOruzjeBasic), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<ObukaVatrenoOruzjeBasic> VratiObuku(int id)
    {
        var result = DataProvider.VratiObuku(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
