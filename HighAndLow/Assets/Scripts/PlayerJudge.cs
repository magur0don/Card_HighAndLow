using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJudge : MonoBehaviour
{
    public bool High = false;
    
    public void HighJudge()
    {
        High = true;
    }

    public void LowJudge()
    {
        High = false;
    }
}
