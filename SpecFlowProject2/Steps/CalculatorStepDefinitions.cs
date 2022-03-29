using TechTalk.SpecFlow;

namespace SpecFlowProject2.Steps
{
    public interface IFoo
    {
        public void Bar();
    }

    public class Foo : IFoo
    {
        public void Bar()
        {
        }
    }

    [Binding]
    public sealed class RegistrationHooks
    {
        [BeforeTestRun]
        public static void RegisterTestThreadDependencies(TestThreadContext testThreadContext)
        {
            testThreadContext.TestThreadContainer.RegisterTypeAs<Foo, IFoo>();
        }
    }

    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly IFoo _foo;

        public CalculatorStepDefinitions(IFoo foo)
        {
            _foo = foo;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _foo.Bar();
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
        }
    }
}
