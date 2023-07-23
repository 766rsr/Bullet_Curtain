using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_03 : MonoBehaviour
{
    public float enmove=1;
    public static int boss=0;
    public GameObject b_e;
    public float cd;
    public int i=0,j;

    public int hp=2000;
    
    // Start is called before the first frame update
    void Start()
    {
        cd=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(enmove*Time.deltaTime, 0,0);
        if(transform.position.x>2.7f) enmove=-1;
        if(transform.position.x<-2.7f) enmove=1;

        if(Time.time-cd>1){
            cd=Time.time;
            if(boss==1){
                bullet_e.type=1;
                for(j=0;j<36;j++){            
                    Instantiate(b_e, transform.position,transform.rotation);
                }
                i++;
                if(i>3) {
                    i=0;
                    boss=2;
                }
            }else if(boss==2){
                bullet_e.type=2;
                bullet_e.angle=Random.Range(120,210);
                for(j=0;j<20;j++){            
                    Instantiate(b_e, transform.position,transform.rotation);
                }
                i++;
                if(i>3) {
                    i=0;
                    boss=1;
                }
            }
        }
        
    }

    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.name == "bullet(Clone)")
        {
            Destroy(otherObject.gameObject);
            this.hp--;
            if(this.hp<=0){
                Destroy(this.gameObject);
                player.PlayerScore += 10000;
                SceneManager.LoadScene("win");
            }
        }
    }
}
