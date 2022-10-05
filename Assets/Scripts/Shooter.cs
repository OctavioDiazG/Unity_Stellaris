using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 3f;
    [SerializeField] float baseFirinRrate = 0.2f;
    private float y;
    
    [Header("AI")]
    [SerializeField] bool useAI;
    //Uribes Request, Doble shooting
    [SerializeField] private bool isSpecial;
    //Uribes Request, Doble shooting
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    [HideInInspector] public bool isFiring;

    Coroutine _firingCoroutine;

    AudioPlayer _audioPlayer;

    void Awake() 
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && _firingCoroutine == null)
        {
            //Uribes Request, Doble shooting
            if (isSpecial)
            {
                _firingCoroutine = StartCoroutine(FireContinuously());
            }
            //Uribes Request, Doble shooting
            _firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
            _firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            if (useAI)
            {
                y = 0;
            }
            else
            {
                y = 1;
            }
            GameObject instance = Instantiate(projectilePrefab, transform.position + new Vector3(0,y,0), Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFirinRrate -firingRateVariance, baseFirinRrate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
            
            _audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
