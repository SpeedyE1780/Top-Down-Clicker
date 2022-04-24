using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;    
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += Vector2.down * Time.deltaTime;
    }
}
