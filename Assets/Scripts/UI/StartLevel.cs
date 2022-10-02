using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public void StartGame()
    {
        // UIAudioPlayer.PlayPositive();
        // GameSystem.Instance.StartTimer();
        // gameObject.SetActive(false);
        // Controller.Instance.DisplayCursor(false);
        GameSystem.Instance.StartGame();
        StartScreenUI.Instance.gameObject.SetActive(false);

    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}