using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_e : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletSpeed = 3.0f;
    public static int type=0;
    public static float angle=0;

    void Start()
    {
        if(type==0){
            transform.Rotate(0, 0,  Random.Range(0,360));
        }else if(type==1){
            transform.Rotate(0, 0,  angle);
            angle+=10;
            if(angle==360) angle=0;
        }else if(type==2){
            transform.Rotate(0, 0,  angle);
            angle+=1.5f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float amountToMove = BulletSpeed * Time.deltaTime;
        transform.Translate(0, amountToMove, 0);
        if(transform.position.y >= 6.5 || transform.position.y<=-5) Destroy(gameObject);
        if(transform.position.x >= 4 || transform.position.x<=-4) Destroy(gameObject);
        
    }
}
