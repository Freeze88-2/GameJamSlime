using UnityEngine;

public class PlayerCollisonLogic : MonoBehaviour
{
    private bool interact;
    private Animator anim;
    private bool interacting;
    [SerializeField] private AudioSource audio;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("Interact", interacting);

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
        if (collision.CompareTag("Water"))
        {
            anim.SetBool("Died", true);
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
}
