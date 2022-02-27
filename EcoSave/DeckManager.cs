using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckManager : MonoBehaviour
{
    public List<Card> cartasPossiveis = new List<Card>();
    private Card[] cartasMao;
    private GameObject[] cartasGO;

    [SerializeField] private TMP_Text txtMaxCards;

    private int quantCartasSolucao = 0;

    private void Awake()
    {
        cartasGO = GameObject.FindGameObjectsWithTag("Card");
        cartasMao = new Card[cartasGO.Length];
    }

    void Start()
    {
        txtMaxCards.text = cartasPossiveis.Count.ToString();
        EmbaralharCartas();
        DistribuirCartas();
    }

    private void EmbaralharCartas()
    {
        System.Random random = new System.Random();
        cartasPossiveis = cartasPossiveis.OrderBy(item => random.Next()).ToList();
    }

    private void EmbaralharCartasMao()
    {
        List<Card> indicesRemove = new List<Card>();

        // Separa cartas para a mão e evita mais que duas soluções
        int maxCartaSolucao = 2;

        for(int a=0; a<cartasPossiveis.Count; a += 1)
        {
            for (int b=0; b<cartasMao.Length; b += 1)
            {
                if (cartasMao[b] != null) continue;

                if (cartasPossiveis.Count - maxCartaSolucao > maxCartaSolucao && cartasPossiveis[a].tipoCarta == TipoCartaEnum.Solucao)
                {
                    if (quantCartasSolucao == maxCartaSolucao) continue;

                    quantCartasSolucao += 1;
                }

                cartasMao[b] = cartasPossiveis[a];
                indicesRemove.Add(cartasMao[b]);
                break;
            }
        }

        // Remove cartas que já foram para a mão
        foreach (Card carta in indicesRemove) cartasPossiveis.Remove(carta);

        txtMaxCards.text = cartasPossiveis.Count.ToString();
    }

    public void DistribuirCartas()
    {
        EmbaralharCartasMao();

        for (int a = 0; a<cartasGO.Length; a+=1)
        {
            if (cartasMao[a] == null) continue;

            Card carta = cartasMao[a];
            InstanciarCarta(carta, cartasGO[a]);
        }
    }

    public void RemoverCartaMao(GameObject cartaGO)
    {
        for (int a = 0; a < cartasGO.Count(); a+=1)
        {
            if (cartasGO[a] == cartaGO)
            {
                Debug.Log("Remover carta: " + a);
                cartasMao[a] = null;
                return;
            }
        }
    }

    private void InstanciarCarta(Card carta, GameObject cartaGO)
    {
        CardManager manager = cartaGO.GetComponent<CardManager>();
        manager.MudarCarta(carta);        
        //cardManager.VirarCarta();
    }

    public void VirarFundoCartas()
    {
        foreach (GameObject cartaGO in cartasGO)
        {
            CardManager manager = cartaGO.GetComponent<CardManager>();
            manager.virarFundo();
        }
    }
}
