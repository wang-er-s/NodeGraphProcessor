namespace ET
{
    public class DataModifier : Entity , IAwake<NumericType, int>
    {
        /// <summary>
        /// 修改器类型
        /// </summary>
        public NumericType NumericType;

        public int Value;

    }
}