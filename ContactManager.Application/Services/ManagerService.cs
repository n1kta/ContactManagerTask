using System;
using System.Collections.Generic;
using ContactManager.Application.Contracts;
using ContactManager.MSSQL.Models;
using ContactManager.MSSQL.Repositories;

namespace ContactManager.Application.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public IEnumerable<Manager> GetManagers()
        {
            var result = _managerRepository.GetManagers();

            return result;
        }

        public Manager GetManagerById(int entityId)
        {
            var result = _managerRepository.GetManagerById(entityId);

            return result;
        }

        public void CreateManager(IEnumerable<Manager> managers)
        {
            try
            {
                _managerRepository.CreateManager(managers);
                _managerRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void DeleteManager(int entityId)
        {
            var manager = GetManagerById(entityId);

            if (manager == null)
                throw new NullReferenceException();

            try
            {
                _managerRepository.DeleteManager(manager);
                _managerRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateManager(Manager manager)
        {
            try
            {
                _managerRepository.UpdateManager(manager);
                _managerRepository.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
