using UnityEngine;

public class monster : MonoBehaviour
{
    
    public float moveSpeedyatay = 20f;
    public float moveSpeeddikey = 15f;
    public int deger = 23;
    public Scpoint logic;
    private Rigidbody2D myrigidbody;
    public Joystick joyControl;
    
    public Vector2 xsinir= new Vector2(15.5f, -15.5f);
    public Vector2 ysinir = new Vector2(8.1f, -8.5f);
      
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        
      
        logic  = GameObject.FindGameObjectWithTag("Logic").GetComponent<Scpoint>();
        
        myrigidbody = GetComponent<Rigidbody2D>();
  
    }

 
   
    void Update()
    {

        if (!logic.monsterAlive)
        {
            Destroy(gameObject);
            return;
        }
        float keyboardHorizontal = Input.GetAxis("Horizontal");
        float keyboardVertical = Input.GetAxis("Vertical");

        // Joystick girişlerini al
        float joystickHorizontal = joyControl.Horizontal;
        float joystickVertical = joyControl.Vertical;

        // Öncelikli olarak joystick girişini, ardından klavye girişini kullan
        float horizontalInput = joystickHorizontal != 0 ? joystickHorizontal : keyboardHorizontal;
        float verticalInput = joystickVertical != 0 ? joystickVertical : keyboardVertical;
        
      
        
      

        myrigidbody.linearVelocity = new Vector2(horizontalInput * moveSpeedyatay, verticalInput*moveSpeeddikey);
       
        
        if (horizontalInput != 0 || verticalInput != 0)
        {
            // Hareket a��s�n� hesapla
            float angle = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;

            // Karakteri o y�ne d�nd�r
            transform.localRotation = Quaternion.Euler(0, 0, angle-90);
        }
          
  
             
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (logic.monsterAlive==false)
        {

            logic.monsterAlive = false; // Karakterin hareketini durdur
            logic.gameOver(); // Game Over ekran�n� g�ster

        }
       
    }
}

