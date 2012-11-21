namespace app.web
{
  public interface IProcessOneRequest
  {
    void run(IContainRequestDetails request);
    bool can_process(IContainRequestDetails request);
  }
}