using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTrigger : MonoBehaviour
{
    public Text textField;
    private bool testTuturial = false;
    private bool testCredits = false;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
     public void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void Tutorial()
    {
        if (testTuturial == false)
        {
            textField.text = "\nTutorial: \nPassar texto: Digite o botão Próximo. \nInserir palavra: digite o texto na caixa de texto e aperte o botão próximo. \nPedir dica: Digite o botão dica.";
            testTuturial = true;
        }
        else
        {
            textField.text = "";
            testTuturial = false;
        }
    }

    public void Credits()
    {
        if (testCredits == false)
        {
            textField.text = "\nCriador: \nJosué Vieira de Melo \nContato: \nInstagram: @magicbits_ \nTwitter: @magicbits_ \nTwitch: @magicbits_";
            testCredits = true;
        }
        else
        {
            textField.text = "";
            testCredits = false;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
