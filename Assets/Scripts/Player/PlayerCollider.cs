using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private PlayerContacts contacts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contacts.CollisionWithObjext(collision.gameObject);
    }
}
