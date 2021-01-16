using System.Collections;
using UnityEngine;

public class Character : ColorObject
{
    [SerializeField] protected float speed = 8;
    [SerializeField] protected GameObject[] myColliders;

    protected Animator animator;
    protected SpriteRenderer spriteRen;

    protected bool fall = false;
    protected bool canMove = false;
    protected Vector3 newPos;

    protected Direction directionMove;
    protected const float offsetBlock = 1f;
    protected const float offsetswipe = 20f;

    protected void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

            if (transform.position == newPos)
            {
                EndMove();
            }
        }
    }

    protected virtual void EndMove()
    {
    }

    protected IEnumerator CoFallPlayer()
    {
        PlayAnimation(CharacterAnim.Fall);
        yield return new WaitForSeconds(1.5f);
        MainController.Instance.PlayerEndMove();
    }

    public void SetNewPosition(Direction direction)
    {
        directionMove = direction;

        switch (direction)
        {
            case Direction.Up:
                myColliders[0].SetActive(true);
                newPos = new Vector3(transform.position.x, transform.position.y + offsetswipe, transform.position.z);
                break;
            case Direction.Right:
                myColliders[1].SetActive(true);
                newPos = new Vector3(transform.position.x + offsetswipe, transform.position.y, transform.position.z);
                break;
            case Direction.Down:
                myColliders[2].SetActive(true);
                newPos = new Vector3(transform.position.x, transform.position.y - offsetswipe, transform.position.z);
                break;
            case Direction.Left:
                myColliders[3].SetActive(true);
                newPos = new Vector3(transform.position.x - offsetswipe, transform.position.y, transform.position.z);
                break;
        }

        canMove = true;
    }

    public void SetNewPosition(Vector2 objectPos, bool offset = true)
    {
        Vector2 position = objectPos;

        if (offset)
        {
            if (directionMove == Direction.Up)
                position.y -= 1;
            else if (directionMove == Direction.Right)
                position.x -= 1;
            else if (directionMove == Direction.Down)
                position.y += 1;
            else if (directionMove == Direction.Left)
                position.x += 1;
        }

        newPos = position;
    }

    public void SetPositionBeforeWall(Vector2 wallPos)
    {
        Vector2 position = transform.position;

        if (directionMove == Direction.Up)
            position.y = wallPos.y - 1;
        else if (directionMove == Direction.Right)
            position.x = wallPos.x - 1;
        else if (directionMove == Direction.Down)
            position.y = wallPos.y + 1;
        else if (directionMove == Direction.Left)
            position.x = wallPos.x + 1;

        newPos = position;
        fall = true;

        StartCoroutine(CoFallPlayer());
    }

    public void DeEnableMyColliders()
    {
        foreach (var collider in myColliders)
        {
            collider.SetActive(false);
        }
    }

    public void PlayAnimation(CharacterAnim anim)
    {
        animator.SetTrigger(anim.ToString());
    }

    public virtual void DestroyCharacter()
    {
        Destroy(gameObject);
    }
}

public enum CharacterAnim
{
    Fall
}
