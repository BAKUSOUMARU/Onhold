using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class SaveData
{
    public string _stageNumber;
}

public class JsonStageSelect : MonoBehaviour
{
    [SerializeField]
    [Header("�Z�[�u�f�[�^")]
    private SaveData _saveData;

    [SerializeField]
    [Header("�t�@�C���̏ꏊ")]
    private string _filePath;

    [SerializeField]
    [Header("�X�e�[�W�̃{�^��")]
    private List<GameObject> _stageButton;

    void Awake()
    {
        foreach (GameObject chr in _stageButton)
        {
            chr.SetActive(false);
        }
        _filePath = Application.persistentDataPath + "/" + ".savedata.json";
        Load();
    }

    public void Save(string _nowStageNumber)
    {
        if (!File.Exists(_filePath))
        {
            _filePath = Application.persistentDataPath + "/" + ".savedata.json";
        }
        else
        {
            new SaveData();
        }
        _saveData._stageNumber = _nowStageNumber;

        string json = JsonUtility.ToJson(_saveData);
        StreamWriter streamWriter = new StreamWriter(_filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();
    }

    public void Load()
    {
        if (File.Exists(_filePath))
        {                
            StreamReader streamReader;
            streamReader = new StreamReader(_filePath);
            string _data = streamReader.ReadToEnd();
            streamReader.Close();

            _saveData = JsonUtility.FromJson<SaveData>(_data);

            switch (_saveData._stageNumber)
            {
                case "Stage1":
                    _stageButton[0].SetActive(true);
                    Debug.Log("�X�e�[�W1�܂ł��J��");
                    break;

                case "Stage2":
                    _stageButton[0].SetActive(true);
                    _stageButton[1].SetActive(true);
                    Debug.Log("�X�e�[�W2�܂ł��J��");
                    break;

                case "Stage3":
                    _stageButton[0].SetActive(true);
                    _stageButton[1].SetActive(true);
                    _stageButton[2].SetActive(true);
                    Debug.Log("�X�e�[�W3�܂ł��J��");
                    break;

                case "Stage4":
                    _stageButton[0].SetActive(true);
                    _stageButton[1].SetActive(true);
                    _stageButton[2].SetActive(true);
                    _stageButton[3].SetActive(true);
                    Debug.Log("�X�e�[�W4�܂ł��J��");
                    break;

                case "Stage5":
                    _stageButton[0].SetActive(true);
                    _stageButton[1].SetActive(true);
                    _stageButton[2].SetActive(true);
                    _stageButton[3].SetActive(true);
                    _stageButton[4].SetActive(true);
                    Debug.Log("�X�e�[�W5�܂ł��J��");
                    break;
            }
        }
    }

    public void ResetSaveData()
    {
        _saveData._stageNumber = "Stage1";
        Debug.Log("���Z�b�g");
    }
}
