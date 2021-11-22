using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepository
    {
        bool SaveChanges();
        public string SGuid { get; } // Just to check instance creation
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);

        void UpdateCommand(Command command);

        void DeleteCommand(Command command);

    }
}