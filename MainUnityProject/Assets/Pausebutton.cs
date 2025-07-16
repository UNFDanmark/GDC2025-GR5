using UnityEngine;
using UnityEngine.UI;

public class Pausebutton : MonoBehaviour
{
    public Sprite pauseSprite;
    public Sprite PlaySprite;
    public Image btnImage;

    public bool isPaused;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            btnImage.sprite = pauseSprite;
        }
        else
        {
            Time.timeScale = 1f;
            btnImage.sprite = PlaySprite;
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
    }
}
