using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float starttime;
    public float[] enemy_cd = new float[10];
    public float[] enemy_count = new float[10];
    

    public GameObject[] enemy = new GameObject[10];
    // Start is called before the first frame update
    void Start()
    {
        starttime=Time.time;
        for(int i=0;i<10;i++){
            enemy_count[i]=Time.time;

            if(i<4){
                enemy_cd[i]=starttime+Random.Range(50,100)/10;
            }else{
                enemy_cd[i]=starttime+Random.Range(30,80)/10;
            }            
        }

        enemy_cd[0]=0;
        enemy_cd[1]=0;
        enemy_cd[4]=starttime+3;
        enemy_cd[5]=starttime+3;        
    }

    // Update is called once per frame
    void Update()
    {
        int i;
        if(Time.time-starttime<30){
            for(i=0;i<4;i++){
                if(Time.time-enemy_count[i]>enemy_cd[i]){
                    enemy_count[i]=Time.time;
                    enemy_cd[i]=Random.Range(50,100)/10;
                    Instantiate(enemy[0], transform.position,transform.rotation);
                }                
            }
        }else if(Time.time-starttime<60){
            for(i=0;i<4;i++){
                if(Time.time-enemy_count[i]>enemy_cd[i]){
                    enemy_count[i]=Time.time;
                    enemy_cd[i]=Random.Range(25,50)/10;
                    Instantiate(enemy[0], transform.position,transform.rotation);
                }                
            }
        }else{
            if(enemy[2].transform.position.y>3.7f) 
                enemy[2].transform.Translate(0, -1.5f*Time.deltaTime, 0);
            else
                if(enemy_03.boss==0) enemy_03.boss=1;
        }
        
        for(i=4;i<10;i++){
            if(Time.time-enemy_count[i]>enemy_cd[i]){
                enemy_count[i]=Time.time;
                enemy_cd[i]=Random.Range(30,80)/10;
                Instantiate(enemy[1], transform.position,transform.rotation);
            }                
        }        
        
    }
}
