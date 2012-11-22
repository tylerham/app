 using Machine.Specifications;
 using app.utility.service_locator;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(Container))]  
  public class ContainerSpecs
  {
    public abstract class concern : Observes<IFindDependencies,
                                      Container>
    {
        
    }

   
    public class when_observation_name : concern
    {
      Because b = () =>
        result = sut.an<TestDependency>();

      It should_be_an_instance_of_test_dependency = () => result.ShouldBeAn<TestDependency>();
      It should_not_be_null = () => result.ShouldNotBeNull();
      static TestDependency result;
    }
  }

  class TestDependency
  {}
}
