using Machine.Specifications;
using app.web;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

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
        a_resource_type = fake.an<IDescribeAResource>();
      };

      Because b = () =>
       result = sut.can_process(request);

      It should_check_request_resource_type = () => 
       request.received(x => x.is_requesting_resource_type(a_resource_type));

      static IContainRequestDetails request;
      static bool result;
      static IDescribeAResource a_resource_type;
    }
  }
}