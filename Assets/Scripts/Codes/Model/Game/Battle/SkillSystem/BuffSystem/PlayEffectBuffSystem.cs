namespace ET
{
    public class PlayEffectBuffSystem : ABuffSystemBase<PlayEffectBuffData>
    {
#if !SERVER
        public override void OnExecute(uint currentFrame)
        {
            EventSystem.Instance.Publish(new EventType.PlayEffectBuffSystemExcuteEvent()
            {
                PlayEffectBuffData = GetBuffDataWithTType, Target = this.GetBuffTarget(),
                CurrentOverlay = this.CurrentOverlay
            });
            Log.Info($"Execute播放：{GetBuffDataWithTType.EffectName}");
            if (this.BuffData.EventIds != null)
            {
                foreach (var eventId in this.BuffData.EventIds)
                {
                    Game.Scene.GetComponent<BattleEventSystemComponent>().Run($"{eventId}{this.TheUnitFrom.Id}", this);
                    //Log.Info($"抛出了{this.MSkillBuffDataBase.theEventID}{this.theUnitFrom.Id}");
                }
            }
        }

        public override void OnFinished(uint currentFrame)
        {
            EventSystem.Instance.Publish(new EventType.PlayEffectBuffSystemFinishEvent()
            {
                PlayEffectBuffData = GetBuffDataWithTType, Target = this.GetBuffTarget(),
                CurrentOverlay = this.CurrentOverlay
            });
        }

        public override void OnRefreshed(uint currentFrame)
        {
            EventSystem.Instance.Publish(new EventType.PlayEffectBuffSystemExcuteEvent()
            {
                PlayEffectBuffData = GetBuffDataWithTType, Target = this.GetBuffTarget(),
                CurrentOverlay = this.CurrentOverlay
            });
            Log.Info($"Refresh播放：{GetBuffDataWithTType.EffectName}");
            if (this.BuffData.EventIds != null)
            {
                foreach (var eventId in this.BuffData.EventIds)
                {
                    Game.Scene.GetComponent<BattleEventSystemComponent>().Run($"{eventId}{this.TheUnitFrom.Id}", this);
                    //Log.Info($"抛出了{this.MSkillBuffDataBase.theEventID}{this.theUnitFrom.Id}");
                }
            }
        }
#else
        public override void OnExecute(uint currentFrame)
        {

        }

#endif
    }
}