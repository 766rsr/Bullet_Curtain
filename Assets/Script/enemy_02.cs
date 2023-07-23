using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy_02 : MonoBehaviour
{
    // Start is called before the first frame update
    public float EnemySpeed = 2f;
    public float cd;

    

    void Start()
    {
        transform.position = new Vector3( Random.Range(-3,3), 6.4f , 0 );
        cd=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float amountToMove = EnemySpeed * Time.deltaTime;

        if(Time.time-cd<2.5) GetComponent<Transform>().LookAt(player.player_t);
        if(Time.time-cd<1 || Time.time-cd>2.5) transform.Translate(0, 0,(Time.time-cd)*amountToMove);        

        if(transform.position.y <= -5 || transform.position.y >= 7) Destroy(this.gameObject);
        if(transform.position.x >= 4 || transform.position.x<=-4) Destroy(this.gameObject);        
        
    }
    void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.name == "bullet(Clone)")
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
            player.PlayerScore += 20;
        }
    }
}
