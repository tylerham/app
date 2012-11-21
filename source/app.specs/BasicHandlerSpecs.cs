 using System;
 using System.IO;
 using System.Web;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web;
 using app.web.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(BasicHandler))]  
  public class BasicHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      BasicHandler>
    {
        
    }

   
    public class when_processing_a_new_http_context : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessRequests>();
        a_raw_aspnet_request = ObjectFactory.web.create_request();
        a_new_controller_request = new object();
      };

      Because b = () =>
        sut.ProcessRequest(a_raw_aspnet_request);

      It should_delegate_the_processing_of_a_new_controller_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(a_new_controller_request));

      static IProcessRequests front_controller;
      static object a_new_controller_request;
      static HttpContext a_raw_aspnet_request;
    }
  }
}
