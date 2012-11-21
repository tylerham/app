namespace app.web
{
  public class FrontController : IProcessRequests
  {
      private readonly IFindCommands _commandRegistry;

      public FrontController(IFindCommands commandRegistry)
      {
          _commandRegistry = commandRegistry;
      }

      public void process(IContainRequestDetails a_new_controller_request)
    {
      _commandRegistry.get_the_command_that_can_process(a_new_controller_request).run(a_new_controller_request);
    }
  }
}