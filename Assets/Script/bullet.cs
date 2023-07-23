using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float BulletSpeed = 15.0f;
    public static int type=0;


    // Start is called before the first frame update
    void Start()
    {
        if(type==1) transform.Rotate(0, 0,  Random.Range(-10,10)/10);
        if(type==2) transform.Rotate(0, 0,  Random.Range(-50,50)/10);
    }

    // Update is called once per frame
    void Update()
    {
        float amountToMove = BulletSpeed * Time.deltaTime;
        transform.Translate(0, amountToMove, 0);
        if(transform.position.y >= 6.5) Destroy(gameObject);
        if(transform.position.x >= 4 || transform.position.x<=-4) Destroy(gameObject);
    }
}
