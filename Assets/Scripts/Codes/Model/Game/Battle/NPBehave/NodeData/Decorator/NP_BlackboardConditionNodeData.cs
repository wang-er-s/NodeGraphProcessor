﻿using NPBehave;
using Sirenix.OdinInspector;

[BoxGroup("黑板条件节点配置"), GUIColor(0.961f, 0.902f, 0.788f, 1f)]
[HideLabel]
public class NP_BlackboardConditionNodeData : NP_NodeDataBase
{
    [HideInEditorMode] private BlackboardCondition m_BlackboardConditionNode;

    [LabelText("运算符号")] public Operator Ope = Operator.IS_EQUAL;

    [LabelText("终止条件")] public Stops Stop = Stops.IMMEDIATE_RESTART;

    public NP_BlackBoardRelationData NPBalckBoardRelationData = new NP_BlackBoardRelationData()
        { WriteOrCompareToBB = true };

    public override Decorator CreateDecoratorNode(NP_RuntimeTree runtimeTree, Node node)
    {
        this.m_BlackboardConditionNode = new BlackboardCondition(this.NPBalckBoardRelationData.BBKey,
            this.Ope,
            this.NPBalckBoardRelationData.NP_BBValue, this.Stop, node);
        //此处的value参数可以随便设，因为我们在游戏中这个value是需要动态改变的
        return this.m_BlackboardConditionNode;
    }

    public override NodeType BelongNodeType => NodeType.Decorator;

    public override Node NP_GetNode()
    {
        return this.m_BlackboardConditionNode;
    }
}