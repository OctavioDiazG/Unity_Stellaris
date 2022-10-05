using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSettings : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationSpeed));
        rb.AddTorque(40 * Time.deltaTime);
    }
}
