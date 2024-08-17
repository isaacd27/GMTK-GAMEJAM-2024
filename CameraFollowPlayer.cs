using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Camera c;
    private Vector3 offset = new Vector3(0, 2, -10);

    public float zoomOffset;

    // Start is called before the first frame update
    void Start()
    {
        //if player is not set, will set it as the first object tagged 'player'
        if (player == null){
            player = GameObject.FindWithTag("Player");
        }
        c = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        c.orthographicSize = zoomOffset + player.GetComponent<PlayerController>().size;

    }
}
