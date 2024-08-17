using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slimeball : MonoBehaviour
{
    public float sizeI = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
    
        if (other.gameObject.tag == "Player"){
            PlayerController p = other.GetComponent<PlayerController>();

        if (p == null){
        Debug.Log("Error: non player object tagged as player");
        }else{
        
            p.increaseSize(sizeI);

            Destroy(this.gameObject);
        }

        }
    }
}
