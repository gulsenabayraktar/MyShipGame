using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCode : MonoBehaviour
{
    float Speed = 800f;
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * (Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
