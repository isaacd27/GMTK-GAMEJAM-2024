using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Transform ExitLocale; //recommend attaching  debug sprite during testing
    public float maxSize = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            PlayerController p = other.GetComponent<PlayerController>();
            if (p == null)
            {
                Debug.Log("Error: non player object tagged as player");
            }
            else
            {
            
            if(p.size <= maxSize){
                p.transform.position = ExitLocale.transform.position;
                //play schloop sound here
            }

            }
        }
    }
}
