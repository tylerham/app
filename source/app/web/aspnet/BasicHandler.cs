using System.Web;

namespace app.web.aspnet
{
  public class BasicHandler : IHttpHandler
  {
    public void ProcessRequest(HttpContext context)
    {
      throw new System.NotImplementedException();
    }

    public bool IsReusable { get; private set; }
  }
}