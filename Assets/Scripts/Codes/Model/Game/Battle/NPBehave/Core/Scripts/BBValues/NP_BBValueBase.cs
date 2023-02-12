using Sirenix.OdinInspector;

namespace ET
{
    public abstract class NP_BBValueBase<T> : ANP_BBValue, INP_BBValue<T>
    {
        [LabelText("值")] public T Value;

        public T GetValue()
        {
            return Value;
        }
        
        public override void SetValueFrom(ANP_BBValue anpBbValue)
        {
            if (anpBbValue == null || !(anpBbValue is NP_BBValueBase<T>))
            {
                Log.Error($"{typeof(T)} 拷贝失败，anpBbValue为空或类型非法");
                return;
            }
            this.SetValueFrom((INP_BBValue<T>) anpBbValue);
        }
        
        protected virtual void SetValueFrom(INP_BBValue<T> bbValue)
        {
            if (bbValue == null || !(bbValue is NP_BBValueBase<T>) )
            {
                Log.Error($"{typeof(T)} 拷贝失败，anpBbValue为空或类型非法");
                return;
            }
            
            this.SetValueFrom(bbValue.GetValue());
        }
        
        public virtual void SetValueFrom(T bbValue)
        {
            Value = bbValue;
        }
    }
}