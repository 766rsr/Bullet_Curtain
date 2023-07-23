using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    public float PlayerSpeed = 9.0f;
    public int PlayerLife=30;  //生命值
    public static int PlayerScore;  //玩家分數
    public GameObject bu;
    public Animator ani;
   
    
    public float cd = 0.3f;
    public float cd_count;

    public float cd_d;

    public GameObject Explosion;

    public Transform p_t;
    public static Transform player_t;


    // Start is called before the first frame update
    void Start()
    {
        cd_count=Time.time;
        cd_d=Time.time;
        cd=0.3f;
        PlayerLife=30;
        PlayerScore=0;
    }

    // Update is called once per frame
    void Update()
    {
        
        float AmountToMove = PlayerSpeed * Time.deltaTime;
        if((transform.position.x>-4 && AmountToMove*Input.GetAxis("Horizontal") <= 0) || (transform.position.x<4 && AmountToMove*Input.GetAxis("Horizontal") >= 0)){
            if((transform.position.y<5.7 && AmountToMove*Input.GetAxis("Vertical") >= 0) || (transform.position.y>-3.7 && AmountToMove*Input.GetAxis("Vertical") <= 0)){
                transform.Translate(AmountToMove*Input.GetAxis("Horizontal"), AmountToMove* Input.GetAxis("Vertical") ,0);
            }            
        }
        

        if(Input.GetKey("z") && Time.time-cd_count>cd){
            cd_count=Time.time;
            Instantiate(bu, transform.position,transform.rotation);
            if(PlayerScore>1000){
                Instantiate(bu, transform.position,transform.rotation);
                Instantiate(bu, transform.position,transform.rotation);
            }
            if(PlayerScore>2500){
                Instantiate(bu, transform.position,transform.rotation);
                Instantiate(bu, transform.position,transform.rotation);
                Instantiate(bu, transform.position,transform.rotation);
                Instantiate(bu, transform.position,transform.rotation);
                Instantiate(bu, transform.position,transform.rotation);
                Instantiate(bu, transform.position,transform.rotation);                
            }
        }

        if(PlayerScore>2000){
            bullet.type=2;
        }else if(PlayerScore>1000){
            bullet.type=1;
        }else if(PlayerScore>250){
            cd=0.15f;
        }

        KeyCheck();
        player_t=p_t;
    }

    void OnTriggerEnter(Collider otherObject){
        if(otherObject.name == "bullet_e(Clone)"){
            Destroy(otherObject.gameObject);
        }
        if(otherObject.name == "enemy_01"){
            Destroy(otherObject.gameObject);
        }
        if(otherObject.name == "enemy_02"){
            Destroy(otherObject.gameObject);
        }

        if(Time.time-cd_d>0.2 && otherObject.name != "bullet(Clone)"){
            cd_d=Time.time;
            this.PlayerLife--;
            Instantiate(Explosion,this.transform.position,transform.rotation);
            if(PlayerLife==0) SceneManager.LoadScene("loss");
        }
    }

    void KeyCheck(){
        if(Input.GetKey(KeyCode.RightArrow))
            ani.SetBool("key_r", true);
        else
            ani.SetBool("key_r", false);
        if(Input.GetKey(KeyCode.LeftArrow))
            ani.SetBool("key_l", true);
        else
            ani.SetBool("key_l", false);
        if(Input.GetKey(KeyCode.UpArrow))
            ani.SetBool("key_f", true);
        else
            ani.SetBool("key_f", false);
        if(Input.GetKey(KeyCode.DownArrow))
            ani.SetBool("key_b", true);
        else
            ani.SetBool("key_b", false);
    }

    private GUIStyle guiStyle = new GUIStyle();
    void OnGUI(){
        guiStyle.fontSize = 50;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10,10,200,50), "Score: " + PlayerScore,guiStyle);
        GUI.Label(new Rect(10,70,200,50), "Life: " + PlayerLife,guiStyle);
    }
}
