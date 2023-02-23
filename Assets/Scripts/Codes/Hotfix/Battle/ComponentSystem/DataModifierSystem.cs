namespace ET
{
    public static class DataModifierSystem
    {
        public static void Modify(this DataModifier self)
        {
            self.GetParent<Entity>().GetComponent<NumericComponent>()[(int)self.NumericType] += self.Value;
        }

        public static void Reset(this DataModifier self)
        {
            self.GetParent<Entity>().GetComponent<NumericComponent>()[(int)self.NumericType] -= self.Value;
        }
    }
    
    public class DataModifierAwakeSystem : AwakeSystem<DataModifier,NumericType, int>
    {
        protected override void Awake(DataModifier self, NumericType a, int b)
        {
            self.NumericType = a;
            self.Value = b;
        }
    }
}