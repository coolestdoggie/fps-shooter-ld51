using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreUI : MonoBehaviour
{
    public static FinalScoreUI Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Display()
    {
        gameObject.SetActive(true);
        Controller.Instance.DisplayCursor(true);
        UIAudioPlayer.PlayNegative();
        GameSystem.Instance.StopTimer();
        
    }
}
