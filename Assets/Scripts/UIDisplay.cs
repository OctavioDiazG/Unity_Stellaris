//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Pause Menu")]
    public GameObject pauseMenuUI;
    //[SerializeField] bool GameIsPaused;

    //Uribes Request, Win game after 30000 points
    [Header("Victory Panel")] 
    public GameObject victoryPanel;
    public GameObject pauseButton;
    public GameObject uiPanel;
    //[SerializeField] bool gameIsVictory;
    //Uribes Request, Win game after 30000 points

    //Uribes Request, Win game after 30000 points
    public void Victory()
    {
        Debug.Log("Entramos en Pantalla de Victoria");
        victoryPanel.SetActive(true);
        pauseButton.SetActive(false);
        uiPanel.SetActive(false);
        Time.timeScale = 0f;
        //gameIsVictory = true;
    }
    //Uribes Request, Win game after 30000 points

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //GameIsPaused = false;
        //Cursor.visible = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        //GameIsPaused = true;
        //Cursor.visible = true;
    }

    private void Awake() 
    {    
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    } 
    
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("0000000");
    }
}
