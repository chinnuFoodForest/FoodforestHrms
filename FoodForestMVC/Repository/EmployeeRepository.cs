
using FoodForestMVC.Contacts;
using FoodForestMVC.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FoodForestMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Employee entity)
        {
            _db.Employees.Add(entity);
            return Save();
        }

        public bool Delete(Employee entity)
        {
            _db.Employees.Remove(entity);
            return Save();
        }

        public ICollection<Employee> FindAll()
        {
            return _db.Employees.ToList();
        }

        public Employee FindById(int id)
        {
            var employee = _db.Employees.Find(id);
            return employee;
        }

        public bool isExists(int id)
        {
            var exists = _db.Employees.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(Employee entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return Save();
        }
    }
}
