using System.Linq;

namespace FeatureToggle.Toggles {
    public interface IToggleRouter {
        bool IsEnabled(string key);
    }

    public class ReleaseRouter : IToggleRouter {
        private readonly IToggle[] toggles;

        public ReleaseRouter(IToggle[] toggles) {
            this.toggles = toggles;
        }

        public bool IsEnabled(string key) => toggles
            .SingleOrDefault(t => t.Key.Equals(key))?.IsEnabled ?? false;
    }

    public enum ToggleKey {
        NewUserType,
        OtherToggle
    }
}