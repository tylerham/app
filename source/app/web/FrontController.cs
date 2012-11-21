namespace app.web
{
  public class FrontController : IProcessRequests
  {
    readonly IFindCommands _commandRegistry;

    public FrontController(IFindCommands command_registry) {
      _commandRegistry = command_registry;
    }

    public void process(IContainRequestDetails a_new_controller_request)
    {
      _commandRegistry.get_the_command_that_can_process(a_new_controller_request).run(a_new_controller_request);
    }
  }
}