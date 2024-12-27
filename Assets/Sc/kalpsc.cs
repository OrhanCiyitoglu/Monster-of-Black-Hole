using UnityEngine;

public class kalpsc : MonoBehaviour
{

    public Scpoint point;
    public GameObject kalp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        point = GameObject.FindGameObjectWithTag("Logic").GetComponent<Scpoint>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            point.addScore(5);
            Destroy(kalp);
        }

    }
}
