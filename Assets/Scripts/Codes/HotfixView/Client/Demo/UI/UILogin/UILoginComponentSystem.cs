using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(UILoginComponent))]
    public static class UILoginComponentSystem
    {
        [ObjectSystem]
        public class UILoginComponentAwakeSystem : AwakeSystem<UILoginComponent>
        {
            protected override void Awake(UILoginComponent self)
            {
                ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
                self.loginBtn = rc.Get<GameObject>("LoginBtn");

                self.loginBtn.GetComponent<Button>().onClick.AddListener(() => { self.OnLogin(); });
                self.account = rc.Get<GameObject>("Account");
                self.password = rc.Get<GameObject>("Password");
            }
        }

        public static void OnLogin(this UILoginComponent self)
        {
            Log.Info(self.DomainScene().Name);
            Log.TraceInfo("track info");
            Log.Trace("track");
            Log.Info("info");
        }
    }
}