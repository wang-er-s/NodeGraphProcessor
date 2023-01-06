﻿using GraphProcessor;
using NodeGraphProcessor.Examples;
using UnityEngine;

public class RuntimeConditionalGraph : MonoBehaviour
{
    [Header("Graph to Run on Start")] public BaseGraph graph;

    private ConditionalProcessor processor;

    private void Start()
    {
        if (graph != null)
            processor = new ConditionalProcessor(graph);

        processor.Run();
    }
}