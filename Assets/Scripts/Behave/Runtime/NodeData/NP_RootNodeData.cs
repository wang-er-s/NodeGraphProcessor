using NPBehave;
using Sirenix.OdinInspector;

public class NP_RootNodeData : NP_NodeDataBase
{
    [HideInEditorMode] public Root m_Root;

    public override Node NP_GetNode()
    {
        return this.m_Root;
    }
}