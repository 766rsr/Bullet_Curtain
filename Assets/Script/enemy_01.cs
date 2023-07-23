using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_01 : MonoBehaviour
{
    public float EnemySpeed = 1.0f;
    public GameObject b_e;
    public float cd;
    public int hp=6;

    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3( Random.Range(-3,3), 6.4f , 0 );
        bullet_e.type=0;
        for(int i=0;i<36;i++){            
            Instantiate(b_e, transform.position,transform.rotation);
        }
        cd=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        float amountToMove = EnemySpeed * Time.deltaTime;
        transform.Translate(0, -1.0f*amountToMove, 0);

        if(transform.position.y <= -5)
            Destroy(this.gameObject);

        if(Time.time-cd >3){
            for(int i=0;i<36;i++){                
                Instantiate(b_e, transform.position,transform.rotation);
            }
            cd=Time.time;    
        }        
        
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.name == "bullet(Clone)")
        {
            Destroy(otherObject.gameObject);
            this.hp--;
            if(this.hp==0){
                Destroy(this.gameObject);
                player.PlayerScore += 100;
            }
        }
    }

}
