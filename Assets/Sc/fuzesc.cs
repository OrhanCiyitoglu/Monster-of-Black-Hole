using System.Drawing;
using UnityEngine;

public class fuzesc : MonoBehaviour
{
    public Scpoint fuze11;
    public GameObject nesnekapama;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuze11 = GameObject.FindGameObjectWithTag("Logic").GetComponent<Scpoint>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            fuze11.gameOver();
            Destroy(nesnekapama);
        }
    }
}
