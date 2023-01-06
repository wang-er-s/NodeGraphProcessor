﻿using GraphProcessor;
using UnityEditor.UIElements;

[NodeCustomEditor(typeof(MultiAddNode))]
public class MultiAddNodeView : BaseNodeView
{
    public override void Enable()
    {
        var floatNode = nodeTarget as MultiAddNode;

        var floatField = new DoubleField
        {
            value = floatNode.output
        };

        // Update the UI value after each processing
        nodeTarget.onProcessed += () => floatField.value = floatNode.output;

        controlsContainer.Add(floatField);
    }
}