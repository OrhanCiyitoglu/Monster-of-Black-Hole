using UnityEngine;

public class mapSinir : MonoBehaviour
{
   

    public float xSinir = 15.5f;
    public float ySinir = 8.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
        // map sinirlarini yazdýðým kod
    {
        if (transform.position.x < -xSinir)
        {
           transform.position = new Vector3(-xSinir,transform.position.y,transform.position.z);
        }
        if (transform.position.x > xSinir)
        {
            transform.position = new Vector3(xSinir, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -ySinir) 
        {
            transform.position = new Vector3(transform.position.x,-ySinir,transform.position.z);
        }
        if(transform.position.y > ySinir)
        {
            transform.position= new Vector3(transform.position.x, ySinir, transform.position.z);
        }

    }
}
