using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public float reqSize;

    //this script is the same thing as sceneloader but it happens when a trigger is entered.
    [SerializeField]
    private string Nextlevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //note: it's probably possible to have a level score display thing pop-up, sonic style.
        if (collision.CompareTag("Player"))
        {
            PlayerController p = collision.gameObject.GetComponent<PlayerController>();
            if (p.size >= reqSize)
            {
                SceneManager.LoadScene(Nextlevel);
            }
            else
            {
                Debug.Log("You do not meet the required size");
            }

        }
    }
}