using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Player myPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myPlayer.CollisionWithObjext(collision.gameObject);
    }
}
