using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormsDisplayEngine : IDisplayInformation
  {
    readonly ICreateViews _viewFactory;
    readonly HttpContext _request;

    public WebFormsDisplayEngine(ICreateViews view_factory, HttpContext request)
    {
      _viewFactory = view_factory;
      _request = request;
    }

    public void display<PresentationModel>(PresentationModel model)
    {
_viewFactory.create_view_that_can_render(model).ProcessRequest(_request);
    }
  }
}