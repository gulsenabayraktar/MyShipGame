using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TNTCollision : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    void Start()
    {

    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                ParticleSystem particleEffect = Instantiate(explosionParticle, transform.position,transform.rotation);
                Destroy(particleEffect,1f);
                Destroy(gameObject);
                break;
            default:
                break;

        }
    }
}
