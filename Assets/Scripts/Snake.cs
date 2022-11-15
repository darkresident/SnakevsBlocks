using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public GameObject PanelWin;
    private Control control;
    private AudioSource apple;
    public AudioClip DestroyBlock;
    [Min(0)]
    public float volume;

    private new ParticleSystem particleSystem;

    private float disTime = 2f;
    public Material material;
    public bool Die = false;
    

    private void Awake()
    {   
        apple = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
        control = GetComponent<Control>();
        material.SetFloat("_Edge", disTime);
    }
    

    private void Update()
    {
        if (Die)
        {
            disTime -= (Time.deltaTime * 0.5f);
            material.SetFloat("_Edge", disTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            apple.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            control.enabled = false;
            Invoke("PlayerReachFinish", 5f);
        }
    }

    public void Destroy()
    {
        apple.PlayOneShot(DestroyBlock, volume);
    }

    public void Blood()
    {
        particleSystem.Play();
        Invoke("BloodStop", 0.2f);
    }
    private void BloodStop()
    {
        particleSystem.Stop();
    }

    private void PlayerReachFinish()
    {   
        Time.timeScale = 0f;
        PanelWin.SetActive(true);
        LevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (LevelIndex >= 7)
        {
            LevelIndex = 1;
        }
    }


    public static int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "Level Index";
}
