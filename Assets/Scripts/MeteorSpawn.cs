using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
//Uribes Request, MeteorRain
public class MeteorSpawn : MonoBehaviour
{
    [Header("Meteor List")] 
    public GameObject[] meteor;
    [Header("Meteor Preferences")] 
    public float meteorLifeTime = 2f;
    public float spawnRate = 2f;
    public float rotationSpeed = 50f;
    
    //private bool _bCanCreateMeteor = true; // bool to stop the spawning
    
    AudioPlayer _audioPlayer;

    void Awake() 
    {
        _audioPlayer = FindObjectOfType<AudioPlayer>();
    }
     
    void Start() 
    {
        StartCoroutine(CreateMeteor());
    }
     
    IEnumerator CreateMeteor()
    {
        while(true)
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(0, meteor.Length);
            GameObject instance = Instantiate(meteor[randomNumber], new Vector3(Random.Range(-4,4), Random.Range(10,11), 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            Destroy(instance, meteorLifeTime);
            //yield return null;
        }
        //yield return null;
    }
}
//Uribes Request, MeteorRain
