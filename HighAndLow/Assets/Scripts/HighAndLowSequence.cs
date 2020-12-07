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
        Show,
        Result
    }

    private GameSequence gameSequence = GameSequence.Invalide;

    public Dealer dealer;

    public PlayerCard playerCard;

    public CPUCard cpuCard;

    public PlayerJudge playerJudge;

    public GameJudge gameJudge;

    public ScoreViewer scoreViewer;

    public float waitTime = 1f;

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
                gameJudge.GameJudgeTextInit();
                gameSequence = GameSequence.Deal;
                break;
            case GameSequence.Deal:

                // PlayerとCPUにカードをディールする
                playerCard.SetPlayerCard();
                cpuCard.SetCPUCard();
                
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

                bool isWin = false;

                if (playerJudge.High)
                {
                    if (playerCard.playerCard.Number > cpuCard.cpuCard.Number)
                    {
                        isWin = true;
                    }
                }
                else
                {
                    if (playerCard.playerCard.Number < cpuCard.cpuCard.Number)
                    {
                        isWin = true;
                    }
                }

                gameJudge.GameJudgeTextView(isWin);
                waitTime -= Time.deltaTime;
                if (waitTime < 0f)
                {
                    playerJudge.Judge = false;

                    if (dealer.GameEnd(playerCard.GetPlayerDeck()))
                    {
                        gameSequence = GameSequence.Result;
                    }
                    else
                    {
                        gameSequence = GameSequence.Start;
                    }

                    scoreViewer.AddScoreViewer(isWin);
                    waitTime = 1f;
                }

                break;

            case GameSequence.Result:

                bool isResultWin = false;

                if (scoreViewer.playerScore > scoreViewer.cpuScore)
                {
                    isResultWin = true;
                }
                gameJudge.GameResultTextView(isResultWin);
                break;

        }
    }

}
