using System.Linq;

namespace ET
{
    [ObjectSystem]
    public class UnitComponentAwakeSystem : AwakeSystem<UnitComponent>
    {
        protected override void Awake(UnitComponent self)
        {
        }
    }

    [ObjectSystem]
    public class UnitComponentDestroySystem : DestroySystem<UnitComponent>
    {
        protected override void Destroy(UnitComponent self)
        {
            foreach (Unit unit in self.idUnits.Values)
            {
                unit.Dispose();
            }

            self.idUnits.Clear();
        }
    }

 
}