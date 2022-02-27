using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalTest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject painelWin;
    [SerializeField] private GameObject painelLose;
    [SerializeField] private TMP_Text mensagemWin;
    [SerializeField] private TMP_Text mensagemLose;

    void Start()
    {
        mensagemWin.text = GameManager.Instance.MudarNome(mensagemWin.text);
        mensagemLose.text = GameManager.Instance.MudarNome(mensagemLose.text);
        if (GameManager.Instance.state == States.Win)
        {
            painelWin.SetActive(true);
            painelLose.SetActive(false);
        }
        else if (GameManager.Instance.state == States.Lose)
        {
            painelWin.SetActive(false);
            painelLose.SetActive(true);
        }
    }

    public void Reiniciar()
    {
        GameManager.Instance.ResetFases();
        SceneManager.LoadScene(2);
    }

    public void Fechar()
    {
        Application.Quit();
    }
}
