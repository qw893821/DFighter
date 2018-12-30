using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalJumpDetection : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "ColliderTile")
        {
            transform.SendMessageUpwards("LeaveGround");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "ColliderTile")
        {
            transform.SendMessageUpwards("OnGround");
        }
    }
}
