using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PainelControl : MonoBehaviour
{
    [SerializeField] private GameObject _painelCorrigir;
    [SerializeField] private GameObject _painelApagar;
    [SerializeField] private TMP_InputField _textBox;
    [SerializeField] private TMP_Dropdown _options;
    [SerializeField] private Bingo bingo;

    void Start()
    {
        ReloadOptions();
    }

    public void ReloadOptions()
    {
        _options.ClearOptions();
        _options.AddOptions(bingo.GetBingoData());
    }

    public void OnpenCorrigir()
    {
        if (_painelCorrigir.activeSelf == false)
        {
            if (_painelApagar.activeSelf == true)
            {
                ReloadOptions();
                _painelApagar.SetActive(false);
                _painelCorrigir.SetActive(true);
                _options.gameObject.SetActive(true);
            }
            else
            {
                ReloadOptions();
                _painelCorrigir.SetActive(true);
                _options.gameObject.SetActive(true);
            }
        }
        else
        {
            if (_painelApagar.activeSelf == true)
            {
                _painelApagar.SetActive(false);
                _painelCorrigir.SetActive(false);
                _options.gameObject.SetActive(false);
            }
            else
            {
                _painelCorrigir.SetActive(false);
                _options.gameObject.SetActive(false);
            }
        }
    }

    public void OnpenApagar()
    {
        if (_painelApagar.activeSelf == false)
        {
            if (_painelCorrigir.activeSelf == true)
            {
                ReloadOptions();
                _painelApagar.SetActive(true);
                _options.gameObject.SetActive(true);
                _painelCorrigir.SetActive(false);
            }
            else
            {
                ReloadOptions();
                _painelApagar.SetActive(true);
                _options.gameObject.SetActive(true);
            }
        }
        else
        {
            if (_painelCorrigir.activeSelf == true)
            {
                _painelApagar.SetActive(false);
                _painelCorrigir.SetActive(false);
                _options.gameObject.SetActive(false);
            }
            else
            {
                _painelApagar.SetActive(false);
                _options.gameObject.SetActive(false);
            }
        }
    }

    public void RemoveOption()
    {
        int index = _options.value;
        string str = _options.options[index].text;
        bingo.RemoveWord(str);
        ReloadOptions();
    }

    public void ChangeWord()
    {
        int index = _options.value;
        string oldWord = _options.options[index].text;
        string newWord = _textBox.text;
        bingo.ModifiWord(newWord, oldWord);
        ReloadOptions();
    }
}
