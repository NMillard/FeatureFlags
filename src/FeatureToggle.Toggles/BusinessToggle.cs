using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureToggle.Toggles {
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

        public void RunPolicies(TContext context, Action enabledAction, Action disabledAction) {
            bool isEnabled = Policies.All(policy => policy(context));

            if (isEnabled) enabledAction();
            else disabledAction();
        }
    }
}