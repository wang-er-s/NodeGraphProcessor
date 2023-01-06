﻿using System;
using System.Collections.Generic;
using GraphProcessor;

[Serializable]
[NodeMenuItem("Custom/CircleRadians")]
public class CircleRadians : BaseNode
{
    [Output(name = "In")] public List<float> outputRadians;

    public override string name => "CircleRadians";

    public override void TryGetOutputValue<T>(NodePort outputPort, NodePort inputPort, ref T value)
    {
        var inputPortIndexInOutputPortEdge = outputPort.GetEdges().FindIndex(edge => edge.inputPort == inputPort);
        if (outputRadians[inputPortIndexInOutputPortEdge] is T finalValue) value = finalValue;
    }
}