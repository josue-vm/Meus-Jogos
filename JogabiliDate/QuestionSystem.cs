using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestionSystem : MonoBehaviour
{
    [Header("Fase Info")]
    public Personagem personagem;
    public States state;

    [Header("Info")]
    public TMP_Text nome;
    public TMP_Text arroba;
    public TMP_Text semana;
    public TMP_Text arrobaResposta;
    public TMP_Text mensagem;

    [Header("Foto")]
    public Image fotoMensagem;

    [Header("Resposta")]
    public TMP_Text resposta01;
    public TMP_Text resposta02;
    public TMP_Text resposta03;
    public TMP_Text resposta04;

    [Header("Corações")]
    public Image coracao01;
    public Image coracao02;
    public Image coracao03;
    public Image coracao04;
    public Image coracao05;
    public Image coracao06;
    public Image coracao07;
    public Image coracao08;
    public Image coracao09;
    public Image coracao10;

    public int indexP = 0;

    private Color original;
    private Color full;

    private void Start()
    {
        original = new Color(coracao01.color.r, coracao01.color.g, coracao01.color.b, 0.25f);
        full = new Color(coracao01.color.r, coracao01.color.g, coracao01.color.b, 1f);
        SetStaticInfo();
        SetInfoSemanal();
        SetRespostas();
    }

    public void SetStaticInfo()
    {
        nome.text = personagem.nome;
        arroba.text = personagem.arroba;
        arrobaResposta.text = personagem.arroba;
    }

    public void SetInfoSemanal()
    {
        Debug.Log(GameManager.Instance.nomePlayer);
        string mensagemNome = GameManager.Instance.MudarNome(personagem.perguntas[indexP].mensagem);
        semana.text = personagem.perguntas[indexP].semana;
        mensagem.text = mensagemNome;
        fotoMensagem.sprite = personagem.perguntas[indexP].foto;
    }

    public void SetRespostas()
    {
        resposta01.text = personagem.perguntas[indexP].pergunta01;
        resposta02.text = personagem.perguntas[indexP].pergunta02;
        resposta03.text = personagem.perguntas[indexP].pergunta03;
        resposta04.text = personagem.perguntas[indexP].pergunta04;
    }

    public void SetIndexP()
    {
        indexP += 1;
    }

    public void EscolherResposta(int index)
    {
        if (index == 1)
        {
            GameManager.Instance.SetFaseCount(personagem.perguntas[indexP].valorPergunta01);
        }
        else if (index == 2)
        {
            GameManager.Instance.SetFaseCount(personagem.perguntas[indexP].valorPergunta02);
        }
        else if (index == 3)
        {
            GameManager.Instance.SetFaseCount(personagem.perguntas[indexP].valorPergunta03);
        }
        else if (index == 4)
        {
            GameManager.Instance.SetFaseCount(personagem.perguntas[indexP].valorPergunta04);
        }
    }

    public void SetCoracoes()
    {
        
        if (GameManager.Instance.faseCount == 0)
        {
            coracao01.color = original;
            coracao02.color = original;
            coracao03.color = original;
            coracao04.color = original;
            coracao05.color = original;
            coracao06.color = original;
            coracao07.color = original;
            coracao08.color = original;
            coracao09.color = original;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 1)
        {
            coracao01.color = full;
            coracao02.color = original;
            coracao03.color = original;
            coracao04.color = original;
            coracao05.color = original;
            coracao06.color = original;
            coracao07.color = original;
            coracao08.color = original;
            coracao09.color = original;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 2)
        {
            coracao01.color = full;
            coracao02.color = full;
            coracao03.color = original;
            coracao04.color = original;
            coracao05.color = original;
            coracao06.color = original;
            coracao07.color = original;
            coracao08.color = original;
            coracao09.color = original;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 3)
        {
            coracao01.color = full;
            coracao02.color = full;
            coracao03.color = full;
            coracao04.color = original;
            coracao05.color = original;
            coracao06.color = original;
            coracao07.color = original;
            coracao08.color = original;
            coracao09.color = original;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 4)
        {
            coracao01.color = full;
            coracao02.color = full;
            coracao03.color = full;
            coracao04.color = full;
            coracao05.color = original;
            coracao06.color = original;
            coracao07.color = original;
            coracao08.color = original;
            coracao09.color = original;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 5)
        {
            coracao01.color = full;
            coracao02.color = full;
            coracao03.color = full;
            coracao04.color = full;
            coracao05.color = full;
            coracao06.color = original;
            coracao07.color = original;
            coracao08.color = original;
            coracao09.color = original;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 6)
        {
            coracao01.color = full;
            coracao02.color = full;
            coracao03.color = full;
            coracao04.color = full;
            coracao05.color = full;
            coracao06.color = full;
            coracao07.color = original;
            coracao08.color = original;
            coracao09.color = original;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 7)
        {
            coracao01.color = full;
            coracao02.color = full;
            coracao03.color = full;
            coracao04.color = full;
            coracao05.color = full;
            coracao06.color = full;
            coracao07.color = full;
            coracao08.color = original;
            coracao09.color = original;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 8)
        {
            coracao01.color = full;
            coracao02.color = full;
            coracao03.color = full;
            coracao04.color = full;
            coracao05.color = full;
            coracao06.color = full;
            coracao07.color = full;
            coracao08.color = full;
            coracao09.color = original;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 9)
        {
            coracao01.color = full;
            coracao02.color = full;
            coracao03.color = full;
            coracao04.color = full;
            coracao05.color = full;
            coracao06.color = full;
            coracao07.color = full;
            coracao08.color = full;
            coracao09.color = full;
            coracao10.color = original;
        }
        else if (GameManager.Instance.faseCount == 10)
        {
            coracao01.color = full;
            coracao02.color = full;
            coracao03.color = full;
            coracao04.color = full;
            coracao05.color = full;
            coracao06.color = full;
            coracao07.color = full;
            coracao08.color = full;
            coracao09.color = full;
            coracao10.color = full;
        }
    }

    public void Responder(int resposta)
    {
        if (indexP < personagem.perguntas.Length - 1)
        {
            EscolherResposta(resposta);
            SetCoracoes();
            SetIndexP();
            SetInfoSemanal();
            SetRespostas();
            Debug.Log(GameManager.Instance.faseCount);
        }
        else
        {
            EscolherResposta(resposta);
            Debug.Log(GameManager.Instance.faseCount);
            if (GameManager.Instance.faseCount == 10)
            {
                GameManager.Instance.SetVitoria(true);
            }
            else
            {
                GameManager.Instance.SetVitoria(false);
            }
            SceneManager.LoadScene("Final");
        }
    }
}
