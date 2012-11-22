using app.web.application.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
	public class ViewTheMainDepartmentsInTheStore : ISupportAUserFeature
	{
		IFetchStoreInformation department_repository;
		IDisplayInformation display_engine;

		public ViewTheMainDepartmentsInTheStore(IFetchStoreInformation department_repository, IDisplayInformation department_view)
		{
			this.department_repository = department_repository;
			this.display_engine = department_view;
		}

		public ViewTheMainDepartmentsInTheStore()
			: this(new StubCatalog(),
				new StubDisplayEngine())
		{
		}

		public void run(IContainRequestDetails request)
		{
			display_engine.display(department_repository.get_the_main_departments());
		}
	}
}