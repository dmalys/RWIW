using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NRules;
using NRules.Fluent;
using RwiwProject.Models;
using RwiwProject.Rules;
using RwiwWebProject.Models;
using System;

namespace RwiwWebProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArchitectureController : ControllerBase
    {
        private readonly ILogger<ArchitectureController> _logger;

        public ArchitectureController(ILogger<ArchitectureController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ArchitectureResponse PostArchitecture([FromBody] ArchRequest request)
        {
            //Load rules
            var repository = new RuleRepository();
            repository.Load(x => x.From(typeof(FirstRule).Assembly));

            //Compile rules
            var factory = repository.Compile();

            //Create a working session
            var session = factory.CreateSession();

            //Load domain model
            var architecture = new Architecture(request.DependencyNumber, request.AcceptableDowntime, request.SyncronicUserNumber, request.PacketNumberPerSession, request.ApplicationComplexity, request.DataTypeUsed);
            
            //Insert facts into rules engine's memory
            session.Insert(architecture);

            //Start match/resolve/act cycle
            session.Fire();

            return new ArchitectureResponse() 
            {
                ArchitectureTypeChosen = architecture.ArchitectureTypeChosen.ToString(),
                ResponseDecision = architecture.ResponseDecision
            };
        }
    }
}
