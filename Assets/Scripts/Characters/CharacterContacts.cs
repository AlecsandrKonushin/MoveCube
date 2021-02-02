using UnityEngine;

/// <summary>
/// Контакты character с объектами.
/// Контролирует колайдеры. Определяет столкновения.
/// </summary>
public class CharacterContacts : MonoBehaviour
{
    [SerializeField] protected GameObject[] myColliders;

    protected Character character;

    protected GameObject collisionObject;

    protected virtual void Start()
    {
        character = GetComponent<Character>();
    }

    public virtual void CollisionWithObjeсt(GameObject collision)
    {
        collisionObject = collision;

        if (collision.transform.tag == "block")
            ContactWithBlock();
        else if (collision.transform.tag == "wall")
            ContactWithWall();
        else if (collision.transform.tag == "portal")
            ContactWithPortal();
    }

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

    protected virtual void ContactWithBlock()
    {
        Block block = collisionObject.GetComponent<Block>();

        if (character.MyColor != block.MyColor)
        {
            character.SetNewPosition(block.transform.position);
            DeEnableMyColliders();
        }
    }

    protected virtual void ContactWithWall()
    {
        DeEnableMyColliders();

        character.SetPositionBeforeWall(collisionObject.transform.position);
    }

    protected virtual void ContactWithCoockie() { }

    protected virtual void ContactWithPortal() { }

}
