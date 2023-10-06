using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoColor : MonoBehaviour
{
    void Start()
    {
        Material mymat = GetComponent<MeshRenderer>().material;
        mymat.SetColor("_EmissionColor", Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f));
    }

   
    void Update()
    {

    }
}
