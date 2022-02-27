using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplacePronun : MonoBehaviour
{
    [SerializeField] private string _nome;
    [SerializeField] private Pronomes _pronome;

    private List<string[]> pronomesSingular = new List<string[]> { new string[3]{"ela", "ele", "elu"},
                                                           new string[3]{"dela", "dele", "delu"},
                                                           new string[3]{"nela", "nele", "nelu"},
                                                           new string[3]{"esta", "este",  "estu"},
                                                           new string[3]{"desta", "deste", "destu"},
                                                           new string[3]{"nesta", "neste", "nestu"},
                                                           new string[3]{"essa", "esse",  "essu"},
                                                           new string[3]{"dessa", "desse", "dessu"},
                                                           new string[3]{"nessa", "nesse", "nessu"},
                                                           new string[3]{"aquela", "aquele", "aquelu"},
                                                           new string[3]{"daquela", "daquele", "daquelu"},
                                                           new string[3]{"naquela",  "naquele", "naquelu"},
                                                           new string[3]{"àquela", "àquele", "àquelu"} };

    private List<string[]> pronomesPlural = new List<string[]> { new string[3]{"elas", "eles", "elus"},
                                                                 new string[3]{"delas", "deles", "delus"},
                                                                 new string[3]{"nelas", "neles", "nelus"},
                                                                 new string[3]{"estas", "estes", "estus"},
                                                                 new string[3]{"destas","destes", "destus"},
                                                                 new string[3]{"nestas", "nestes", "nestus"},
                                                                 new string[3]{"essas", "esses", "essus"},
                                                                 new string[3]{"dessas", "desses", "dessus"},
                                                                 new string[3]{"nessas", "nesses", "nessus"},
                                                                 new string[3]{"aquelas", "aqueles", "aquelus"},
                                                                 new string[3]{"daquelas", "daqueles", "daquelus"},
                                                                 new string[3]{"naquelas", "naqueles", "naquelus"},
                                                                 new string[3]{"àquelas", "àqueles", "àquelus"} };

    void Start()
    {
        ChangeNome();
        Debug.Log("Pronome = Ela");
        ReplacePronons(Pronomes.Ele);
        ReplacePronons(Pronomes.Elu);
        _pronome = Pronomes.Ele;
        Debug.Log("Pronome = Ele");
        ReplacePronons(Pronomes.Ela);
        ReplacePronons(Pronomes.Elu);
        Debug.Log("Pronome = Elu");
        _pronome = Pronomes.Elu;
        ReplacePronons(Pronomes.Ela);
        ReplacePronons(Pronomes.Ele);
    }

    public void SetNome(string nome)
    {
        _nome = nome;
    }

    public string GetNome()
    {
        return _nome;
    }

    public void SetPronome(Pronomes pronome)
    {
        _pronome = pronome;
    }

    public Pronomes GetPronome()
    {
        return _pronome;
    }

    public void ChangeNome()
    {
        string texto = "Olá #nome seja bem vindo(a/u)! #nome essa é uma frase teste. Obrigado por jogar, #nome!";
        string saida = texto.Replace("#nome", _nome);
        Debug.Log(texto);
        Debug.Log(saida);
    }

    //string inicial, string final, Pronomes pInicilal, Pronomes pFinal
    public void ReplacePronons(Pronomes pEntrada)
    {
        string textoA = "ela dela nela esta desta nesta essa dessa nessa aquela daquela naquela àquela";
        string textoB = "ele dele nele este deste neste esse desse nesse aquele daquele naquele àquele";
        string textoC = "elu delu nelu estu destu nestu essu dessu nessu aquelu daquelu naquelu àquelu";
        string saida = "";


        switch (_pronome)
        {
            case Pronomes.Ela:
                if (pEntrada == Pronomes.Ele)
                {
                    saida = textoB;
                    Debug.Log(textoB);
                }
                else if (pEntrada == Pronomes.Elu)
                {
                    saida = textoC;
                    Debug.Log(textoC);
                }
                foreach (string[] pronome in pronomesSingular)
                {
                    if (pEntrada == Pronomes.Ele)
                    {
                        if (saida.Contains(pronome[1]))
                        {
                            saida = saida.Replace(pronome[1], pronome[0]);
                        }
                    }
                    if (pEntrada == Pronomes.Elu)
                    {
                        if (saida.Contains(pronome[2]))
                        {
                            saida = saida.Replace(pronome[2], pronome[0]);
                        }
                    }
                }
                Debug.Log(saida);
                break;
            case Pronomes.Ele:
                if (pEntrada == Pronomes.Ela)
                {
                    saida = textoA;
                    Debug.Log(textoB);
                }
                else if (pEntrada == Pronomes.Elu)
                {
                    saida = textoC;
                    Debug.Log(textoC);
                }
                foreach (string[] pronome in pronomesSingular)
                {
                    if (pEntrada == Pronomes.Ela)
                    {
                        if (saida.Contains(pronome[0]))
                        {
                            saida = saida.Replace(pronome[0], pronome[1]);
                        }
                    }
                    if (pEntrada == Pronomes.Elu)
                    {
                        if (saida.Contains(pronome[2]))
                        {
                            saida = saida.Replace(pronome[2], pronome[1]);
                        }
                    }                  
                }
                Debug.Log(saida);
                break;
            case Pronomes.Elu:
                if (pEntrada == Pronomes.Ela)
                {
                    saida = textoA;
                    Debug.Log(textoA);
                }
                else if (pEntrada == Pronomes.Ele)
                {
                    saida = textoB;
                    Debug.Log(textoB);
                }
                foreach (string[] pronome in pronomesSingular)
                {
                    saida = textoA;
                    if (pEntrada == Pronomes.Ela)
                    {
                        if (saida.Contains(pronome[0]))
                        {
                            saida = saida.Replace(pronome[0], pronome[2]);
                        }
                    }
                    if (pEntrada == Pronomes.Ele)
                    {
                        if (saida.Contains(pronome[1]))
                        {
                            saida = saida.Replace(pronome[1], pronome[2]);
                        }
                    }
                }
                Debug.Log(saida);
                break;
        }
    }
}