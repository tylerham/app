namespace app.web.application.catalogbrowsing
{
	public delegate PresentationData IGetPresentationDataFromARequest<Request, PresentationData>(Request input);
}