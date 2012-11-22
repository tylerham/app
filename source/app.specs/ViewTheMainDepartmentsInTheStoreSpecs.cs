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
	[Subject(typeof(ViewTheMainDepartmentsInTheStore))]
	public class ViewTheMainDepartmentsInTheStoreSpecs
	{
		public abstract class concern : Observes<ISupportAUserFeature,
										  ViewTheMainDepartmentsInTheStore>
		{
		}

		public class when_run : concern
		{
			Establish c = () =>
			{
				request = fake.an<IContainRequestDetails>();
				department_repository = depends.on<IFetchStoreInformation>();

				department_repository.setup(x => x.get_the_main_departments()).Return(main_departments);

				departments_view = depends.on<IDisplayInformation>();
			};

			Because b = () =>
			  sut.run(request);

			It should_get_the_list_of_departments = () =>
			{
			};

			It should_display_departments =
			  () => departments_view.received(x => x.display(main_departments));

			static IContainRequestDetails request;
			static IFetchStoreInformation department_repository;
			static IDisplayInformation departments_view;
			static IEnumerable<Department> main_departments = new List<Department>();
		}
	}
}