using System;
using System.Collections.Generic;
using System.Linq;
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
    public class LogController : ControllerBase
    {
        #region construtores
        /// <summary>
        /// Initializes a new instance of the <see cref="AnexoController"/> class.
        /// </summary>
        /// <param name="logService">The logService<see cref="ILogService"/>.</param>
        /// <param name="machineService">The machineService<see cref="IMachineService"/>.</param>
        /// <param name="uof">The uof<see cref="IUnitOfWork"/>.</param>
        public LogController(
            ILogService logService, 
            IMachineService machineService, 
            IUnitOfWork uof)
        {
            _logService = logService;
            _machineService = machineService;
            _uof = uof;
        }

        #endregion

        #region locais
        /// <summary>
        /// Defines the _logService.
        /// </summary>
        private readonly ILogService _logService;

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

        #endregion

        #region métodos públicos

        /// <summary>
        /// The GetLog.
        /// </summary>
        /// <returns>The <see cref="IEnumerable<>"/>.</returns>
        [HttpGet]
        public IEnumerable<LogViewModel> GetLog()
        {
            return _logService.GetAll();
        }

        /// <summary>
        /// The GetLogs.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="IEnumerable<>"/>.</returns>
        [HttpGet("{id}")]
        public IEnumerable<LogViewModel> GetLogs([FromRoute] Guid id)
        {
            var logs = _logService.GetAll();
            var log = logs.Where(a => a.Machine.Id == id).ToList();

            return log;
        }
        
        /// <summary>
        /// The PostLog.
        /// </summary>
        /// <param name="log">The log<see cref="LogViewModel"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost]
        public async Task<IActionResult> PostLog([FromBody] LogViewModel log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logService.Add(log);
            _uof.Commit();

            return Ok(log);
        }

        //TODO: FUNÇÃO PARA COMANDOS DO CMD

        #endregion
    }
}