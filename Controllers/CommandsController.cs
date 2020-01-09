using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Command.Models;


namespace Command.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly CommandContext _commandContext;

        public CommandsController(CommandContext commandContext) => _commandContext = commandContext;

        //GET:         api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command.Models.Command>> GetCommands()
        {
            return _commandContext.Commands;
        }

        //GET:          api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command.Models.Command> GetCommandsById(int id)
        {
            return _commandContext.Commands.Find(id);
        }

        //POST          api/commands
        [HttpPost]
        public ActionResult<Command.Models.Command> AddCommand(Command.Models.Command command)
        {
            _commandContext.Commands.Add(command);
            _commandContext.SaveChanges();

            return CreatedAtAction("GetCommandsById", new Command.Models.Command { Id = command.Id }, command);
        }

        //PUT           api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult<Command.Models.Command> UpdateCommand(int id, Command.Models.Command command)
        {
            _commandContext.Entry(command).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _commandContext.SaveChanges();
            return NoContent();
        }

        //DELETE        api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult<Command.Models.Command> DeleteCommand(int id)
        {
            var command = _commandContext.Commands.Find(id);
            _commandContext.Commands.Remove(command);
            _commandContext.SaveChanges();
            return NoContent();
        }

    }
}