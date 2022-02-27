using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    [Header("Propriedades")]
    [SerializeField] private GameObject confimationPanel;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float fadein;

    [Header("Fase")]
    [SerializeField] private GameObject fase;

    [Header("Problema")]
    [SerializeField] private Problema problema;

    private Color initialC;
    private Color finalC;
    private bool isFade;

    private void Awake()
    {
        problema.resolvido = false;
    }

    void OnMouseEnter()
    {
        if (problema.resolvido == true)
        {
            if (confimationPanel.activeSelf == false && isFade == false)
            {
                sprite.color = new Color(0, 1, 0, 0.25f);
                fase.GetComponent<FaseManager>().SetNomeCarta(problema.nome);
                fase.GetComponent<FaseManager>().SetDescricaoCarta("Problema Resolvido");
            }
        }
        else
        {
            if (confimationPanel.activeSelf == false && isFade == false)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.25f);
                fase.GetComponent<FaseManager>().SetNomeCarta(problema.nome);
                fase.GetComponent<FaseManager>().SetDescricaoCarta(problema.descricao);
            }
        }
    }
    void OnMouseExit()
    {
        if (confimationPanel.activeSelf == false && isFade == false)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
            fase.GetComponent<FaseManager>().SetNomeCarta("");
            fase.GetComponent<FaseManager>().SetDescricaoCarta("");
        }
    }

    public bool GetProblemaResolvido()
    {
        return problema.resolvido;
    }

    public void SetProblemaResolvido(bool status)
    {
        problema.resolvido = status;
    }

    public void FadeRed()
    {
        isFade = true;
        initialC = Color.white;
        finalC = Color.red;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.25f);
        StartCoroutine("ColorFadeIn");
    }

    public void FadeGreen()
    {
        isFade = true;
        initialC = Color.white;
        finalC = Color.green;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.25f);
        StartCoroutine("ColorFadeIn");
    }

    IEnumerator ColorFadeIn()
    {
        for (float i=0.01f; i<fadein; i+=0.1f)
        {
            sprite.material.color = Color.Lerp(initialC, finalC, i / fadein);
            yield return null;
        }
        StartCoroutine("ColorFadeOut");
    }

    IEnumerator ColorFadeOut()
    {
        for (float i = 0.01f; i < fadein; i += 0.1f)
        {
            sprite.material.color = Color.Lerp(finalC, initialC, i / fadein);
            yield return null;
        }
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0f);
        isFade = false;
    }
}