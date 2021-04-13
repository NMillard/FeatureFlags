namespace FeatureToggle {
    public class Toggle {
        public string ToggleKey { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class SimpleToggle {
        public SimpleToggle(string toggle) {
        }
    }
}