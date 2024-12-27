using UnityEngine;
using UnityEngine.UIElements;

public class soundManager : MonoBehaviour
{
    AudioSource ses;
    [SerializeField] private AudioClip temas;
    [SerializeField] private AudioClip start12;
    [SerializeField] private AudioClip tryAgain12;
    public GameObject backk;
    private AudioSource backSoundAudioSource;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ses = GetComponent<AudioSource>();
        backSoundAudioSource = backk.GetComponent<AudioSource>();
    }
    public void Temas()
    {
       ses.PlayOneShot(temas);
    }
    public void BASLAT()
    {
        
       
        ses.PlayOneShot(start12);
      

    }
    public void TRY()
    {
        ses.PlayOneShot(tryAgain12);
    }

    
}
