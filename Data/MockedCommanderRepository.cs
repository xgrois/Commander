using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockedCommanderRepository : ICommanderRepository
    {
        public string SGuid { get; } = "MockedCommanderRepository instance: " + System.Guid.NewGuid().ToString();

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command>()
            {
                new Command
            {
                Id = 0,
                HowTo = "Dummy HowTo",
                Line = "Dummy Line",
                Platform = "Dummy Platform"
            },
                            new Command
            {
                Id = 1,
                HowTo = "Dummy HowTo 1",
                Line = "Dummy Line 1",
                Platform = "Dummy Platform 1"
            },
                            new Command
            {
                Id = 2,
                HowTo = "Dummy HowTo 2",
                Line = "Dummy Line 2",
                Platform = "Dummy Platform 2"
            }
            };
        }

        public Command GetCommandById(int id)
        {
            return new Command
            {
                Id = 0,
                HowTo = "Dummy HowTo",
                Line = "Dummy Line",
                Platform = "Dummy Platform"
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}