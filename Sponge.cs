using UnityEngine;

public class Sponge : MonoBehaviour
{
    //if the sponge only grows in one dimension or not.
    public bool oneDir = false;
    public float size = 1f;
    [SerializeField]
    private float maxsize = 2f;
    public float growSpeed = 3f;

    //is the sponge growing;
    public bool isGrowing;

    //if the sponge only grows in one scale, does it grow up/down or left/right?
    public bool isy = true;

    public float getSize()
    {
        return size;
    }

    public void increaseSize(float s)
    {
        size += s;
    }

    public void decreaseSize(float s)
    {
        size -= s;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGrowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((isGrowing) && (gameObject.transform.localScale.x <= maxsize))
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x + (growSpeed * Time.deltaTime), transform.localScale.y + (growSpeed * Time.deltaTime));
            //Debug.Log(gameObject.transform.localScale.magnitude); to verify object is scaling.
        }
        else if ((!isGrowing) && (gameObject.transform.localScale.x == maxsize))
        {
            isGrowing = !isGrowing;
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerController p = coll.gameObject.GetComponent<PlayerController>();

            if (p != null)
            {
                if (p.size > 1f && p.size - size >= size)
                {
                    //change below later so player size is reduced to 1 or reduced by the maxsize

                    if (p.size > maxsize)
                    {
                        // prevents size from being lost to the ether, can be removed when inital size increase is changed.
                        p.increaseSize(size - maxsize);
                        p.increaseMass(0.2f * (size - maxsize));
                        size = maxsize;

                    }
                    else
                    {
                        size += p.size - (p.size - 1);
                        p.decreaseMass(0.2f * (p.size - 1));
                        p.size = p.size - (p.size - 1);
                    }

                    if (p.size < 1)
                    {
                        Debug.Log("Reduced to smaller than size 1");
                    }

                    if (oneDir)
                    {
                        if (isy)
                        {
                            gameObject.transform.localScale = new Vector3(1, size);
                        }
                        else
                        {
                            gameObject.transform.localScale = new Vector3(size, 1);
                        }
                    }
                    else
                    {
                        isGrowing = !isGrowing;
                    }


                }

            }
        }
    }


}