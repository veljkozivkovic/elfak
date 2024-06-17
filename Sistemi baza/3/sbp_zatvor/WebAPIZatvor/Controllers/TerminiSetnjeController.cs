namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class TerminiSetnjeController : ControllerBase
{

    [HttpGet("VratiTermineSetnje/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<TerminSetnjePregled>> VratiTermineSetnje(int id)
    {
        var result = DataProvider.VratiTermineSetnje(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }
    
    [HttpPost("DodajTerminSetnje/{idZatvorskeJedinice}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> DodajTerminSetnje([FromBody] TerminSetnjeBasic terminSetnjeBasic, int idZatvorskeJedinice)
    {
        var result = await DataProvider.DodajTerminSetnjeAsync(terminSetnjeBasic, idZatvorskeJedinice);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniTerminSetnje")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult IzmeniTerminSetnje([FromBody] TerminSetnjeBasic terminSetnjeBasic)
    {
        var result = DataProvider.IzmeniTerminSetnje(terminSetnjeBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiTerminSetnje/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<TerminSetnjeBasic> VratiTerminSetnje(int id)
    {
        var result = DataProvider.VratiTerminSetnje(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiTerminSetnje/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> ObrisiTerminSetnje(int id)
    {
        var result = await DataProvider.ObrisiTerminSetnjeAsync(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
