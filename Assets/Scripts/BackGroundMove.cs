using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour
{
    private Renderer render;
    [SerializeField] private Vector2 velocity = new Vector2(-1f,0);
    void Start()
    {
        render = GetComponent<Renderer>();
    
    }

    void Update()
    {
        Vector2 textureOffset = new Vector2(velocity.x * Time.time, velocity.y * Time.time);
        render.material.mainTextureOffset = textureOffset;
    }
}
