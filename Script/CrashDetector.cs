using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    private float reloadTimeDelay;
    [SerializeField]
    private ParticleSystem crashEffect;
    [SerializeField]
    private AudioSource audioSource;
    public PlayerController player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && player.isActive == true)
        {
            player.isActive = false;
            audioSource.Play();
            crashEffect.Play();
            Invoke("ReloadScene", reloadTimeDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
