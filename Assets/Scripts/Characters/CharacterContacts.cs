using UnityEngine;

/// <summary>
/// Контакты character с объектами.
/// Контролирует колайдеры. Определяет столкновения.
/// </summary>
public class CharacterContacts : MonoBehaviour
{
    [SerializeField] protected GameObject[] myColliders;

    protected GameObject collisionObject;

    public virtual void CollisionWithObjeсt(GameObject collision) { }

    public void EnableCollider(int numberCollider)
    {
        myColliders[numberCollider].SetActive(true);
    }

    public void DeEnableMyColliders()
    {
        foreach (var collider in myColliders)
        {
            collider.SetActive(false);
        }
    }
}
