# Feature Toggles

Consider if a feature is visible to users or code-only, such as choosing which algorithm to execute.

Feature toggles are practically one of two categories: a release or business toggle.

Release toggles are mainly helping the development team manage new releases. They're internal
technical tools to enable or disable features at runtime.
They allow you to easily merge new code into master without having to actually release the new feature. Mastering
release toggles even allows you to develop right on the master branch without the need for feature branches.
A release toggle must be removed as soon as it's no longer needed.

Business toggle are for the benefits of the business or clients. These toggles enables the business to toggle
features to tailor the experience of the application for business purposes. They're perfectly used for enabling
or disabling "pro" features for individual clients, when a client fulfills some defined "policy".
Business toggles might live throughout the whole application's lifetime.

Toggles may be either "baked" into the release by defining hard-coded toggles, or, they can be read from
some configuration source, such as appsettings.json or environment variables.

## Common mistakes when using feature toggles.
Highly coupled decisions. Decision point and decision logic is often coupled together because it's easy.
It's easy to slap in a simple if-else, testing if some flag is turned on or off. But, you'd really like to decouple the decision logic from the decision point.
Initially, approaching feature toggling using binary branching doesn't seem too bad. After all, what you want is to say "if this is on, then do this, otherwise do this other thing", and if-else perfectly helps you do just that.
But, you'll discover problems down the road, when you start to implement the exact same branching multiple places.