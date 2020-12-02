using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUCard : MonoBehaviour
{
    public Dealer Dealer;

    private List<Card> cpuDeck = new List<Card>();

    public Card cpuCard;

    public void SetCPUDeck()
    {
        cpuDeck = Dealer.GetCPUDeck();
    }

    public void SetCPUCard()
    {
        cpuCard = Deck.GetCard(cpuDeck);
        Debug.Log(cpuCard.Number);
    }
}
