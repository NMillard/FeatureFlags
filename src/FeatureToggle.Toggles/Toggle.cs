namespace FeatureToggle.Toggles {
    public interface IToggle {
        string Key { get; }
        bool IsEnabled { get; }
    }
    
    public class ReleaseToggle : IToggle {
        public ReleaseToggle(string toggleKey, bool isEnabled) {
            Key = toggleKey;
            IsEnabled = isEnabled;
        }

        public string Key { get; }
        public bool IsEnabled { get; }
    }
}