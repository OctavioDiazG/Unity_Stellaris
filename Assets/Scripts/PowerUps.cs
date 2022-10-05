using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] int life = 70;

    public int GetLife()
    {
        return life;
    }

    public void PickupPowerup()
    {
        Destroy(gameObject);
    }
}