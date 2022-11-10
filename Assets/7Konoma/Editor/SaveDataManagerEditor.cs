using UnityEditor;
using UnityEngine;

namespace ISDevTemplateEditor
{
    [CustomEditor(typeof(JsonStageSelect))]
    public class SaveDataManagerEditor : Editor
    {
        [SerializeField] string _stageNunber;
        public override void OnInspectorGUI()
        {
            var maneger = target as JsonStageSelect;
            EditorGUILayout.LabelField("�Z�[�u�@�\");
            DrawDefaultInspector();

            EditorGUILayout.Space(5f);
            _stageNunber = EditorGUILayout.TextField("�ۑ��������X�e�[�W��", _stageNunber);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("�Z�[�u"))
            {
                Debug.Log("�Z�[�u");
                maneger.Save(_stageNunber);
            }
            if (GUILayout.Button("���[�h"))   maneger.Load();
            if (GUILayout.Button("���Z�b�g")) maneger.ResetSaveData();

            EditorGUILayout.EndHorizontal();

        }
    }
}
