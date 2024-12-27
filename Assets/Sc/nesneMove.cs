using UnityEngine;

public class nesneMove : MonoBehaviour
{
    
    // nesnelere randoom hýz eklemeliyim 
    public int speed ;
    void Start()
    {
       speed= Random.Range(5, 15);
      

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * speed) *Time.deltaTime;
        
    }
}
