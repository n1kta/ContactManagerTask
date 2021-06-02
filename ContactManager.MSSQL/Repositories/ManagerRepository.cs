using System;
using System.Collections.Generic;
using System.Linq;
using ContactManager.MSSQL.Context;
using ContactManager.MSSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.MSSQL.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _context;

        public ManagerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateManager(IEnumerable<Manager> entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException();
                _context.AddRange(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public void DeleteManager(Manager entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException();
                _context.Remove(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public void UpdateManager(Manager entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException();

                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        IEnumerable<Manager> IManagerRepository.GetManagers()
        {
            return _context.Set<Manager>().ToList();
        }

        public Manager GetManagerById(int entityId)
        {
            return _context.Set<Manager>().FirstOrDefault(x => x.Id == entityId);
        }
    }
}
