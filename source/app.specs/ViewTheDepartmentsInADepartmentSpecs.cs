using System.Collections.Generic;
using Machine.Specifications;
using app.web;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
	[Subject(typeof(ViewTheDepartmentsInADepartment))]
	public class ViewTheDepartmentsInADepartmentSpecs
	{
		public abstract class concern : Observes<ISupportAUserFeature,
									 ViewTheDepartmentsInADepartment>
		{
		}

		public class when_run : concern
		{
			Establish c = () =>
			{
				request = fake.an<IContainRequestDetails>();
				
        input_model = new ViewDepartmentRequest();
				department_repository = depends.on<IDepartmentRepository>();
				request.setup(x => x.map<ViewDepartmentRequest>()).Return(input_model);

				department_repository.setup(x => x.get_the_departments_using(input_model)).Return(sub_departments);

				sub_departments_view = depends.on<IDisplayInformation>();
			};

			Because b = () =>
			  sut.run(request);

			It should_get_the_list_of_departments = () =>
			{
			};

			It should_display_departments =
			  () => sub_departments_view.received(x => x.display(sub_departments));

			static IContainRequestDetails request;
			static IDepartmentRepository department_repository;
			static IDisplayInformation sub_departments_view;
			static IEnumerable<Department> sub_departments = new List<Department>();
		  static ViewDepartmentRequest input_model;
		}	
	}
}