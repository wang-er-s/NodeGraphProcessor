namespace ET
{
    //[EntityMenu(typeof (Unit), "打开属性菜单")]
    public class UnitNumericWindowMenu: AEntityMenuHandler
    {
        public override void OnClick(Entity entity)
        {
            MongoHelper.Init();
            //       var unit = entity as Unit;
            //     Log.Debug(unit.Config.Name);
        }
    }
}