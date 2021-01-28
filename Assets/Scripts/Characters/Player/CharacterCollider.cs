using UnityEngine;

public class CharacterCollider : MonoBehaviour
{
    private CharacterContacts contacts;

    private void Start()
    {
        contacts = GetComponentInParent<CharacterContacts>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contacts.CollisionWithObjeсt(collision.gameObject);
    }
}
