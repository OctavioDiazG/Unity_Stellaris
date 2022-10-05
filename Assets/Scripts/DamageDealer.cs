using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] bool isBullet = false;
    [SerializeField] bool isAsteroid = false;
    

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    //Uribes Request, Bullets Will Destroy Enemy Bullets
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet") && isBullet)
        {
            Destroy(gameObject); 
            Destroy(col.gameObject);
            //Debug.Log("se destruye la bala");
        }
        if (col.gameObject.CompareTag("Asteroid") && isAsteroid)
        {
            Destroy(gameObject); 
            Destroy(col.gameObject);
            //Debug.Log("se destruye la bala");
        }
    }
    //Uribes Request, Bullets Will Destroy Enemy Bullets

}
