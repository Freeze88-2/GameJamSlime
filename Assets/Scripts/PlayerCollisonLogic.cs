using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisonLogic : MonoBehaviour
{
    private bool interact;
    private Animator anim;
    private bool interacting;
    private bool dead = false;
    [SerializeField] private AudioSource audio;
    private void Start()
    {
        anim = GetComponent<Animator>();
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
        audio.clip = clip;
        audio.Play();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
