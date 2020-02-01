using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisonLogic : MonoBehaviour
{
    bool interact;
    // Update is called once per frame
    void Update()
    {
        interact = Input.GetKey(KeyCode.E);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Water")
            Debug.Log("dieded");
        if (collision.tag == "Hole")
        {
            if (Input.GetKey(KeyCode.E))
            {
                collision.gameObject.GetComponent<Holes>().DeactivateHole();
            }
        }
    }
}
