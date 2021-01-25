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
        Debug.LogError("Не работает колайдер у enemy");
        contacts.CollisionWithObjeсt(collision.gameObject);
    }
}
