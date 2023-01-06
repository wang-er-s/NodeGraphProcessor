//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2021年5月31日 19:15:32
//------------------------------------------------------------

using GraphProcessor;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Examples.Editor._05_All
{
    public class NPBehaveToolbarView : UniversalToolbarView
    {
        private static BlackboardInspectorViewer _BlackboardInspectorViewer;

        public NPBehaveToolbarView(BaseGraphView graphView, MiniMap miniMap, BaseGraph baseGraph) : base(graphView,
            miniMap, baseGraph)
        {
        }

        private static BlackboardInspectorViewer s_BlackboardInspectorViewer
        {
            get
            {
                if (_BlackboardInspectorViewer == null)
                    _BlackboardInspectorViewer = ScriptableObject.CreateInstance<BlackboardInspectorViewer>();

                return _BlackboardInspectorViewer;
            }
        }

        protected override void AddButtons()
        {
            base.AddButtons();

            AddButton(new GUIContent("Blackboard", "打开Blackboard数据面板"),
                () =>
                {
                    s_BlackboardInspectorViewer.Blackboard =
                        (m_BaseGraph as NPBehaveGraph).NpBlackBoard;
                    Selection.activeObject = s_BlackboardInspectorViewer;
                }, false);
        }

        public class BlackboardInspectorViewer : SerializedScriptableObject
        {
            public NP_BlackBoard Blackboard;
        }
    }
}