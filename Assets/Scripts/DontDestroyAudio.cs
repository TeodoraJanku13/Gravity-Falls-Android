using UnityEngine.SceneManagement;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    int currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 0 || currentScene == 1 || currentScene == 5)
        {
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
