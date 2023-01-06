using Examples.Editor._05_All;
using GraphProcessor;
using Plugins.NodeEditor;
using UnityEngine;

[NodeMenuItem("NPBehave行为树/Task/Wait", typeof (NPBehaveGraph))]
public class NP_RootNode : NP_NodeBase
{
    public GameObject Owner;

    public override Color color { get; } = Color.cyan;

    public override string name { get; } = "行为树根节点";

    [Output("下个节点"), Vertical]
    public BaseNode NextNode;

    protected override void Process()
    {
         
    }
}