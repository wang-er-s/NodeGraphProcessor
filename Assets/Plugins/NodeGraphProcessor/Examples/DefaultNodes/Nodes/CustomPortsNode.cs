using System;
using System.Collections.Generic;
using GraphProcessor;
using UnityEngine;

[Serializable]
[NodeMenuItem("Custom/MultiPorts")]
public class CustomPortsNode : BaseNode
{
    [Input] public List<float> inputs;

    [Output] public List<float> outputs; // TODO: custom function for this one

    // We keep the max port count so it doesn't cause binding issues
    [SerializeField] [HideInInspector] private int portCount = 1;

    public List<object> values = new();

    public override string name => "CustomPorts";

    public override string layoutStyle => "TestType";

    protected override void Process()
    {
        foreach (var inputValue in TryGetAllInputValues<float>(nameof(inputs))) outputs.Add(inputValue);

        // do things with values
    }

    public override void TryGetOutputValue<T>(NodePort outputPort, NodePort inputPort, ref T value)
    {
        //出端口所有连线对应端口中，目标入端口所对应的index
        var inputPortIndexInOutputPortEdge = outputPort.GetEdges().FindIndex(edge => edge.inputPort == inputPort);
        if (outputs[inputPortIndexInOutputPortEdge] is T finalValue) value = finalValue;
    }

    [CustomPortBehavior(nameof(inputs))]
    private IEnumerable<PortData> ListPortBehavior(List<SerializableEdge> edges)
    {
        portCount = Mathf.Max(portCount, edges.Count + 1);

        for (var i = 0; i < portCount; i++)
            yield return new PortData
            {
                displayName = "In " + i,
                displayType = typeof(float),
                identifier = i.ToString() // Must be unique
            };
    }
}