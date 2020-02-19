using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisonLogic : MonoBehaviour
{
    private bool interact;
    private Animator anim;
    private bool interacting;
    private bool dead = false;
    private AudioSource sound;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        anim.SetBool("Interact", interacting);
        anim.SetBool("Died", dead);
        
        interact = Input.GetKey(KeyCode.E);
        if (interacting)
            interacting = false;

    }
    private void SetSound(AudioClip clip)
    {
        sound.clip = clip;
        sound.Play();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") && !dead)
        {
            dead = true;
        }

        if (collision.CompareTag("Hole"))
        {
            if (interact)
            {
                interacting = true;
                collision.gameObject.GetComponent<Holes>().DeactivateHole();
            }
        }
    }
    private void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
