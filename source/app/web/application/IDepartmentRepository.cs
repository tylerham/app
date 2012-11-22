using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.application
{
  public interface IDepartmentRepository
  {
    IEnumerable<Department> get_the_main_departments();
    IEnumerable<Department> get_the_departments_using(ViewDepartmentRequest request);
      IEnumerable<Product> get_the_products_using(ViewDepartmentRequest inputModel);
  }
}