using System.Collections.Generic;
using System.Linq;

namespace FeatureToggle {
    public interface IFeatureFlags {
        bool IsEnabled(string key);
    }

    public class FeatureFlags : IFeatureFlags {
        private readonly List<Toggle> toggles;

        public FeatureFlags(List<Toggle> toggles) {
            this.toggles = toggles;
        }

        public bool IsEnabled(string key) => toggles.SingleOrDefault(t => t.ToggleKey.Equals(key))?.IsEnabled ?? false;
    }
}