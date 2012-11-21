 using Machine.Specifications;
 using app.web;
 using app.web.application.catalogbrowsing;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(ViewTheMainDepartmentsInTheStore))]  
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewTheMainDepartmentsInTheStore>
    {
        
    }

   
    public class when_run : concern
    {
        
      It first_observation = () =>        
        
    }
  }
}
