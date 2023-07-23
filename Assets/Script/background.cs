using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    // Start is called before the first frame update

    public float ScrollSpeed = 0.02f;
    private Renderer REN;

    void Start()
    {
        this.REN = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time*this.ScrollSpeed);
        this.REN.material.mainTextureOffset = offset;
        
    }
}
