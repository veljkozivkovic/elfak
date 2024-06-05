using Microsoft.AspNetCore.Mvc;
using Zatvor;

namespace WebAPIZatvor.Controllers
{
    public class IzvrseniPrestupiController : Controller
    {
        [HttpGet("VratiIzvrsenePrestupe")]
        [ProducesResponseType(typeof(List<IzvrsenPrestupPregled>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<List<IzvrsenPrestupPregled>> VratiIzvrsenePrestupe(int zatvorenikID)
        {
            var result = DTOManager.VratiIzvrsenePrestupe(zatvorenikID);

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
            var result = await DTOManager.DodajIzvrsenPrestupAsync(prestupBasic);

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
            if (prestupBasic == null || prestupBasic.Id <= 0)
            {
                return BadRequest("Invalid input data.");
            }

            var result = DTOManager.IzmeniIzvrsenPrestup(prestupBasic);

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
            if (id <= 0)
            {
                return BadRequest("Invalid prestup ID.");
            }

            var result = DTOManager.ObrisiIzvrsenPrestup(id);

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
            if (id <= 0)
            {
                return BadRequest("Invalid prestup ID.");
            }

            var result = DTOManager.VratiIzvrsenPrestup(id);

            if (result.IsError)
            {
                return StatusCode(result.Error.StatusCode, result.Error.Message);
            }

            return Ok(result.Data);
        }
















    }
}
