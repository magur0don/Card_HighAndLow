using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighAndLowSequence : MonoBehaviour
{
    private enum GameSequence
    {
        Invalide,
        Init,
        Start,
        Deal,
        PlayerJudge,
        Show
    }

    private GameSequence gameSequence = GameSequence.Invalide;

    public Dealer dealer;

    public PlayerCard playerCard;

    public CPUCard cpuCard;

    public PlayerJudge playerJudge;

    void Update()
    {
        switch (gameSequence)
        {

            case GameSequence.Invalide:

                gameSequence = GameSequence.Init;
                break;

            case GameSequence.Init:

                // PlayerとCPUにデッキをディールする
                playerCard.SetPlayerDeck();
                cpuCard.SetCPUDeck();
                gameSequence = GameSequence.Deal;
                break;

            case GameSequence.Start:

                gameSequence = GameSequence.Deal;
                break;
            case GameSequence.Deal:

                // PlayerとCPUにカードをディールする
                playerCard.SetPlayerCard();
                cpuCard.SetCPUCard();

                Debug.Log(playerCard.playerCard.Number);
                Debug.Log(cpuCard.cpuCard.Number);
                gameSequence = GameSequence.PlayerJudge;
                break;
            case GameSequence.PlayerJudge:

                // 数を予想してボタンを押したらShowに進む
                if (playerJudge.Judge)
                {
                    gameSequence = GameSequence.Show;
                }
                break;
            case GameSequence.Show:

                // プレイヤーが確認したらStartに戻って次のゲーム
                cpuCard.ShowCPUCard();

                if (playerJudge.High)
                {
                    if (playerCard.playerCard.Number > cpuCard.cpuCard.Number)
                    {
                        Debug.Log("勝ち");
                    }
                    else
                    {
                        Debug.Log("負け");
                    }
                }
                else
                {
                    if (playerCard.playerCard.Number < cpuCard.cpuCard.Number)
                    {
                        Debug.Log("勝ち");
                    }
                    else
                    {
                        Debug.Log("負け");
                    }
                }
                playerJudge.Judge = false;
                gameSequence = GameSequence.Start;
                break;
        }
    }
}
