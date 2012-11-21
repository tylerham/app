namespace app.web
{
  public interface IProcessOneRequest : ISupportAUserFeature
  {
    bool can_process(IContainRequestDetails request);
  }
}