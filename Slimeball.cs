using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slimeball : MonoBehaviour
{
    public float sizeI = 1.0f;
    public float massI = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
    
        if (other.gameObject.tag == "Player"){
            PlayerController p = other.GetComponent<PlayerController>();

        if (p == null){
        Debug.Log("Error: non player object tagged as player");
        }else{
            AudioManager.playSFX("Pickup");
            p.increaseSize(sizeI);
            p.increaseMass(massI);

            Destroy(this.gameObject);
        }

        }
    }
}
