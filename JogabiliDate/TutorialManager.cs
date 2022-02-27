using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [Header("Assets")]
    [SerializeField] private TMP_InputField _inputNome;
    [SerializeField] private TMP_Dropdown _dropdownPronomes;
    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private GameObject _painelEscolha;
    [SerializeField] private TMP_Text _mensagem;
    [SerializeField] private TMP_Text _mensagemTutorial;
    [SerializeField] private TMP_Text _nextButton;
    [SerializeField] private TMP_Text _finalButton;

    [Header("Mensagens")]
    [TextArea(4, 13)]
    [SerializeField] private string[] _mensgensTutorial;

    private string _nome;
    private Pronomes _pronome;
    private int messageCount = 0;

    private void Start()
    {
        GameManager.Instance.state = States.Tutorial;
    }

    public void SetNome()
    {
        GameManager.Instance.nomePlayer = _inputNome.text;
    }

    public void SetPronome()
    {
        if (_dropdownPronomes.value == 0)
        {
            GameManager.Instance.pronome = Pronomes.Ele;
        }
        else if (_dropdownPronomes.value == 1)
        {
            GameManager.Instance.pronome = Pronomes.Ela;
        }
        else if (_dropdownPronomes.value == 2)
        {
            GameManager.Instance.pronome = Pronomes.Elu;
        }
    }

    public void NextMessage()
    {
        if (messageCount == 2)
        {
            _mensagemTutorial.text = _mensgensTutorial[messageCount];
            _nextButton.gameObject.SetActive(false);
            _finalButton.gameObject.SetActive(true);
        }
        else
        {
            _mensagemTutorial.text = _mensgensTutorial[messageCount];
            messageCount++;
        }
    }

    public void SetMessage()
    {
        _mensagem.text = "Olá " + GameManager.Instance.nomePlayer + ", deseja fazer o tutorial?";
    }

    public void CloseTutorial()
    {
        SceneManager.LoadScene(2);
    }
}
