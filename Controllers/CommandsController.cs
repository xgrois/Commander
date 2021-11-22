using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommandsController : ControllerBase
    {
        public string SGuid { get; } = "CommandsController instance: " + System.Guid.NewGuid().ToString();


        private readonly ICommanderRepository _commanderRepository;
        private readonly IMapper _mapper;

        //private readonly CommanderRepository _commanderRepository = new CommanderRepository();

        public CommandsController(ICommanderRepository commanderRepository, IMapper mapper)
        {
            _commanderRepository = commanderRepository;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            System.Console.WriteLine("{0}, {1}", SGuid, _commanderRepository.SGuid);
            var commands = _commanderRepository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            System.Console.WriteLine("{0}, {1}", SGuid, _commanderRepository.SGuid);
            var command = _commanderRepository.GetCommandById(id);

            if (command is null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDTO>(command));
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            System.Console.WriteLine("{0}, {1}", SGuid, _commanderRepository.SGuid);
            var command = _mapper.Map<Command>(commandCreateDTO);

            _commanderRepository.CreateCommand(command);
            _commanderRepository.SaveChanges();

            var commandReadDTO = _mapper.Map<CommandReadDTO>(command);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDTO.Id }, commandReadDTO);

        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO commandUpdateDTO)
        {
            var command = _commanderRepository.GetCommandById(id);

            if (command is null)
                return NotFound(); // 404

            _mapper.Map(commandUpdateDTO, command); // This also changes db context!!

            _commanderRepository.UpdateCommand(command); // Dummy, just good practice if repo implementation changes

            _commanderRepository.SaveChanges();

            return NoContent();

        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> jsonPatchDocument)
        {
            var command = _commanderRepository.GetCommandById(id);

            if (command is null)
                return NotFound(); // 404

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(command);

            jsonPatchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(commandToPatch, command);

            _commanderRepository.UpdateCommand(command); // Dummy, just good practice if repo implementation changes

            _commanderRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _commanderRepository.GetCommandById(id);

            if (command is null)
                return NotFound(); // 404

            _commanderRepository.DeleteCommand(command);
            _commanderRepository.SaveChanges();

            return NoContent();
        }

    }
}