using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject insan;
    public GameObject kalp;
    public GameObject nukleer;
    public GameObject fuze;
    public GameObject su;
    public GameObject[] objects;
    public int deadzone = -15;
    public float minSpawnRate = 0.1f; // Minimum spawn hýzý
    public float maxSpawnRate = 1.8f; // Maksimum spawn hýzý
    public float spwanRate;
    private float timer = 0;
    public Scpoint logic;
    private List<GameObject> spawnedObjects = new List<GameObject>(); // Spawn edilen nesneleri tutacaðýmýz liste
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Scpoint>();
        objects = new GameObject[] { insan, kalp, nukleer, fuze, su };
        spawnobje();
    }

    void Update()
    {
        UpdateSpawnRate(); // Puan bazlý spawn hýzýný güncelle
        if (timer < spwanRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnobje();
            timer = 0;
        }

        destrroyOffScreen1();

    }
    void spawnobje()
    {


        int randomIndex = Random.Range(0, objects.Length);  // objects dizisinden rastgele bir nesne seç

        // Rastgele bir x pozisyonu seç (örneðin, -14 ile 14 arasýnda)
        float randomXPosition = Random.Range(-14.5f, 14.5f);

        // Y pozisyonunu sabitle (örneðin 10) yukarýdan baþlasýn
        Vector3 spawnPosition = new Vector3(randomXPosition, 12.22f, 0);

        // Seçilen nesneyi spawn et
        GameObject newobject= Instantiate(objects[randomIndex], spawnPosition, Quaternion.identity);
        spawnedObjects.Add(newobject);
        // yeni bi liste olusuturup spawn olanlarý oraya attýk takip edebilmek için baþka yoolu daha olmalý

    }
    void destrroyOffScreen1()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i); // Listeyi güncelle
                i--; // Listeden bir eleman çýkarýldýðý için, indeksi bir azaltýyoruz
                continue; // Diðer kodu atla, bir sonraki elemana geç
            }



            // Eðer nesne ekranýn altýna düþerse
            if (spawnedObjects[i].transform.position.y <= -14f)
            {
                Destroy(spawnedObjects[i]); // Nesneyi yok et
                spawnedObjects.RemoveAt(i); // Nesneyi listeden çýkar
                i--; // Nesne silindiði için dizideki indeks bir kaydýrýlýr
            }
        }
    }
    void UpdateSpawnRate()
    {
        // Puan bazlý logaritmik bir azalma ile spawnRate'i güncelle
        spwanRate = Mathf.Lerp(maxSpawnRate, minSpawnRate, logic.puan / 70f);
        
    }
}
