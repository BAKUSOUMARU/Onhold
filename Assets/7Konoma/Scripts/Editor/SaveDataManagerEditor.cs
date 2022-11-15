using UnityEditor;
using UnityEngine;

namespace ISDevTemplateEditor
{
    [CustomEditor(typeof(JsonStageSelect))]
    public class SaveDataManagerEditor : Editor
    {
        [SerializeField] int _stageNunber;
        public override void OnInspectorGUI()
        {
            var maneger = target as JsonStageSelect;
            EditorGUILayout.LabelField("セーブ機能");
            DrawDefaultInspector();

            EditorGUILayout.Space(5f);
            _stageNunber = EditorGUILayout.IntField("保存したいステージ数", _stageNunber);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("セーブ"))
            {
                Debug.Log("セーブ");
                maneger.Save(_stageNunber);
            }
            if (GUILayout.Button("ロード"))   maneger.Load();
            if (GUILayout.Button("リセット")) maneger.ResetSaveData();

            EditorGUILayout.EndHorizontal();

        }
    }
}
