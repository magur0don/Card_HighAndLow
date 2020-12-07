﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameJudge : MonoBehaviour
{
    public Text JudgeText;

    public void GameJudgeTextInit()
    {
        JudgeText.text = string.Empty;
    }

    public void GameJudgeTextView(bool isWin)
    {
        if (isWin)
        {
            JudgeText.text = "Win";
        }
        else
        {
            JudgeText.text = "Lose";
        }
    }

    public void GameResultTextView(bool isWin)
    {
        if (isWin)
        {
            JudgeText.text = "Playerの勝利です";
        }
        else
        {
            JudgeText.text = "CPUの勝ちです";
        }
    }
}
