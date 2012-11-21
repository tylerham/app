using Machine.Specifications;
using app.web;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(RequestCommand))]
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestCommand>
    {
    }

    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
      };

      Because b = () =>
       result =  sut.can_process(request);
      
      It should_be_able_to_process_the_request = () => result.ShouldBeTrue();

      static IContainRequestDetails request;
      static bool result;
    }
  }
}