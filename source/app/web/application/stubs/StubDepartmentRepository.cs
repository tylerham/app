using System.Collections.Generic;
using System.Linq;

namespace app.web.application.stubs
{
  public class StubDepartmentRepository : IDepartmentRepository
  {
    public IEnumerable<Department> get_the_main_departments()
    {
      return Enumerable.Range(1, 1000).Select(x => new Department{name = x.ToString("Department 0")});
    }
  }
}