using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartScreenUI : MonoBehaviour
{
    public static StartScreenUI Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Display()
    {
        gameObject.SetActive(true);
        Controller.Instance.DisplayCursor(true);

    }
}
