using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RemoteController.Application.Interfaces;
using RemoteController.Application.ViewModels;
using RemoteController.Domain.Interfaces;

namespace RemoteController.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        #region construtores
        /// <summary>
        /// Initializes a new instance of the <see cref="AnexoController"/> class.
        /// </summary>
        /// <param name="machineService">The machineService<see cref="IMachineService"/>.</param>
        /// <param name="uof">The uof<see cref="IUnitOfWork"/>.</param>
        public MachinesController(
            IMachineService machineService, 
            IUnitOfWork uof)
        {
            _machineService = machineService;
            _uof = uof;
        }
        #endregion

        #region locais
        /// <summary>
        /// Defines the _machineService.
        /// </summary>
        private readonly IMachineService _machineService;

        /// <summary>
        /// Defines the _uof.
        /// </summary>
        private readonly IUnitOfWork _uof;

        #endregion

        #region métodos privados
        /// <summary>
        /// The MachineExists.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool MachineExists(Guid id)
        {
            return _machineService.Any(e => e.Id == id);
        }
        #endregion

        #region métodos públicos
        /// <summary>
        /// The GetMachines.
        /// </summary>
        /// <returns>The <see cref="IEnumerable<MachineViewModel>"/>.</returns>
        [HttpGet]
        public IEnumerable<MachineViewModel> GetMachines()
        {
            return _machineService.GetAll();
        }

        /// <summary>
        /// The GetMachine.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachine([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machine = await _machineService.GetByIdAsync(id);

            if (machine == null)
            {
                return NotFound();
            }

            return Ok(machine);
        }

        /// <summary>
        /// The PutMachine.
        /// </summary>
        /// <param name="machine">The machine<see cref="MachineViewModel"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public IActionResult PutMachine([FromRoute] Guid id, [FromBody] MachineViewModel machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machine.Id)
            {
                return BadRequest();
            }

            try
            {
                _machineService.Update(machine);
                _uof.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// The PostMachine.
        /// </summary>
        /// <param name="machine">The machine<see cref="MachineViewModel"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost]
        public async Task<IActionResult> PostMachine([FromBody] MachineViewModel machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _machineService.Add(machine);
            _uof.Commit();

            return Ok(machine);
        }

        /// <summary>
        /// The DeleteMachine.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machine = await _machineService.GetByIdAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            _machineService.Remove(id);
            _uof.Commit();

            return Ok(machine);
        }
        #endregion
    }
}