using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    private List<Card> GameDeck = new List<Card>();

    private void Awake()
    {
        GameStart();
    }

    public List<Card> GetPlayerDeck()
    {
        var playerDeck = new List<Card>();
        for (int i = 0; i < CardHelper.CardMax / 2; i++)
        {
            playerDeck.Add(GameDeck[i]);
        }
        return playerDeck;
    }

    public List<Card> GetCPUDeck()
    {
        var cpuDeck = new List<Card>();
        for (int i = CardHelper.CardMax / 2; i < CardHelper.CardMax; i++)
        {
            cpuDeck.Add(GameDeck[i]);
        }
        return cpuDeck;
    }

    public void GameStart()
    {
        GameDeck = Deck.GetDeck();
        GameDeck = Deck.ShuffleDeck(GameDeck);
    }
}
