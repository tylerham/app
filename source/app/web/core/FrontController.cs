namespace app.web.core
{
  public class FrontController : IProcessRequests
  {
      IFindCommands _commandRegistry;

      public FrontController(IFindCommands commandRegistry)
      {
          _commandRegistry = commandRegistry;
      }

    public FrontController():this(new CommandRegistry())
    {
    }

    public void process(IContainRequestDetails request)
    {
      _commandRegistry.get_the_command_that_can_process(request).run(request);
    }
  }
}