using UnityEngine;
using UnityEngine.SceneManagement;

public class pueseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausmenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public void puause()
    {
        pausmenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
