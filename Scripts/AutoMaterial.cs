using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMaterial : MonoBehaviour
{
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        //float scaleX = Mathf.Lerp(0.1f,1f,Time.deltaTime);
        float OffsetX = Mathf.Sin(Time.time / 20) * 0.5f;
        float OffsetY = Mathf.Cos(Time.time / 20) * 0.5f;
        //rend.material.mainTextureScale = new Vector2(scaleX,10f);
        rend.material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
