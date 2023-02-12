﻿using System;
using ET;
using Sirenix.OdinInspector;

[Title("给自己添加一个Buff", TitleAlignment = TitleAlignments.Centered)]
public class NP_AddBuffAction: NP_ClassForStoreAction
{
    public override Action GetActionToBeDone()
    {
        this.Action = this.AddBuff;
        return this.Action;
    }

    public void AddBuff()
    {
       Log.Info("添加一个buff"); 
    }
}