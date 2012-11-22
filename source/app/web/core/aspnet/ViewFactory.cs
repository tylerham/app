using System.Web;

namespace app.web.core.aspnet
{
	public class ViewFactory : ICreateViews
	{
		public IHttpHandler create_view_that_can_render<PresentationModel>(PresentationModel data)
		{
			throw new System.NotImplementedException();
		}
	}
}