using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.core;

namespace app.specs
{
    public class ViewProductsInADepartment : ISupportAUserFeature
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDisplayInformation _productView;

        public ViewProductsInADepartment(IDepartmentRepository departmentRepository, IDisplayInformation productView)
        {
            _departmentRepository = departmentRepository;
            _productView = productView;
        }

        public void run(IContainRequestDetails request)
        {
            _productView.display(_departmentRepository.get_the_products_using(request.map<ViewDepartmentRequest>()));
        }
    }
}