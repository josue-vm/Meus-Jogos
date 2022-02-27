using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using TMPro;

public class Bingo : MonoBehaviour
{
    [SerializeField] private List<string> _bingoData;
    [SerializeField] private TMP_Text[] _texts;
    [SerializeField] private TMP_InputField _textField;
    private string[] _casasBingo;
    private string exportPath;
    private string importPath;

    void Awake()
    {
        BingoData data = SaveSys.LoadPlayer();
        _bingoData = data._bingoData;
        _casasBingo = new string[24];
        RandomBingo();
        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i].text = _casasBingo[i];
        }

        exportPath = Application.dataPath + "/Exportar/";
        importPath = Application.dataPath + "/Importar/";

        if (Directory.Exists(exportPath) == false)
        {
            Directory.CreateDirectory(exportPath);
        }

        if (Directory.Exists(importPath) == false)
        {
            Directory.CreateDirectory(importPath);
        }

        SaveSys.SaveToText();
    }

    public void AddWord()
    {
        string word = _textField.text;
        _bingoData.Add(word);
        SaveSys.SaveBingo(_bingoData);
    }

    public void RemoveWord(string word)
    {
        _bingoData.Remove(word);
        SaveSys.SaveBingo(_bingoData);
    }

    public void ModifiWord(string newWord, string oldWord)
    {
        int index = _bingoData.IndexOf(oldWord);
        _bingoData[index] = newWord;
        SaveSys.SaveBingo(_bingoData);
    }

    public void LoadSavedBingo()
    {
        string path = importPath + "Bingo.bg";
        BingoData data = SaveSys.LoadSave(path);
        _bingoData = data._bingoData;
        SaveSys.SaveBingo(_bingoData);
    }

    public void ExportSave()
    {
        string path = exportPath + "Bingo.bg";
        SaveSys.ExportBingo(_bingoData, path);
    }

    public void ReloadBingo()
    {
        BingoData data = SaveSys.LoadPlayer();
        _bingoData = data._bingoData;
        RandomBingo();
        for (int i=0; i<_texts.Length; i++)
        {
            _texts[i].text = _casasBingo[i];
        }
    }

    public void RandomBingo()
    {
        if (_bingoData.Count > 24)
        {
            int num = Random.Range(0, _bingoData.Count - 1);
            List<int> numbers = new List<int>(num);
            for (int i=0; i < 24; i++)
            {
                int n = Random.Range(0, _bingoData.Count - 1);
                while (numbers.Contains(n))
                {
                    n = Random.Range(0, _bingoData.Count - 1);
                }
                numbers.Add(n);
            }
            int[] vn = numbers.ToArray();
            for (int i=0; i < 24; i++ )
            {
                _casasBingo[i] = _bingoData.ToArray()[vn[i]];
            }
        }
    }

    public void SetText()
    {
        RandomBingo();
        for (int i=0; i<_casasBingo.Length; i++)
        {
            _texts[i].text = _casasBingo[i];
        }
    }

    public void SetBingoData(List<string> data)
    {
        _bingoData = data;
    }

    public void SetCasasBingo(string[] casas)
    {
        _casasBingo = casas;
    }

    public List<string> GetBingoData()
    {
        return _bingoData;
    }

    public string[] GetCasasBingo()
    {
        return _casasBingo;
    }
}