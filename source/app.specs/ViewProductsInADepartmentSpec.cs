using System.Collections.Generic;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    using Machine.Specifications;

    [Subject(typeof (ViewProductsInADepartment))]
    public class ViewProductsInADepartmentSpec
    {
        public abstract class concern : Observes<ISupportAUserFeature,
                                            ViewProductsInADepartment>
        {
        }

        public class when_run : concern
        {
            private Establish c = () =>
                {
                    request = fake.an<IContainRequestDetails>();

                    input_model = new ViewDepartmentRequest();
                    department_repository = depends.on<IDepartmentRepository>();
                    request.setup(x => x.map<ViewDepartmentRequest>()).Return(input_model);

                    department_repository.setup(x => x.get_the_products_using(input_model)).Return(products);

                    products_view = depends.on<IDisplayInformation>();
                };

            private Because b = () =>
                                sut.run(request);

            private It should_get_the_list_of_products = () =>
                {
                };

            private It should_display_products =
                () => products_view.received(x => x.display(products));

            private static IContainRequestDetails request;
            private static IDepartmentRepository department_repository;
            private static IDisplayInformation products_view;
            private static IEnumerable<Product> products = new List<Product>();
            private static ViewDepartmentRequest input_model;
        }
    }
}
