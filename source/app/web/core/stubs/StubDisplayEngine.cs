using System.Web;
using app.web.application.catalogbrowsing;

namespace app.web.core.stubs
{
  public class StubDisplayEngine : IDisplayInformation
  {
    public void display<PresentationModel>(PresentationModel model)
    {
      HttpContext.Current.Items.Add("blah",model);
      HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
    }
  }
}