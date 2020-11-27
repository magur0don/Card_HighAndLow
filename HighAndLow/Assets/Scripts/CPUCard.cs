using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUCard : MonoBehaviour
{
    public Dealer Dealer;

    private List<Card> cpuDeck = new List<Card>();

    private void Start()
    {
        cpuDeck = Dealer.GetCPUDeck();
        var firstCard = Deck.GetCard(cpuDeck);
        Debug.Log($"CPU : {firstCard.CardSuit}{firstCard.Number}");
    }
}
