using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance 
    { 
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }


    public States state;
    [Header("PlayerInfo")]
    public string nomePlayer;
    public Pronomes pronome;
    public int faseCount = 0;
    public bool vitoria = false;

    [Header("FasesCount")]
    public int andreCount = 0;
    public int sushiCount = 0;
    public int rafaCount = 0;
    public int tenguCount = 0;

    [Header("FasesTerminadas")]
    public bool andreTerm = false;
    public bool sushiTerm = false;
    public bool rafaTerm = false;
    public bool tenguTerm = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadAndre()
    {
        SceneManager.LoadScene("maajin");
    }

    public void LoadSushi()
    {
        SceneManager.LoadScene("sushi");
    }

    public void LoadRafa()
    {
        SceneManager.LoadScene("rafa");
    }

    public void LoadTengu()
    {
        SceneManager.LoadScene("tengu");
    }

    public void SetFaseCount(int value)
    {
        int aux = faseCount;
        if (aux >= 0 && aux <= 10)
        {
            aux += value;
            if (aux < 0)
            {
                faseCount = 0;
            }
            else if (aux > 10)
            {
                faseCount = 10;
            }
            else
            {
                faseCount += value;
            }
        }
    }

    public void SaveFaseCount(States state)
    {
        if (state == States.Maajin)
        {
            andreCount = faseCount;
        }
        else if (state == States.Sushi)
        {
            sushiCount = faseCount;
        }
        else if (state == States.Rafa)
        {
            rafaCount = faseCount;
        }
        else if (state == States.Tengu)
        {
            tenguCount = faseCount;
        }
    }

    public void SetVitoria (bool vit)
    {
        vitoria = vit;
        if (vitoria == true)
        {
            state = States.Win;
        }
        else
        {
            state = States.Lose;
        }
    }

    public void SetFaseTeminada(States state)
    {
        if (state == States.Maajin)
        {
            andreTerm = true;
        }
        else if (state == States.Sushi)
        {
            sushiTerm = true;
        }
        else if (state == States.Rafa)
        {
            rafaTerm = true;
        }
        else if (state == States.Tengu)
        {
            tenguTerm = true;
        }
    }

    public void ResetFases()
    {
        faseCount = 0;
        andreTerm = false;
        andreCount = 0;
        sushiTerm = false;
        sushiCount = 0;
        rafaTerm = false;
        rafaCount = 0;
        tenguTerm = false;
        tenguCount = 0;
    }

    public string MudarNome(string texto)
    {
        Debug.Log(nomePlayer);
        string saida = texto.Replace("#nome", nomePlayer);
        return saida;
    }
}

public enum States
{
    MainMenu,
    Tutorial,
    Maajin,
    Sushi,
    Rafa,
    Tengu,
    Win,
    Lose
}

public enum Pronomes
{
    Ela,
    Ele,
    Elu
}