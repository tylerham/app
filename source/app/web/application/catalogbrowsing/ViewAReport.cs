using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
	public class ViewAReport<PresentationData> : ISupportAUserFeature
	{
		IDisplayInformation display_engine;
		IGetPresentationDataFromARequest<PresentationData> query;

	  public ViewAReport(IGetPresentationDataFromARequest<PresentationData> query):this(new StubDisplayEngine(),query)
	  {
	  }

	  public ViewAReport(IFetchAReport<PresentationData> query):this(query.fetch_using)
	  {
	  }

	  public ViewAReport(IDisplayInformation display_engine, IGetPresentationDataFromARequest<PresentationData> query)
		{
			this.display_engine = display_engine;
			this.query = query;
		}

		public void run(IContainRequestDetails request)
		{
		  display_engine.display(query(request));
		}
	}
}