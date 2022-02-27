using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FaseManager : MonoBehaviour
{
    [Header("Título")]
    [SerializeField] private TMP_Text titulo;

    [Header("Contadores")]
    [SerializeField] private TMP_Text contadorRodadas;
    [SerializeField] private TMP_Text contadorCartas;

    [Header("Silders")]
    [SerializeField] private Slider sliderDinheiro;
    [SerializeField] private Slider sliderPessoas;
    [SerializeField] private Slider sliderComida;
    [SerializeField] private Slider sliderPesquisa;

    [Header("Valores")]
    [SerializeField] private TMP_Text valorDinheiro;
    [SerializeField] private TMP_Text valorPessoas;
    [SerializeField] private TMP_Text valorComida;
    [SerializeField] private TMP_Text valorPesquisa;

    [Header("Áreas")]
    [SerializeField] private GameObject area1;
    [SerializeField] private GameObject area2;
    [SerializeField] private GameObject area3;
    [SerializeField] private GameObject area4;

    [Header("Informação da Carta")]
    [SerializeField] private TMP_Text nomeCarta;
    [SerializeField] private TMP_Text descricaoCarta;

    [Header("Painel Finalização")]
    [SerializeField] private GameObject painelFinal;

    [Header("Seletor de Fase")]
    [SerializeField] private FaseIndex indexFase;

    [Header("Deck")]
    [SerializeField] private GameObject deck;

    private int faseCont = 6;
    private int cartasCont = 3;
    private int problemaCont = 4;
    private bool fimDeFase = false;

    private void Start()
    {
        AtivarAreaFade(area1);
        AtivarAreaFade(area2);
        AtivarAreaFade(area3);
        AtivarAreaFade(area4);
    }

    public void AtivarAreaFade(GameObject area)
    {
        area.SetActive(true);
        area.GetComponent<AreaManager>().FadeRed();
    }

    public void FadeGreen (EscolherArea area)
    {
        if (area == EscolherArea.Area01)
        {
            area1.GetComponent<AreaManager>().FadeGreen();
        }
        else if (area == EscolherArea.Area02)
        {
            area2.GetComponent<AreaManager>().FadeGreen();
        }
        else if (area == EscolherArea.Area03)
        {
            area3.GetComponent<AreaManager>().FadeGreen();
        }
        else if (area == EscolherArea.Area04)
        {
            area4.GetComponent<AreaManager>().FadeGreen();
        }
    }

    public void ProblemaResolvido(EscolherArea area)
    {
        if (area == EscolherArea.Area01)
        {
            area1.GetComponent<AreaManager>().SetProblemaResolvido(true);
        }
        else if (area == EscolherArea.Area02)
        {
            area2.GetComponent<AreaManager>().SetProblemaResolvido(true);
        }
        else if (area == EscolherArea.Area03)
        {
            area3.GetComponent<AreaManager>().SetProblemaResolvido(true);
        }
        else if (area == EscolherArea.Area04)
        {
            area4.GetComponent<AreaManager>().SetProblemaResolvido(true);
        }
    }

    public bool ValidarCartas(Card carta)
    {
        if (Mathf.Abs(carta.valorComida) <= sliderComida.value && 
            Mathf.Abs(carta.valorDinheiro) <= sliderDinheiro.value &&
            Mathf.Abs(carta.valorPesquisa) <= sliderPesquisa.value &&
            Mathf.Abs(carta.valorPessoas) <= sliderPessoas.value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetDinheiro(int valor)
    {
        sliderDinheiro.value += valor;
        valorDinheiro.text = sliderDinheiro.value.ToString("0");
    }

    public void SetPessoas(int valor)
    {
        sliderPessoas.value += valor;
        valorPessoas.text = sliderPessoas.value.ToString("0");
    }

    public void SetComida(int valor)
    {
        sliderComida.value += valor;
        valorComida.text = sliderComida.value.ToString("0");
        Debug.Log("somar: " + valor.ToString());
    }

    public void SetPesquisa(int valor)
    {
        sliderPesquisa.value += valor;
        valorPesquisa.text = sliderPesquisa.value.ToString("0");
    }

    public void SetTituloFase(string tituloFase)
    {
        titulo.text = tituloFase;
    }

    public void SetNomeCarta(string nome)
    {
        nomeCarta.text = nome;
    }

    public void SetDescricaoCarta(string descricao)
    {
        descricaoCarta.text = descricao;
    }

    public void SetContadorRodadas(int valor)
    {
        contadorRodadas.text = valor.ToString();
    }

    public void SetProblemaCont()
    {
        if (problemaCont > 0)
        {
            problemaCont -= 1;
        }
        if (problemaCont == 0)
        {
            SetVitoria();
            SetFimDeFase();
        }
    }

    public void SetFaseCont()
    {
        if (faseCont > 0)
        {
            faseCont -= 1;
            SetContadorRodadas(faseCont);
        }
        else if (faseCont == 0)
        {
            if (problemaCont == 1)
            {
                SetVitoria();
                SetFimDeFase();
            }
            else
            {
                painelFinal.GetComponentInChildren<TMP_Text>().text = "Que pena, você falhou!\nEscolha a próxima fase:";

                SetFimDeFase();
            }
        }
    }

    public void SetContadorCartas(int valor)
    {
        contadorCartas.text = "x" + valor.ToString();
    }

    public void SetCartasCont()
    {
        if (cartasCont > 0)
        {
            cartasCont -= 1;
            SetContadorCartas(cartasCont);
        }
        if (cartasCont == 0)
        {
            cartasCont = 3;
            SetContadorCartas(cartasCont);
            SetFaseCont();

            Invoke("DistribuirCartas", 0.3f);
        }
        else if (CartasDeque() <= cartasCont+1)
        {
            Invoke("DistribuirCartas", 0.3f);
        }
    }

    public void SetVitoria()
    {
        if (indexFase == FaseIndex.Fase01)
        {
            GameManager.instance.vitoria01 = true;
        }
        else if (indexFase == FaseIndex.Fase02)
        {
            GameManager.instance.vitoria02 = true;
        }
        else if (indexFase == FaseIndex.Fase03)
        {
            GameManager.instance.vitoria03 = true;
        }
        else if (indexFase == FaseIndex.Fase04)
        {
            GameManager.instance.vitoria04 = true;
        }
        GameManager.instance.contadorVitoria += 1;
    }

    public void SetFimDeFase()
    {
        if (fimDeFase == false)
        {
            deck.GetComponent<DeckManager>().VirarFundoCartas();
            GameManager.instance.contadorFases += 1;
            if (indexFase == FaseIndex.Fase01)
            {
                fimDeFase = true;
                painelFinal.SetActive(true);
                GameManager.instance.fase01 = true;
            }
            else if (indexFase == FaseIndex.Fase02)
            {
                fimDeFase = true;
                painelFinal.SetActive(true);
                GameManager.instance.fase02 = true;
            }
            else if (indexFase == FaseIndex.Fase03)
            {
                fimDeFase = true;
                painelFinal.SetActive(true);
                GameManager.instance.fase03 = true;
            }
            else if (indexFase == FaseIndex.Fase04)
            {
                fimDeFase = true;
                painelFinal.SetActive(true);
                GameManager.instance.fase04 = true;
            }
        }
    }

    public void ChamarSeletor()
    {
        if (GameManager.instance.contadorFases == 4)
        {
            if (GameManager.instance.contadorVitoria >= 3)
            {
                ScenesNavigator.instance.LoadScene(7);
            }
            else
            {
                ScenesNavigator.instance.LoadScene(6);
            }
        }
        else
        {
            ScenesNavigator.instance.LoadScene(1);
        }
    }

    private void DistribuirCartas()
    {
        deck.GetComponent<DeckManager>().DistribuirCartas();
    }

    private int CartasDeque() {
        return deck.GetComponent<DeckManager>().cartasPossiveis.Count;
    }

    public void SetAlerta(bool alerta)
    {
        if (alerta) descricaoCarta.color = new Color(1, 0, 0);
        else descricaoCarta.color = new Color(0, 0, 0);
    }
}

public enum FaseIndex
{
    Fase01,
    Fase02,
    Fase03,
    Fase04
}