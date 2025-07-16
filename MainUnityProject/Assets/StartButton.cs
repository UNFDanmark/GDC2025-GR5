using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject UIBLOCKER;
    public bool pluh;
    
    
    public void StartGame()
    {
        UIBLOCKER.SetActive(false);
        GameManagerScript.Instance.SetGameState(GameState.SpawningWave);
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }

    public void BackToStart()
    {
        print("PRINT");
        GameManagerScript.Instance.SetGameState(GameState.Menu);
    }
    
}
