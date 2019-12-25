using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //private AudioManager audioManager;
    private GameObject cv;
    private GameObject cva;
    private GameObject cvt;
   // private AudioSource audioSource;
   // public AudioClip audioClip;
    [SerializeField]
    public Canvas tutorial;
    public Canvas about;
    void Awake()
    {
        //audioSource.clip = audioClip;
        ////audioSource.playOnAwake = true;
        //audioSource.loop = true;
        //audioSource.volume = 0.7f;
        //audioSource.pitch = 1.0f;
        //audioManager = AudioManager.instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        cv = GameObject.Find("Menu");
        cvt = GameObject.FindGameObjectWithTag("Tutorial");
        cva = GameObject.FindGameObjectWithTag("About");
        tutorial.enabled = false;
        about.enabled = false;
        //audioSource.Play();
        //audioManager.PlaySound("MenuMusic");
    }
    public void About()
    {
        cv.SetActive(false);
        about.enabled = true;
    }
    public void ReturnA()
    {
        about.enabled = false;
        cv.SetActive(true);
    }
    public void ReturnB()
    {
        tutorial.enabled = false;
        cv.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Tutorial()
    {

        //GameObject.FindGameObjectWithTag("Menu").SetActive(false);
        cv.SetActive(false);
        tutorial.enabled = true;

    }
    //public void About()
    //{

    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
