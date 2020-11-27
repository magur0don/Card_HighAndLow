using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighAndLowSequence : MonoBehaviour
{
    private enum GameSequence
    {
        Invalide,
        Start,
        Deal,
        PlayerJudge,
        Show
    }

    private GameSequence gameSequence = GameSequence.Invalide;
    
    void Update()
    {
        switch (gameSequence) {

            case GameSequence.Invalide:

                gameSequence = GameSequence.Start;
                break;
            case GameSequence.Start:

                gameSequence = GameSequence.Deal;
                break;
            case GameSequence.Deal:

                // PlayerとCPUにデッキをディールする
                
                gameSequence = GameSequence.PlayerJudge;
                break;
            case GameSequence.PlayerJudge:

                // 数を予想してボタンを押したらShowに進む

                gameSequence = GameSequence.Show;
                break;
            case GameSequence.Show:

                // プレイヤーが確認したらStartに戻って次のゲーム

                gameSequence = GameSequence.Start;
                break;
        }
    }
}
