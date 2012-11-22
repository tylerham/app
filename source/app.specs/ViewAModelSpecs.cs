using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
	[Subject(typeof(ViewAModel<string, int>))]
	public class ViewAModelSpecs
	{
		public abstract class concern : Observes<ISupportAUserFeature,
										  ViewAModel<string, int>>
		{
		}

		public class when_run : concern
		{
			Establish c = () =>
			{
				request = fake.an<IContainRequestDetails>();
				request_data = "Test";
				mapper = input => input == request_data ? displayData : -1;			
				depends.on(mapper);

				request.setup(x => x.map<string>()).Return(request_data);

				display_engine = depends.on<IDisplayInformation>();
			};

			Because b = () =>
			  sut.run(request);

			It should_get_the_list_of_products = () =>
			{
			};

			It should_display_products =
			  () => display_engine.received(x => x.display(displayData));

			static IContainRequestDetails request;
			static IDisplayInformation display_engine;
			static int displayData;
			static string request_data;
			static IGetPresentationDataFromARequest<string, int> mapper;
		}
	}
}