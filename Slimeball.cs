using UnityEngine;

public class Slimeball : MonoBehaviour
{
    public float sizeI = 1.0f;
    public float massI = 0.2f;


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
                audioManager.playSFX("Pickup");
                p.increaseSize(sizeI);
                p.increaseMass(massI);
                Destroy(this.gameObject);

            }
        }
    }
}
