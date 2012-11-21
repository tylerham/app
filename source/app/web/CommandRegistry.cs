using System.Collections.Generic;
using System.Linq;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
    readonly IEnumerable<IProcessOneRequest> processors;

    public CommandRegistry(IEnumerable<IProcessOneRequest> processors)
    {
      this.processors = processors;
    }

    public IProcessOneRequest get_the_command_that_can_process(IContainRequestDetails request)
    {
      return processors.First(c => c.can_process(request));
    }
  }
}