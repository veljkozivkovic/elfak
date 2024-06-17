namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class PrestupiController : ControllerBase
{

    [HttpGet("VratiSvePrestupe")]
    [ProducesResponseType(typeof(List<PrestupPregled>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<PrestupPregled>> VratiSvePrestupe()
    {
        var result = DataProvider.VratiSvePrestupe();

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajPrestup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<bool>> DodajPrestup([FromBody] PrestupBasic prestupBasic)
    {
        var result = await DataProvider.DodajPrestupAsync(prestupBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniPrestup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> IzmeniPrestup([FromBody] PrestupBasic prestupBasic)
    {
        var result = DataProvider.IzmeniPrestup(prestupBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiPrestup/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiPrestup(int id)
    {
        var result = DataProvider.ObrisiPrestup(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiPrestup/{id}")]
    [ProducesResponseType(typeof(PrestupBasic), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<PrestupBasic> VratiPrestup(int id)
    {
        var result = DataProvider.VratiPrestup(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
