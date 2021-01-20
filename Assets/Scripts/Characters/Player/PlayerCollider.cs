using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private PlayerContacts contacts;

    private void Start()
    {
        contacts = GetComponentInParent<PlayerContacts>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contacts.CollisionWithObjeсt(collision.gameObject);
    }
}
