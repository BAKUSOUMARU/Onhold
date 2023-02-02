using UnityEditor;
using UnityEngine;

namespace JsonSave
{
    [CustomEditor(typeof(JsonStageSelect))]
    public class SaveDataManagerEditor : Editor
    {
        int _stageNumber; 

        public override void OnInspectorGUI()
        {
            var manager = target as JsonStageSelect;
            EditorGUILayout.LabelField("セーブ機能");
            DrawDefaultInspector();

            EditorGUILayout.Space(5f);
            _stageNumber = EditorGUILayout.IntField("保存したいステージ数", _stageNumber);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("セーブ"))
            {
                Debug.Log("セーブ");
                manager.Save(_stageNumber);
            }
            if (GUILayout.Button("ロード"))   manager.Load();
            if (GUILayout.Button("リセット")) manager.ResetSaveData();

            EditorGUILayout.EndHorizontal();
        }
    }
}
