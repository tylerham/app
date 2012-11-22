using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewProductsInADepartment))]
  public class ViewProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewProductsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();

        input_model = new ViewProductsInDepartmentRequest();
        department_repository = depends.on<IFetchStoreInformation>();
        request.setup(x => x.map<ViewProductsInDepartmentRequest>()).Return(input_model);

        department_repository.setup(x => x.get_the_products_using(input_model)).Return(products);

        display_engine = depends.on<IDisplayInformation>();
      };

      Because b = () =>
        sut.run(request);

      It should_get_the_list_of_products = () =>
      {
      };

      It should_display_products =
        () => display_engine.received(x => x.display(products));

      static IContainRequestDetails request;
      static IFetchStoreInformation department_repository;
      static IDisplayInformation display_engine;
      static IEnumerable<Product> products = new List<Product>();
      static ViewProductsInDepartmentRequest input_model;
    }
  }
}