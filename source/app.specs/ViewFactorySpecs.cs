using System.Web;
using Machine.Specifications;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
	[Subject(typeof(ViewFactory))]
	public class ViewFactorySpecs
	{
		public abstract class concern : Observes<ICreateViews, ViewFactory> { }

		public class when_getting_the_view_for_a_model : concern
		{
			Establish that = () =>
			                 	{
									page_creator = (path, type) => type == typeof(ADummyModel) ? (object)new ADummyView() : (object)new TheWrongView();
									depends.on(page_creator);

									model_to_show = new ADummyModel();
								};

			Because of = () =>
							{
								result = sut.create_view_that_can_render(model_to_show);
							};

			It should_return_the_expected_view_type = () =>
			                                        	{
			                                        		result.ShouldBeOfType<ADummyView>();
			                                        	};

			static ADummyModel model_to_show;
			static IHttpHandler result;
			static ICreateAspxPageInstances page_creator;
		}
	}

	public class ADummyModel
	{
	}

	public class ADummyView
	{
	}

	public class TheWrongView
	{
	}
}