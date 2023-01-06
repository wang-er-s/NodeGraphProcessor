using System;
using GraphProcessor;

[Serializable]
[NodeMenuItem("Custom/InheritanceBase")]
public class InheritanceBase : BaseNode
{
    [Input(name = "In Base")] public float input;

    [Output(name = "Out Base")] public float output;

    public float fieldBase;

    public override string name => "InheritanceBase";

    protected override void Process()
    {
        TryGetInputValue(nameof(input), ref input);
        output = input * 42;
    }

    public override void TryGetOutputValue<T>(NodePort outputPort, NodePort inputPort, ref T value)
    {
        if (output is T finalValue) value = finalValue;
    }
}