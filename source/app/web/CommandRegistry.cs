namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
    public IProcessOneRequest get_the_command_that_can_process(IContainRequestDetails request)
    {
      throw new System.NotImplementedException();
    }
  }
}