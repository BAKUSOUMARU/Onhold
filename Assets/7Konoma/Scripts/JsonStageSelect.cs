using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int StageNumber;
}

public class JsonStageSelect : MonoBehaviour
{
    [SerializeField]
    [Header("セーブデータ")]
    private SaveData _saveData;

    [SerializeField]
    [Header("ファイルの場所")]
    private string _filePath;

    [SerializeField]
    [Header("ステージのボタン")]
    private GameObject[] _stageButton;

    void Awake()
    {
        foreach (GameObject chr in _stageButton)
        {
            chr.SetActive(false);
        }
        _filePath = Application.persistentDataPath + "/" + ".savedata.json";
        Load();
    }

    public void Save(int _nowStageNumber)
    {
        if (!File.Exists(_filePath))
        {
            _filePath = Application.persistentDataPath + "/" + ".savedata.json";
        }
        else
        {
            new SaveData();
        }
        _saveData.StageNumber = _nowStageNumber;

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

            for (int s = 0; s <= _saveData.StageNumber; s++)
            {
                _stageButton[s].SetActive(true);
                Debug.Log("ステージ" + s + "までを開放");
            }
        }
    }

    public void ResetSaveData()
    {
        _saveData.StageNumber = 1;
        Debug.Log("リセット");
    }
}
