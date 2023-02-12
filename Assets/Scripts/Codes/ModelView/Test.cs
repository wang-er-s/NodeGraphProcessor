using System;
using System.Collections.Generic;
using ET;
using ET.Client;
using MongoDB.Bson.Serialization;
using NPBehave;
using Sirenix.OdinInspector;
using UnityEngine;
using Exception = System.Exception;
using Root = NPBehave.Root;

public class Test : MonoBehaviour
{
    public TextAsset textAsset;

    [Button]
    private void Start()
    {
        var tree = CreateNpRuntimeTree();
        tree.Start();
    }

    public NP_RuntimeTree CreateNpRuntimeTree()
    {
        NP_DataSupportor npDataSupportor = BsonSerializer.Deserialize<NP_DataSupportor>(textAsset.bytes);

        long rootId = npDataSupportor.NpDataSupportorBase.NPBehaveTreeDataId;

        NP_RuntimeTree tempTree = new NP_RuntimeTree() { BelongNP_DataSupportor = npDataSupportor };

        //配置节点数据
        foreach (var nodeDateBase in npDataSupportor.NpDataSupportorBase.NP_DataSupportorDic)
        {
            try
            {
                switch (nodeDateBase.Value.BelongNodeType)
                {
                    case NodeType.Task:
                        nodeDateBase.Value.CreateTask(tempTree);
                        break;
                    case NodeType.Decorator:
                        nodeDateBase.Value.CreateDecoratorNode(tempTree,
                            npDataSupportor.NpDataSupportorBase.NP_DataSupportorDic[nodeDateBase.Value.LinkedIds[0]]
                                .NP_GetNode());
                        break;
                    case NodeType.Composite:
                        List<Node> temp = new List<Node>();
                        foreach (var linkedId in nodeDateBase.Value.LinkedIds)
                        {
                            temp.Add(npDataSupportor.NpDataSupportorBase.NP_DataSupportorDic[linkedId]
                                .NP_GetNode());
                        }

                        nodeDateBase.Value.CreateComposite(temp.ToArray());
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Error($"{e}-----{nodeDateBase.Value.NodeDes}");
                throw;
            }
        }

        //配置根结点
        tempTree.SetRootNode(npDataSupportor.NpDataSupportorBase.NP_DataSupportorDic[rootId].NP_GetNode() as Root);

        //配置黑板数据
        Dictionary<string, ANP_BBValue> bbvaluesManager = tempTree.GetBlackboard().GetDatas();
        foreach (var bbValues in npDataSupportor.NpDataSupportorBase.NP_BBValueManager)
        {
            bbvaluesManager.Add(bbValues.Key, bbValues.Value);
        }

        return tempTree;
    }
}
