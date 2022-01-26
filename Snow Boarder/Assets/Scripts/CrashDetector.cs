using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float magicNumberDelay=1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            Debug.Log("I hit my head...");
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", magicNumberDelay);
        }   

    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
