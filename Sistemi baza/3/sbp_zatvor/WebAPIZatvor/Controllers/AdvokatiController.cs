namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class AdvokatiController : ControllerBase
{
    [HttpGet("VratiSveAdvokate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<AdvokatPregled>> VratiSveAdvokate()
    {
        var result = DataProvider.VratiSveAdvokate();

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiAdvokata/{jmbg}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<AdvokatBasic> VratiAdvokata(string jmbg)
    {
        var result = DataProvider.VratiAdvokata(jmbg);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajAdvokata")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<bool>> DodajAdvokata([FromBody] AdvokatBasic advokatBasic)
    {
        var result = await DataProvider.DodajAdvokataAsync(advokatBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniAdvokata")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> IzmeniAdvokata([FromBody] AdvokatBasic advokatBasic)
    {
        var result = DataProvider.IzmeniAdvokata(advokatBasic);

        if (result.IsError)
        {
            if (result.Error.StatusCode == 404)
            {
                return NotFound(result.Error.Message);
            }
            else
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiAdvokata/{advokatJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> ObrisiAdvokata(string advokatJMBG)
    {
        var result = DataProvider.ObrisiAdvokata(advokatJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajZastupanje/{zatvorenikId}/{advokatJMBG}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> DodajZastupanje(int zatvorenikId, string advokatJMBG)
    {
        var result = DataProvider.DodajZastupanje(zatvorenikId, advokatJMBG);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("OtkaziZastupanje/{zatvorenikId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<bool> OtkaziZastupanje(int zatvorenikId)
    {
        var result = DataProvider.OtkaziZastupanje(zatvorenikId);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
