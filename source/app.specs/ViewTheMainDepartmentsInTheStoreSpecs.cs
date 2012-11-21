using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.web;
using app.web.application;
using app.web.application.catalogbrowsing;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof (ViewTheMainDepartmentsInTheStore))]
    public class ViewTheMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ISupportAUserFeature,
                                            ViewTheMainDepartmentsInTheStore>
        {
        }

        public class when_run : concern
        {
            private Establish c = () =>
                {
                    request = fake.an<IContainRequestDetails>();
                    department_repository = depends.on<IDepartmentRepository>();
                    department_repository.setup(x => x.get_the_main_departments()).Return(mainDepartments);

                    departments_view = depends.on<IDisplayStoreDepartments>();
                };

            private Because b = () =>
                                sut.run(request);

            private It should_get_the_list_of_departments = () =>
                                                            department_repository.received(
                                                                x => x.get_the_main_departments());

            private It should_display_departments =
                () => departments_view.received(x => x.display_departments(mainDepartments));

            private static IContainRequestDetails request;
            private static IDepartmentRepository department_repository;
            private static IDisplayStoreDepartments departments_view;

            static List<Department> mainDepartments = new List<Department>
                {
                    new Department()
                };
        }
    }
}