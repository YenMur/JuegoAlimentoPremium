using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadPreviousScene()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        if(escenaActual > 0)
        {
            SceneManager.LoadScene(escenaActual - 1);
        }
        else
        {
            Debug.Log("No hay escena anterior.");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
