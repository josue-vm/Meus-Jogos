using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Problema", menuName = "Problema")]
public class Problema : ScriptableObject
{
    [Header("Nome/Descrição")]
    public string nome;
    [TextArea(4, 12)]
    public string descricao;
    [Header("Marcador de Resolução")]
    public bool resolvido = false;
}
