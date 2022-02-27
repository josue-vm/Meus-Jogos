using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Personagem", menuName = "Personagem")]
public class Personagem : ScriptableObject
{
    [Header("Info")]
    public string nome;
    public string arroba;

    [Header("Perguntas")]
    public Pergunta[] perguntas;
}
