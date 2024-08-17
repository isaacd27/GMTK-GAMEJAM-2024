using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Sponge : MonoBehaviour
{
    //if the sponge only grows in one dimension or not.
    public bool oneDir = false;
    public float size = 1f;
    public float maxsize = 10f;
    //if the sponge only grows in one scale, does it grow up/down or left/right?
    public bool isy = true;

    public float getSize(){
        return size;
    }

    public void increaseSize(float s){
        size += s;
    }

    public void decreaseSize(float s){
        size -= s;
    }

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

            if (p != null){
                if(p.size > 1f){
                    //change below later so player size is reduced to 1 or reduced by the maxsize
                    size = p.size /2;
                    p.decreaseSize(p.size/2);

                    if(p.size < 1){
                        Debug.Log("Reduced to smaller than size 1");
                    }

                    if(size > maxsize){
                        // prevents size from being lost to the ether, can be removed when inital size increase is changed.
                        p.increaseSize(size - maxsize);
                        size = maxsize;
                    }


                    if(oneDir){
                        if(isy){
                        gameObject.transform.localScale = new Vector3(1, size);
                        }else{
                        gameObject.transform.localScale = new Vector3(size, 1);
                        }
                    }else{
                    gameObject.transform.localScale = new Vector3(size, size);
                    }


            }

            }
        }
    }
}
