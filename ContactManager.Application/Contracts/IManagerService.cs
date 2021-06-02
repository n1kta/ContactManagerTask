using System.Collections.Generic;
using ContactManager.MSSQL.Models;

namespace ContactManager.Application.Contracts
{
    public interface IManagerService
    {
        IEnumerable<Manager> GetManagers();

        Manager GetManagerById(int entityId);

        void CreateManager(IEnumerable<Manager> managers);

        void DeleteManager(int entityId);

        void UpdateManager(Manager manager);
    }
}
