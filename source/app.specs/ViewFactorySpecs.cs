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
									model_to_show = new ADummyModel();

									view_type_finder = model => model.GetType() == typeof(ADummyModel) ? typeof(ADummyModelView) : typeof(TheWrongViewType);
									depends.on(view_type_finder);

			                 		expected_result = fake.an<IHttpHandler>();
									the_wrong_result = fake.an<IHttpHandler>();

									page_creator = (path, type) => type == typeof(ADummyModelView) ? expected_result : the_wrong_result;
									depends.on(page_creator);
								};

			Because of = () =>
							{
								actual_result = sut.create_view_that_can_render(model_to_show);
							};

			It should_return_the_expected_view_handler = () =>
			                                          	{
			                                          		actual_result.ShouldBeTheSameAs(expected_result);
			                                          	};

			static ADummyModel model_to_show;
			static IHttpHandler actual_result;

			static IHttpHandler expected_result;
			static IHttpHandler the_wrong_result;

			static IGetViewTypeForAModel view_type_finder;
			static ICreateAspxPageInstances page_creator;

		}
	}

	public class ADummyModel
	{
	}

	public class ADummyModelView
	{
	}

	public class TheWrongViewType
	{
	}
}