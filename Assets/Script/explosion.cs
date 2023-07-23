using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float cd;
    // Start is called before the first frame update
    void Start()
    {
        cd=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-cd>5){
            Destroy(this.gameObject);
        }
    }
}
