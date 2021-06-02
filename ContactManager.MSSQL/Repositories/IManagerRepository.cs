using System.Collections.Generic;
using ContactManager.MSSQL.Models;

namespace ContactManager.MSSQL.Repositories
{
    public interface IManagerRepository
    {
        void CreateManager(IEnumerable<Manager> entity);

        void DeleteManager(Manager entity);

        void UpdateManager(Manager entity);

        void Save();

        IEnumerable<Manager> GetManagers();

        Manager GetManagerById(int entityId);
    }
}
