namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class PoseteController : ControllerBase
{

    [HttpGet("VratiPoseteZaZatvorenika/{zatvorenikID}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<PosetaPregled>> VratiPoseteZaZatvorenika(int zatvorenikID)
    {
        var result = DataProvider.VratiPoseteZaZatvorenika(zatvorenikID);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiPoseteZaAdvokata/{advokatJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<PosetaPregled>> VratiPoseteZaAdvokata(string advokatJMBG)
    {
        var result = DataProvider.VratiPoseteZaAdvokata(advokatJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajPosetu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DodajPosetu([FromBody] PosetaBasic posetaBasic)
    {
        var result = await DataProvider.DodajPosetu(posetaBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniPosetu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> IzmeniPosetu([FromBody] PosetaBasic posetaBasic)
    {
        var result = DataProvider.IzmeniPosetu(posetaBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiPosetu/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiPosetu(int id)
    {
        var result = DataProvider.ObrisiPosetu(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiPosetu/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<PosetaBasic> VratiPosetu(int id)
    {
        var result = DataProvider.VratiPosetu(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiSvePosete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<PosetaPregled>> VratiSvePosete()
    {
        var result = DataProvider.VratiSvePosete();

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
