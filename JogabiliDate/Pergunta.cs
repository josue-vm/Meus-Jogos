using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Nova Pergunta", menuName = "Pergunta")]
public class Pergunta : ScriptableObject
{
    [Header("Infos")]

    [TextArea(3, 6)]
    public string mensagem;
    public string semana;
    public Sprite foto;

    [Header("Perguntas")]
    public string pergunta01;
    public int valorPergunta01;
    public string pergunta02;
    public int valorPergunta02;
    public string pergunta03;
    public int valorPergunta03;
    public string pergunta04;
    public int valorPergunta04;

}
