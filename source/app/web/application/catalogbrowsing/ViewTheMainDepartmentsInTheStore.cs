namespace app.web.application.catalogbrowsing
{
	public class ViewTheMainDepartmentsInTheStore : ISupportAUserFeature
	{
	  IDepartmentRepository department_repository;

	  public ViewTheMainDepartmentsInTheStore(IDepartmentRepository department_repository)
	  {
	    this.department_repository = department_repository;
	  }

	  public void run(IContainRequestDetails request)
		{
		  department_repository.get_the_main_departments();
		}
	}
}