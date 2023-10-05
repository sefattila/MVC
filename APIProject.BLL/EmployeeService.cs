using APIProject.Entities;
using APIProject.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.BLL
{
    public class EmployeeService
    {
        private readonly EmployeeRepo _repo;

        public EmployeeService(EmployeeRepo repo)
        {
            _repo = repo;
        }

        public void Create(Employee employee)
        {
            _repo.Create(employee);
        }

        public void Update(Employee employee)
        {
            _repo.Update(employee);
        }

        public void Delete(Employee employee)
        {
            _repo.Delete(employee);
        }

        public IList<Employee> GetAll()
        {
            return _repo.GetAll();
        }

        public Employee GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
