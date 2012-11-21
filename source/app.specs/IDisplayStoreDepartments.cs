using System.Collections.Generic;

namespace app.web.application
{
    public interface IDisplayStoreDepartments
    {
        void display_departments(IEnumerable<Department> departments);
    }
}