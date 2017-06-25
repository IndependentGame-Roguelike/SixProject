using System.Collections.Generic;
using UnityEngine;

namespace UnityPluginAnalytics.Common {
    public interface IUMAnalytics {

        void Init(string appKey, string channelId);

        void SetDebugMode(bool debugMode);

        bool IsDebugMode();

        void OnResume();

        void OnPause();

        void StartLevel(string level);

        void FailLevel(string level);

        void FinishLevel(string level);

        void Pay(double money, string item, int number, double price, int source);

        void Use(string item, int number, double price);

        void Bonus(string item, int num, double price, int trigger);

        void OnProfileSignIn(string provider, string id);

        void SetPlayerLevel(int level);

        void OnEvent(string eventId);

        void OnEvent(string eventId, Dictionary<string, string> map);

        void OnEventValue(string id, Dictionary<string, string> map, int duration);

        void OnEvent(List<string> keyPath, int value, string label);
    }
}