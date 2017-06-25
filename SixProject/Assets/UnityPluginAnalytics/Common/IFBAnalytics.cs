using UnityEngine;

namespace UnityPluginAnalytics.Common {
    public interface IFBAnalytics {
    
        void Init(string appId);

        void OnResume();

        void OnPause();

    }
}