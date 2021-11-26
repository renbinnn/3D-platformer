using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    float speed = 5f;
    float height = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
         
    }


    void Update()
    {
        //float newY = Mathf.Sin(Time.time * speed);
        //transform.position = new Vector3(transform.position.x, newY, transform.position.z) * height;
    }

}