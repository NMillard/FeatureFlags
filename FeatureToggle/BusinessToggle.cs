/*
 * Consider if a feature is visible to users or code-only, such as choosing which algorithm to execute.
 *
 * Feature toggles are practically one of two categories: a release or business toggle.
 * 
 * Release toggles are mainly helping the development team manage new releases. They're internal
 * technical tools to enable or disable features at runtime.
 * They allow you to easily merge new code into master without having to actually release the new feature. Mastering
 * release toggles even allows you to develop right on the master branch without the need for feature branches.
 * A release toggle must be removed as soon as it's no longer needed.
 *
 * Business toggle are for the benefits of the business or clients. These toggles enables the business to toggle
 * features to tailor the experience of the application for business purposes. They're perfectly used for enabling
 * or disabling "pro" features for individual clients, when a client fulfills some defined "policy".
 * Business toggles might live throughout the whole application's lifetime.
 *
 * Toggles may be either "baked" into the release by defining hard-coded toggles, or, they can be read from
 * some configuration source, such as appsettings.json or environment variables.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureToggle {
    public class BusinessToggle<TContext> {
        private readonly BusinessPolicyBuilder<TContext> policyBuilder = new();
        public BusinessPolicyBuilder<TContext> EnableWhen(Predicate<TContext> predicate) {
            policyBuilder.Policies.Add(predicate);
            return policyBuilder;
        }
    }

    public class BusinessPolicyBuilder<TContext> {
        internal readonly List<Predicate<TContext>> Policies = new();
        
        public BusinessPolicyBuilder<TContext> AndWhen(Predicate<TContext> predicate) {
            Policies.Add(predicate);
            return this;
        }

        public bool RunPolicies(TContext context) => Policies.All(policy => policy(context));
    }
    
    public class User {
        public string Username { get; set; }
        public string[] Permissions { get; set; } = new string[0];
    }
}