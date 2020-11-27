using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    public Dealer Dealer;

    private List<Card> playerDeck = new List<Card>();

    private void Start()
    {
        playerDeck = Dealer.GetPlayerDeck();
        var firstCard = Deck.GetCard(playerDeck);
        Debug.Log($"Player : {firstCard.CardSuit}{firstCard.Number}");
    }
}
