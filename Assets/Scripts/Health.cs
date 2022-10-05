using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] int penaltyScore = -50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    //[SerializeField] GameObject drop;
    //private int dropRate = 25; //25% chance of dropping PowerUp
    //private int dropChance;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    [SerializeField] private bool isDistructable = false;

    void Awake() 
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        PowerUps powerUps = other.GetComponent<PowerUps>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            damageDealer.Hit();
        }

        if (powerUps != null)
        {
            TakePowerup(powerUps.GetLife());
            powerUps.PickupPowerup();
        }
        
    }

    public int GetHealth()
    {
        return health;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (isPlayer)
        {
            scoreKeeper.ModifyScore(penaltyScore);
        }
        if(health <= 0)
        {
            Die();
        }
    }

    public void TakePowerup(int life)
    {
        /*
        if (health > 1 && health <= 50 )
        {
            health += life;
        }
        else if (health == 60)
        {
            health += life - 10;
        }
        */
        
        //Uribes Request, Give player health after 10000 points
        health = 70;
        //Uribes Request, Give player health after 10000 points

    }


    void Die()
    {
        
        //Generate random number between 0 and 1
        //enemy drops Health after death
        //dropChance = Random.Range(24, 26);
        //Debug.Log(dropChance);
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
            
            //Uribes Request, Give player health after 10000 points
            scoreKeeper.ScoreReward();
            //Uribes Request, Give player health after 10000 points
            
            /*if (dropChance == dropRate)
            {
                Instantiate(drop, gameObject.transform.position, Quaternion.identity);
            }*/
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
