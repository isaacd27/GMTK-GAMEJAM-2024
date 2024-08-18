using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public float Breaksize = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D coll){
        if (coll.gameObject.tag == "Player"){
            PlayerController p = coll.gameObject.GetComponent<PlayerController>();
            if(p.size > Breaksize){
                //GameObject.FindGameObjectWithTag
                AudioManager.playSFX("Break");
                //play particle effect/animation
                Destroy(this.gameObject);
            }
        }
    }
}
