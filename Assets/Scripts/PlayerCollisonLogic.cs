using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisonLogic : PlayerMovement
{
    private AudioSource sound;

    protected override void Start()
    {
        base.Start();
        sound = GetComponent<AudioSource>();
    }

    public void SetSound(AudioClip clip)
    {
        sound.clip = clip;
        sound.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            anim.Play("die");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
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

    public void ReloadLevel()
    {
        Destroy(gameObject);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(scene.buildIndex);
    }
}