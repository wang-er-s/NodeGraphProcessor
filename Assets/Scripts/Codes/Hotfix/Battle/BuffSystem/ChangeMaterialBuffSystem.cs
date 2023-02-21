namespace ET
{
    public class ChangeMaterialBuffSystem : ABuffSystemBase<ChangeMaterialBuffData>
    {
        public override void OnExecute(uint currentFrame)
        {
            EventSystem.Instance.Publish(Root.Instance.Scene, new EventType.ChangeMaterialBuffSystemExcuteEvent()
                { ChangeMaterialBuffData = GetBuffDataWithTType, Target = this.GetBuffTarget() });
        }

        public override void OnFinished(uint currentFrame)
        {
            EventSystem.Instance.Publish(Root.Instance.Scene, new EventType.ChangeMaterialBuffSystemFinishEvent()
                { ChangeMaterialBuffData = GetBuffDataWithTType, Target = this.GetBuffTarget() });
        }
    }
}