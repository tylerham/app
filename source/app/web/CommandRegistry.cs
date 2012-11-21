using System.Collections.Generic;
using System.Linq;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
    readonly IEnumerable<IProcessOneRequest> _commands;

    public CommandRegistry(IEnumerable<IProcessOneRequest> commands) {
      _commands = commands;
    }

    public IProcessOneRequest get_the_command_that_can_process(IContainRequestDetails request) { return 
      _commands.LastOrDefault(c => c.can_process(request)); }
  }
}