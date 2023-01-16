using NPBehave;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class NP_RepeaterNodeData:NP_NodeDataBase
{
    [HideInEditorMode]
    public Repeater m_Repeater;
        
    public override Node NP_GetNode()
    {
        return this.m_Repeater;
    }
        
    public override Decorator CreateDecoratorNode(Root runtimeTree, Node node)
    {
        this.m_Repeater = new Repeater(node);
        return this.m_Repeater;
    }

}