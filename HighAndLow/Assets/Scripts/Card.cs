using System.Collections;
using System.Collections.Generic;


public class Card
{
    public enum Suit
    {
        Invalid = -1,
        Club,
        Dia,
        Heart,
        Spade,
        Max
    }

    public Suit CardSuit = Suit.Invalid;

    public int Number = 0;

    public Card(Suit suit, int number)
    {
        this.CardSuit = suit;
        this.Number = number;
    }
}
