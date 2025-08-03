using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpMenu : MonoBehaviour {

    public void OnStartClick() {

        SceneManager.LoadScene("SampleScene");

    }

    public void OnQuitQuit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}

