using NPBehave;
using Sirenix.OdinInspector;

public class NP_ServiceNodeData: NP_NodeDataBase
{
    [HideInEditorMode]
    public Service m_Service;

    [LabelText("委托执行时间间隔")]
    public float interval;

    public NP_ClassForStoreAction NpClassForStoreAction;

    public override Node NP_GetNode()
    {
        return this.m_Service;
    }

    public override Decorator CreateDecoratorNode(Root runtimeTree, Node node)
    {
        this.NpClassForStoreAction.BelongtoRuntimeTree = runtimeTree;
        this.m_Service = new Service(interval, this.NpClassForStoreAction.GetActionToBeDone(), node);
        return this.m_Service;
    }
}