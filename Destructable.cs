using UnityEngine;

public class Destructable : MonoBehaviour
{
    public float Breaksize = 2f;
    public bool isglass = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerController p = coll.gameObject.GetComponent<PlayerController>();
            if (p.size >= Breaksize)
            {
                //GameObject.FindGameObjectWithTag
                if (!isglass){
                    audioManager.playSFX("Break");
                }else{
                    audioManager.playbystring("GlassBreak_sfx");
                }
                
                //play particle effect/animation
                Destroy(this.gameObject);
            }
        }
    }
}
