namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class LekarskiPreglediController : ControllerBase
{

    [HttpGet("VratiLekarskePreglede/{zaposleniJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<LekarskiPregledPregled>> VratiLekarskePreglede(string zaposleniJMBG)
    {
        var result = DataProvider.VratiLekarskePreglede(zaposleniJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajLekarskiPregled/{zaposleniJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<bool>> DodajLekarskiPregledAsync([FromBody] LekarskiPregledBasic lekarskiPregled, string zaposleniJMBG)
    {
        var result = await DataProvider.DodajLekarskiPregledAsync(lekarskiPregled, zaposleniJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniLekarskiPregled")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> IzmeniLekarskiPregled([FromBody] LekarskiPregledBasic lekarskiPregled)
    {
        var result = DataProvider.IzmeniLekarskiPregled(lekarskiPregled);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiLekarskiPregled/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiLekarskiPregled(int id)
    {
        var result = DataProvider.ObrisiLekarskiPregled(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiLekarskiPregled/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<LekarskiPregledBasic> VratiLekarskiPregled(int id)
    {
        var result = DataProvider.VratiLekarskiPregled(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiSveLekarskePreglede")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<LekarskiPregledBasic>> VratiSveLekarskePreglede()
    {
        var result = DataProvider.VratiSveLekarskePreglede();

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
