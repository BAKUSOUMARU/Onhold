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
    [Header("セーブデータ")]
    private SaveData _saveData;

    [SerializeField]
    [Header("ファイルの場所")]
    private string _filePath;

    [SerializeField]
    [Header("ステージのボタン")]
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
                    Debug.Log("ステージ1までを開放");
                    break;

                case "Stage2":
                    _stageButton[0].SetActive(true);
                    _stageButton[1].SetActive(true);
                    Debug.Log("ステージ2までを開放");
                    break;

                case "Stage3":
                    _stageButton[0].SetActive(true);
                    _stageButton[1].SetActive(true);
                    _stageButton[2].SetActive(true);
                    Debug.Log("ステージ3までを開放");
                    break;

                case "Stage4":
                    _stageButton[0].SetActive(true);
                    _stageButton[1].SetActive(true);
                    _stageButton[2].SetActive(true);
                    _stageButton[3].SetActive(true);
                    Debug.Log("ステージ4までを開放");
                    break;

                case "Stage5":
                    _stageButton[0].SetActive(true);
                    _stageButton[1].SetActive(true);
                    _stageButton[2].SetActive(true);
                    _stageButton[3].SetActive(true);
                    _stageButton[4].SetActive(true);
                    Debug.Log("ステージ5までを開放");
                    break;
            }
        }
    }

    public void ResetSaveData()
    {
        _saveData._stageNumber = "Stage1";
        Debug.Log("リセット");
    }
}
