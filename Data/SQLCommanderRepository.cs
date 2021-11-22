using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SQLCommanderRepository : ICommanderRepository
    {
        private readonly CommanderContext _ctx;

        public string SGuid { get; } = "MockedCommanderRepository instance: " + System.Guid.NewGuid().ToString();

        public SQLCommanderRepository(CommanderContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _ctx.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _ctx.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_ctx.SaveChanges() > 0);
        }

        public void CreateCommand(Command command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            _ctx.Commands.Add(command);
        }

        public void UpdateCommand(Command command)
        {
            // Nothing ???????????
        }

        public void DeleteCommand(Command command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            _ctx.Commands.Remove(command);

        }
    }
}