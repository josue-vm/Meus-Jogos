using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Fase Teminada")]
    public bool fase01 = false;
    public bool fase02 = false;
    public bool fase03 = false;
    public bool fase04 = false;

    [Header("Fase Vencida")]
    public bool vitoria01 = false;
    public bool vitoria02 = false;
    public bool vitoria03 = false;
    public bool vitoria04 = false;

    public int contadorVitoria = 0;
    public int contadorFases = 0;
    public void ResetarJogo() {
        fase01 = false;
        fase02 = false;
        fase03 = false;
        fase04 = false;

        vitoria01 = false;
        vitoria02 = false;
        vitoria03 = false;
        vitoria04 = false;

        contadorVitoria = 0;
        contadorFases = 0;
    }
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
}