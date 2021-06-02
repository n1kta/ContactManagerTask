using System.Collections.Generic;

namespace ContactManager.Domain.Contracts
{
    public interface IManagerService
    {
        IEnumerable<Manager> GetManagers();
    }
}
