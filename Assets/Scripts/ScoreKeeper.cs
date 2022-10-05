using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int score;
    //Uribes Request, Win game after 30000 points
    public UIDisplay uiDisplay;
    //Uribes Request, Win game after 30000 points


    //Uribes Request, Give player health after 10000 points
    private int scoreReward = 10000;
    public Player playerPos ;
    [SerializeField] GameObject drop;
    //Uribes Request, Give player health after 10000 points


    static ScoreKeeper instance;

    void Awake()
    {
        //ManageSingleton();
    }

    void Start()
    {
        //Uribes Request, Win game after 30000 points
        uiDisplay = FindObjectOfType<UIDisplay>();
        playerPos = FindObjectOfType<Player>();
        //Uribes Request, Win game after 30000 points
    }

    /* void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }*/

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        //Debug.Log (score);
    }
    
    //Uribes Request, Give player health after 10000 points
    public void ScoreReward()
    {
        Vector3 iPlayerPosPosition = playerPos.gameObject.transform.position + Vector3.up;
        if (score >= scoreReward)
        {
            scoreReward += 10000;
            //Debug.Log(scoreReward);
            Instantiate(drop, iPlayerPosPosition, Quaternion.identity);
            //Debug.Log("VIDAAAAAA");
        }

        //Uribes Request, Win game after 30000 points
        if (score >= 30000)
        {
            Debug.Log("Ganamos");
            //uiDisplay.victoryPanel.SetActive(true);
            uiDisplay.Victory();
        }
        //Uribes Request, Win game after 30000 points
    }
    //Uribes Request, Give player health after 10000 points

    public void ResetScore()
    {
        score = 0;
        //Uribes Request, Win game after 30000 points
        uiDisplay = FindObjectOfType<UIDisplay>();
        playerPos = FindObjectOfType<Player>();
        //Uribes Request, Win game after 30000 points
    }

}
