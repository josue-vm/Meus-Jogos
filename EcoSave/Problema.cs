using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Problema", menuName = "Problema")]
public class Problema : ScriptableObject
{
    [Header("Nome/Descri��o")]
    public string nome;
    [TextArea(4, 12)]
    public string descricao;
    [Header("Marcador de Resolu��o")]
    public bool resolvido = false;
}
