using Microsoft.AspNetCore.Mvc;
using Sureña_api.Modelos.Repositorio;
using Sureña_api.Modelos;

namespace Sureña_api.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoControlador : Controller
    {
        private ICargo _cargo;
        public CargoControlador(ICargo cargo)
        {
            _cargo= cargo;
        }

        [HttpGet]
        [ActionName(nameof(GetCargoAsync))]
        public IEnumerable<Cargo> GetCargoAsync()
        {
            return _cargo.GetCargo();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetCargoById))]
        public ActionResult<Cargo> GetCargoById(int id)
        {
            var cargoByID = _cargo.GetCargoById(id);
            if (cargoByID == null)
            {
                return NotFound();
            }
            return cargoByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateCargoAsync))]
        public async Task<ActionResult<Cargo>> CreateCargoAsync(Cargo cargo)
        {
            await _cargo.CreateCargoAsync(cargo);
            return CreatedAtAction(nameof(GetCargoById), new { id = cargo.Id }, cargo);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateCargo))]
        public async Task<ActionResult> UpdateCargo(int id, Cargo cargo)
        {
            if (id != cargo.Id)
            {
                return BadRequest();
            }

            await _cargo.UpdateCargoAsync(cargo);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteCargo))]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var cargo = _cargo.GetCargoById(id);
            if (cargo == null)
            {
                return NotFound();
            }

            await _cargo.DeleteCargoAsync(cargo);

            return NoContent();
        }
    }
}
