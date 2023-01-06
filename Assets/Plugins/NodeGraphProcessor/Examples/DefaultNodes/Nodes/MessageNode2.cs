﻿using System;
using GraphProcessor;

[Serializable]
[NodeMenuItem("Custom/MessageNode2")]
public class MessageNode2 : BaseNode
{
    [Input(name = "In")] public float input;

    [Output(name = "Out")] public float output;

    public override string name => "MessageNode2";

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