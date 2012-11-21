using app.web.application.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
	public class ViewTheDepartmentsInADepartment : ISupportAUserFeature
	{
		IDepartmentRepository department_repository;
		IDisplayInformation display_engine;

		public ViewTheDepartmentsInADepartment(IDepartmentRepository department_repository, IDisplayInformation sub_department_view)
		{
			this.department_repository = department_repository;
			this.display_engine = sub_department_view;
		}

		public ViewTheDepartmentsInADepartment()
			: this(new StubDepartmentRepository(), new StubDisplayEngine())
		{
		}

		public void run(IContainRequestDetails request)
		{
			var mainDepartment = request.get_request_model<Department>();
			var subDepartments = department_repository.get_the_departments_in(mainDepartment);

			display_engine.display(subDepartments);
		}
	}
}