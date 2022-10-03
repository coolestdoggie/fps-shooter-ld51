using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public static LoseScreen Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Display()
    {
        gameObject.SetActive(true);
        Controller.Instance.DisplayCursor(true);
        UIAudioPlayer.PlayPositive();
        GameSystem.Instance.StopTimer();
    }
}
