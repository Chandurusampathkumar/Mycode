using System;
using System.ServiceModel.Configuration;
using ServiceTests.Auth;

namespace PscSoapApiAutomation.Auth
{
    public class SetCookieBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new CookieSetterBehavior();
        }

        public override Type BehaviorType
        {
            get { return typeof(CookieSetterBehavior); }
        }
    }
    public class SetTokenBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new TokenSetterBehavior();
        }

        public override Type BehaviorType
        {
            get { return typeof(TokenSetterBehavior); }
        }
    }
}