using UnityEngine;

public class FakeSlimeBall : MonoBehaviour
{
    [SerializeField] private float CoolDown;
    [SerializeField] private GameObject slimeBall;
    private GameObject slimeBallInst;

    // Start is called before the first frame update
    void Start()
    {
        CoolDown = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Slime ball cooldown
        if (CoolDown > 0)
        {
            CoolDown -= Time.deltaTime;
        }
        else
        {
            slimeBallInst = Instantiate(slimeBall, transform.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
