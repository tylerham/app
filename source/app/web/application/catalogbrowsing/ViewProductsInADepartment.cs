using app.web.application.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
	public class ViewProductsInADepartment : ISupportAUserFeature
	{
		readonly IFetchStoreInformation _departmentRepository;
		readonly IDisplayInformation _productView;

		public ViewProductsInADepartment(IFetchStoreInformation departmentRepository, IDisplayInformation productView)
		{
			_departmentRepository = departmentRepository;
			_productView = productView;
		}

		public ViewProductsInADepartment()
			: this(new StubCatalog(),
				new StubDisplayEngine())
		{
		}

		public void run(IContainRequestDetails request)
		{
			_productView.display(_departmentRepository.get_the_products_using(request.map<ViewProductsInDepartmentRequest>()));
		}
	}
}