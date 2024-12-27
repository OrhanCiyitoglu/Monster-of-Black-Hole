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
    public float minSpawnRate = 0.1f; // Minimum spawn h�z�
    public float maxSpawnRate = 1.8f; // Maksimum spawn h�z�
    public float spwanRate;
    private float timer = 0;
    public Scpoint logic;
    private List<GameObject> spawnedObjects = new List<GameObject>(); // Spawn edilen nesneleri tutaca��m�z liste
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Scpoint>();
        objects = new GameObject[] { insan, kalp, nukleer, fuze, su };
        spawnobje();
    }

    void Update()
    {
        UpdateSpawnRate(); // Puan bazl� spawn h�z�n� g�ncelle
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


        int randomIndex = Random.Range(0, objects.Length);  // objects dizisinden rastgele bir nesne se�

        // Rastgele bir x pozisyonu se� (�rne�in, -14 ile 14 aras�nda)
        float randomXPosition = Random.Range(-14.5f, 14.5f);

        // Y pozisyonunu sabitle (�rne�in 10) yukar�dan ba�las�n
        Vector3 spawnPosition = new Vector3(randomXPosition, 12.22f, 0);

        // Se�ilen nesneyi spawn et
        GameObject newobject= Instantiate(objects[randomIndex], spawnPosition, Quaternion.identity);
        spawnedObjects.Add(newobject);
        // yeni bi liste olusuturup spawn olanlar� oraya att�k takip edebilmek i�in ba�ka yoolu daha olmal�

    }
    void destrroyOffScreen1()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i); // Listeyi g�ncelle
                i--; // Listeden bir eleman ��kar�ld��� i�in, indeksi bir azalt�yoruz
                continue; // Di�er kodu atla, bir sonraki elemana ge�
            }



            // E�er nesne ekran�n alt�na d��erse
            if (spawnedObjects[i].transform.position.y <= -14f)
            {
                Destroy(spawnedObjects[i]); // Nesneyi yok et
                spawnedObjects.RemoveAt(i); // Nesneyi listeden ��kar
                i--; // Nesne silindi�i i�in dizideki indeks bir kayd�r�l�r
            }
        }
    }
    void UpdateSpawnRate()
    {
        // Puan bazl� logaritmik bir azalma ile spawnRate'i g�ncelle
        spwanRate = Mathf.Lerp(maxSpawnRate, minSpawnRate, logic.puan / 70f);
        
    }
}
