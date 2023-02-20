namespace ET
{
    public class ChangeMaterialBuffSystem: ABuffSystemBase<ChangeMaterialBuffData>
    {
#if !SERVER 
        /// <summary>
        /// 自身下一个时间点
        /// </summary>
        private long m_SelfNextimer;
#endif
        public override void OnExecute(uint currentFrame)
        {
#if !SERVER 
            EventSystem.Instance.Publish(new EventType.ChangeMaterialBuffSystemExcuteEvent()
                {ChangeMaterialBuffData = GetBuffDataWithTType, Target = this.GetBuffTarget()}).Coroutine();
#endif
        }

        public override void OnFinished(uint currentFrame)
        {
#if !SERVER 
            EventSystem.Instance.Publish(new EventType.ChangeMaterialBuffSystemFinishEvent()
                {ChangeMaterialBuffData = GetBuffDataWithTType, Target = this.GetBuffTarget()}).Coroutine();
#endif
        }

    }
}