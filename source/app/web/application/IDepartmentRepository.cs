using System.Collections.Generic;

namespace app.web.application
{
  public interface IDepartmentRepository
  {
    IEnumerable<Department> get_the_main_departments();
  }
}