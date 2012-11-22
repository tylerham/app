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
			                 		expected_view = fake.an<IHttpHandler>();
									the_wrong_view = fake.an<IHttpHandler>();
									page_creator = (path, type) => type == typeof(ADummyModel) ? expected_view : the_wrong_view;
									depends.on(page_creator);

									model_to_show = new ADummyModel();
								};

			Because of = () =>
							{
								actual_result = sut.create_view_that_can_render(model_to_show);
							};

			It should_return_the_expected_view= () =>
			                                          	{
			                                          		actual_result.ShouldBeTheSameAs(expected_view);
			                                          	};

			static ADummyModel model_to_show;
			static IHttpHandler actual_result;
			static ICreateAspxPageInstances page_creator;
			static IHttpHandler expected_view;
			static IHttpHandler the_wrong_view;
		}
	}

	public class ADummyModel
	{
	}
}