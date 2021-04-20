using System.Linq;
using FeatureToggle.Toggles;
using Xunit;
using Xunit.Abstractions;

namespace FeatureToggle.Tests {
    public class UnitTest1 {
        private readonly ITestOutputHelper testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper) {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1() {
            var permissions = new[] { "app.read", "app.write" };
            
            new BusinessToggle<string[]>()
                .EnableWhen(s => s.Contains("app.edit"))
                .AndWhen(s => s.Length < 3)
                .RunPolicies(permissions,
                    () => testOutputHelper.WriteLine("is enabled"),
                    () => testOutputHelper.WriteLine("is disabled")
                );
        }
    }
}