using System.Linq;
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
            var sut = new BusinessToggle<User>();
            var user = new User {
                Username = "hello",
                Permissions = new[] { "app.read", "app.write" },
            };

            bool enabled = sut.EnableWhen(u => u.Username.Equals("hello"))
                .AndWhen(u => u.Permissions.Contains("app.edit"))
                .RunPolicies(user);

            testOutputHelper.WriteLine(enabled ? "Is enabled!" : "not enabled");
        }
    }
}