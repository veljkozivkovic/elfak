namespace WebAPIZatvor.Controllers;

[ApiController]
[Route("[controller]")]
public class IzvrseniPrestupiController : ControllerBase
{

    [HttpGet("VratiIzvrsenePrestupe/{zatvorenikID}")]
    [ProducesResponseType(typeof(List<IzvrsenPrestupPregled>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public ActionResult<List<IzvrsenPrestupPregled>> VratiIzvrsenePrestupe(int zatvorenikID)
    {
        var result = DataProvider.VratiIzvrsenePrestupe(zatvorenikID);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPost("DodajIzvrsenPrestup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DodajIzvrsenPrestup([FromBody] IzvrsenPrestupBasic prestupBasic)
    {
        var result = await DataProvider.DodajIzvrsenPrestupAsync(prestupBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpPut("IzmeniIzvrsenPrestup")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> IzmeniIzvrsenPrestup([FromBody] IzvrsenPrestupBasic prestupBasic)
    {
        var result = DataProvider.IzmeniIzvrsenPrestup(prestupBasic);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete("ObrisiIzvrsenPrestup/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> ObrisiIzvrsenPrestup(int id)
    {
        var result = DataProvider.ObrisiIzvrsenPrestup(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

    [HttpGet("VratiIzvrsenPrestup/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IzvrsenPrestupBasic?> VratiIzvrsenPrestup(int id)
    {
        var result = DataProvider.VratiIzvrsenPrestup(id);

        if (result.IsError)
        {
            return StatusCode(result.Error.StatusCode, result.Error.Message);
        }

        return Ok(result.Data);
    }

}
