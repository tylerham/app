using app.web.core;

namespace app.web.application.catalogbrowsing
{
	public class ViewAModel<RequestData, PresentationData> : ISupportAUserFeature
	{
		readonly IDisplayInformation _displayEngine;
		readonly IGetPresentationDataFromARequest<RequestData, PresentationData> _dataFromARequestMapper;

		public ViewAModel(IDisplayInformation display_engine, IGetPresentationDataFromARequest<RequestData, PresentationData> dataFromARequestMapper)
		{
			_displayEngine = display_engine;
			_dataFromARequestMapper = dataFromARequestMapper;
		}

		public void run(IContainRequestDetails request)
		{
			var requestData = request.map<RequestData>();

			var displayData = _dataFromARequestMapper(requestData);

			_displayEngine.display(displayData);
		}
	}
}