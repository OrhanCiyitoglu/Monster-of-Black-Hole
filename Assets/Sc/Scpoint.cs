using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scpoint : MonoBehaviour
{
    public int puan;
    public Text textScore; 
    public GameObject game1OverScreen;
    public GameObject gameStart;
    public bool monsterAlive = true;
    public GameObject monsterr;
    public bool gameStarted = false; // Oyunun baþlayýp baþlamadýðýný kontrol etmek için
    public soundManager sesEkle;
    private static bool restarted =false;
    private void Start()
    {
        if (restarted)
        {
            gameStart.SetActive(false);
            gameStarted = true;
            restarted = false; // Deðeri sýfýrla
        }
        else
        {
            gameStart.SetActive(true);
            gameStarted = false;
        }

        sesEkle = GameObject.FindGameObjectWithTag("sound").GetComponent<soundManager>();
    }
    public void addScore(int addScoreto)
    {
        sesEkle.Temas();
        if (!gameStarted) return;
        puan =puan+addScoreto;
        textScore.text=puan.ToString();
    }

    public void restartGame()
    {
        sesEkle.BASLAT();
        restarted = true;

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
       
    }
    public void gameOver()
    {
        
        if(!gameStarted) return;    
        game1OverScreen.SetActive(true); // Game Over ekranýný göster
        monsterAlive = false;
        
    }
   
    public void startbuton()
    {
       
        gameStart.SetActive(false);
        gameStarted = true;
      
    }

}
