using day8solid.Models;

namespace day8solid.Reposiotries
{
    public class EmployeeReposiotry : IemployeeReposiotry
    {
        firmDBcontext DB;
        public EmployeeReposiotry()
        {
            this.DB = DB;
        }
        public int Add(employee emp)
        {
            DB.Add(emp);
            return DB.SaveChanges();
        }

        public int Delete(int id)
        {
            employee emp = DB.employees.Where(x=>x.SSN== id).FirstOrDefault();
            DB.employees.Remove(emp);
            return DB.SaveChanges();
        }

        public int Edit(employee emp)
        {
            employee oldEmp = DB.employees.Where(x=>x.SSN== emp.SSN).SingleOrDefault();
            oldEmp.SSN= emp.SSN;
            oldEmp.Fname = emp.Fname;
            oldEmp.Bdate = emp.Bdate;
            oldEmp.Lname = emp.Lname;
            oldEmp.salary = emp.salary;
            oldEmp.superid = emp.superid;
            oldEmp.workOns = emp.workOns;
            oldEmp.address = emp.address;
            oldEmp.Mname = emp.Mname;
            return DB.SaveChanges();
        }

        public List<employee> getAll()
        {
            return DB.employees.ToList();
        }

        public employee getById(int id)
        {
            return DB.employees.Where(x=>x.SSN==id).SingleOrDefault();
        }
    }
}
