using System.Collections.Generic;
using System.Linq;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
      private readonly IEnumerable<IProcessOneRequest> _processors;

      public CommandRegistry(IEnumerable<IProcessOneRequest> processors )
      {
          _processors = processors;
      }

      public IProcessOneRequest get_the_command_that_can_process(IContainRequestDetails request)
      {
        return  _processors.First(c => c.can_process(request));
      }
  }
}