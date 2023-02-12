﻿using System.Collections.Generic;
using ET;

namespace NPBehave
{
    public class SyncContext
    {
        private Dictionary<string, Blackboard> blackboards = new Dictionary<string, Blackboard>();

        private Clock clock;

        public SyncContext(NP_SyncComponent npSyncComponent)
        {
            // clock = new Clock(npSyncComponent.GetParent<Unit>().BelongToRoom.GetComponent<LSF_Component>());
        }

        public Clock GetClock()
        {
            return clock;
        }

        public Blackboard GetSharedBlackboard(string key)
        {
            if (!blackboards.ContainsKey(key))
            {
                blackboards.Add(key, new Blackboard(clock));
            }

            return blackboards[key];
        }

        public void Update()
        {
            clock.Update(1);
        }
    }
}