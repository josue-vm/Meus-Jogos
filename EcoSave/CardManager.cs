using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Fase")]
    [SerializeField] private GameObject fase;

    [Header("Carta")]
    [SerializeField] private Card carta;

    [Header("Info Status")]
    [SerializeField] private TMP_Text valorStatus;

    [Header("Info Solução")]
    [SerializeField] private TMP_Text valorPessoas;
    [SerializeField] private TMP_Text valorComida;
    [SerializeField] private TMP_Text valorPesquisa;
    [SerializeField] private TMP_Text valorDinheiro;

    [Header("Templates")]
    [SerializeField] private GameObject statusTemplate;
    [SerializeField] private GameObject solucaoTemplate;
    [SerializeField] private GameObject fundoTemplate;

    [SerializeField] private TemplateEnum templateTipo;

    [Header("Deck")]
    [SerializeField] private GameObject deck;


    public void SetTemplateTipo(TemplateEnum tipo)
    {
        templateTipo = tipo;
    }

    public void SetTemplatePelaCarta(Card novaCarta)
    {
        if (novaCarta.tipoCarta != TipoCartaEnum.Solucao)
        {
            templateTipo = TemplateEnum.Status;
        }
        else
        {
            templateTipo = TemplateEnum.Solucao;
        }
    }

    public void AtivaTemplate()
    {
        if (templateTipo == TemplateEnum.Status)
        {
            statusTemplate.SetActive(true);
            solucaoTemplate.SetActive(false);
            fundoTemplate.SetActive(false);

            statusTemplate.GetComponent<RawImage>().texture = carta.frente;
        }
        else if (templateTipo == TemplateEnum.Solucao)
        {
            statusTemplate.SetActive(false);
            solucaoTemplate.SetActive(true);
            fundoTemplate.SetActive(false);

            solucaoTemplate.GetComponent<RawImage>().texture = carta.frente;
        }
        else if (templateTipo == TemplateEnum.Fundo)
        {
            statusTemplate.SetActive(false);
            solucaoTemplate.SetActive(false);
            fundoTemplate.SetActive(true);
        }
    }

    public void SetTextoCarta()
    {
        if (templateTipo == TemplateEnum.Status)
        {
            valorStatus.text = ValorParaString(carta.valorStatus);
        }
        else if (templateTipo == TemplateEnum.Solucao)
        {
            valorComida.text = ValorParaString(carta.valorComida);
            valorDinheiro.text = ValorParaString(carta.valorDinheiro);
            valorPesquisa.text = ValorParaString(carta.valorPesquisa);
            valorPessoas.text = ValorParaString(carta.valorPessoas);
        }
    }

    public void SetNomeCarta()
    {
        fase.GetComponent<FaseManager>().SetNomeCarta(carta.nome);
    }

    public void SetDescricaoCarta()
    {
        string descricao = carta.descricao;

        if (templateTipo == TemplateEnum.Solucao && !fase.GetComponent<FaseManager>().ValidarCartas(carta))
        {
            descricao += "\n\nSem recurso suficiente!";
            fase.GetComponent<FaseManager>().SetAlerta(true);
        }
        else fase.GetComponent<FaseManager>().SetAlerta(false);

        fase.GetComponent<FaseManager>().SetDescricaoCarta(descricao);
    }

    public void MudarCarta(Card novaCarta)
    {
        carta = novaCarta;
        SetTemplatePelaCarta(carta);
        SetTextoCarta();
        AtivaTemplate();
    }

    public void virarFundo()
    {
        SetTemplateTipo(TemplateEnum.Fundo);
        AtivaTemplate();
        
        deck.GetComponent<DeckManager>().RemoverCartaMao(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(templateTipo == TemplateEnum.Fundo) return;
        SetNomeCarta();
        SetDescricaoCarta();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        fase.GetComponent<FaseManager>().SetNomeCarta("");
        fase.GetComponent<FaseManager>().SetDescricaoCarta("");
        fase.GetComponent<FaseManager>().SetAlerta(false);
    }

    private string ValorParaString(int valor)
    {
        if (valor > 0) return ("+" + valor.ToString());
        return valor.ToString();
    }

    public void BaixarCarta()
    {
        if (templateTipo == TemplateEnum.Solucao)
        {
            if (fase.GetComponent<FaseManager>().ValidarCartas(carta) == true) 
            {
                fase.GetComponent<FaseManager>().SetComida(carta.valorComida);
                fase.GetComponent<FaseManager>().SetDinheiro(carta.valorDinheiro);
                fase.GetComponent<FaseManager>().SetPesquisa(carta.valorPesquisa);
                fase.GetComponent<FaseManager>().SetPessoas(carta.valorPessoas);
                fase.GetComponent<FaseManager>().SetProblemaCont();
                fase.GetComponent<FaseManager>().SetCartasCont();
                fase.GetComponent<FaseManager>().FadeGreen(carta.area);
                fase.GetComponent<FaseManager>().ProblemaResolvido(carta.area);
                virarFundo();
            }
            else
            {
                Debug.Log("Valores maiores que os status");
            }
        }
        else if (templateTipo == TemplateEnum.Status)
        {
            if(carta.tipoCarta == TipoCartaEnum.Comida)
            {
                fase.GetComponent<FaseManager>().SetComida(carta.valorStatus);
            }
            else if (carta.tipoCarta == TipoCartaEnum.Dinheiro)
            {
                fase.GetComponent<FaseManager>().SetDinheiro(carta.valorStatus);
            }
            else if (carta.tipoCarta == TipoCartaEnum.Pesquisa)
            {
                fase.GetComponent<FaseManager>().SetPesquisa(carta.valorStatus);
            }
            else if (carta.tipoCarta == TipoCartaEnum.Populacao)
            {
                fase.GetComponent<FaseManager>().SetPessoas(carta.valorStatus);
            }
            fase.GetComponent<FaseManager>().SetCartasCont();
            virarFundo();
        }
    }
}

public enum EscolherArea
{
    Area01,
    Area02,
    Area03,
    Area04
}

public enum TipoCartaEnum
{
    Comida,
    Dinheiro,
    Pesquisa,
    Populacao,
    Solucao
}

public enum TemplateEnum
{
    Status,
    Solucao,
    Fundo
}