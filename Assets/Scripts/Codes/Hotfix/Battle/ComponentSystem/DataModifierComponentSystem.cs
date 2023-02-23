using System.Collections.Generic;

namespace ET
{
    public class DataModifierComponentDestroySystem : DestroySystem<DataModifierComponent>
    {
        protected override void Destroy(DataModifierComponent self)
        {
            foreach (var selfAllModifier in self.AllModifiers.Values)
            {
                foreach (var dataModifier in selfAllModifier)
                {
                    dataModifier.Dispose();
                }
            }

            self.AllModifiers.Clear();
        }
    }

    public static class DataModifierComponentSystem
    {
        /// <summary>
        /// 新增一个数据修改器
        /// </summary>
        /// <param name="modifierName">所归属修改器集合名称</param>
        /// <param name="dataModifier">要添加的修改器</param>
        /// <param name="numericType">如果不为Min说明需要直接去更新属性</param>
        public static void AddDataModifier(this DataModifierComponent self, string modifierName,
            DataModifier dataModifier, NumericType numericType = NumericType.Min)
        {
            if (self.AllModifiers.TryGetValue(modifierName, out var modifiers))
            {
                modifiers.Add(dataModifier);
            }
            else
            {
                self.AllModifiers.Add(modifierName, new List<ADataModifier>() { dataModifier });
            }

            if (numericType == NumericType.Min)
                return;
            self.GetParent<Unit>().GetComponent<NumericComponent>()[numericType] =
                self.BaptismData(modifierName,
                    self.GetParent<Unit>().GetComponent<NumericComponent>().GetOriNum()[(int)numericType]);
        }

        /// <summary>
        /// 移除一个数据修改器
        /// </summary>
        /// <param name="modifierName">所归属修改器集合名称</param>
        /// <param name="dataModifier">要移除的修改器</param>
        /// <param name="numericType">如果不为Min说明需要直接去更新属性</param>
        public static void RemoveDataModifier(this DataModifierComponent self, string modifierName,
            ADataModifier dataModifier, NumericType numericType = NumericType.Min)
        {
            if (self.AllModifiers.TryGetValue(modifierName, out var modifiers))
            {
                if (modifiers.Remove(dataModifier))
                {
                    if (numericType == NumericType.Min)
                        return;
                    self.GetParent<Unit>().GetComponent<NumericComponent>()[numericType] =
                        self.BaptismData(modifierName,
                            self.GetParent<Unit>().GetComponent<NumericComponent>().GetOriNum()[(int)numericType]);
                    return;
                }
            }

            Log.Error($"目前数据修改器集合中没有名为：{modifierName}的集合");
        }

        /// <summary>
        /// 洗礼一个数值
        /// </summary>
        /// <param name="targetModifierName">目标修改器集合名称</param>
        /// <param name="targetData">将要修改的值</param>
        public static float BaptismData(this DataModifierComponent self, string targetModifierName, float targetData)
        {
            if (self.AllModifiers.TryGetValue(targetModifierName, out var modifiers))
            {
                float constantValue = 0;
                float percentageValue = 0;
                foreach (var modify in modifiers)
                {
                    if (modify.ModifierType == ModifierType.Constant)
                    {
                        constantValue += modify.GetModifierValue();
                    }
                    else
                    {
                        percentageValue += modify.GetModifierValue();
                    }
                }

                targetData = (targetData + constantValue) * (1 + percentageValue);
            }

            return targetData;
        }
    }
}