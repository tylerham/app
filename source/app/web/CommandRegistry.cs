using System.Collections.Generic;
using System.Linq;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
    readonly IEnumerable<IProcessOneRequest> processors;
    readonly ICreateTheCommandWhenOneCantBeFound _missingCommand;

    public CommandRegistry(IEnumerable<IProcessOneRequest> processors, ICreateTheCommandWhenOneCantBeFound missingCommand)
    {
      this.processors = processors;
      _missingCommand = missingCommand;
    }

    public IProcessOneRequest get_the_command_that_can_process(IContainRequestDetails request)
    {
      var match = processors.FirstOrDefault(c => c.can_process(request));
      return match ?? _missingCommand.Invoke();
    }
  }
}