using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerContacts))]
public class Player : ColorObject
{
    [SerializeField] private float speed = 3;
    [SerializeField] private Sprite[] mySprites;
    [SerializeField] private GameObject[] myColliders;

    private SpriteRenderer spriteRen;
    private Animator animator;

    private bool fall = false;
    private bool canMove = false;
    private Vector3 newPos;

    private SwipeDirection directionMove;
    private const float offsetBlock = 1f;
    private const float offsetswipe = 20f;

    private void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
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

    private void EndMove()
    {
        if (fall)
        {
            return;
        }
        else
        {
            canMove = false;
            MainController.Instance.PlayerEndMove();
        }
    }

    private IEnumerator CoFallPlayer()
    {
        PlayAnimation(PlayerAnim.Fall);
        yield return new WaitForSeconds(1.5f);
        MainController.Instance.PlayerEndMove();
    }

    public void SetNewPosition(SwipeDirection direction)
    {
        directionMove = direction;

        switch (direction)
        {
            case SwipeDirection.Up:
                myColliders[0].SetActive(true);
                newPos = new Vector3(transform.position.x, transform.position.y + offsetswipe, transform.position.z);
                break;
            case SwipeDirection.Right:
                myColliders[1].SetActive(true);
                newPos = new Vector3(transform.position.x + offsetswipe, transform.position.y, transform.position.z);
                break;
            case SwipeDirection.Down:
                myColliders[2].SetActive(true);
                newPos = new Vector3(transform.position.x, transform.position.y - offsetswipe, transform.position.z);
                break;
            case SwipeDirection.Left:
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
            if (directionMove == SwipeDirection.Up)
                position.y -= 1;
            else if (directionMove == SwipeDirection.Right)
                position.x -= 1;
            else if (directionMove == SwipeDirection.Down)
                position.y += 1;
            else if (directionMove == SwipeDirection.Left)
                position.x += 1;
        }

        newPos = position;
    }

    public void SetPositionBeforeWall(Vector2 wallPos)
    {
        Vector2 position = transform.position;

        if (directionMove == SwipeDirection.Up)
            position.y = wallPos.y - 1;
        else if (directionMove == SwipeDirection.Right)
            position.x = wallPos.x - 1;
        else if (directionMove == SwipeDirection.Down)
            position.y = wallPos.y + 1;
        else if (directionMove == SwipeDirection.Left)
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

    public void SetNewColor(AllColor color)
    {
        MyColor = color;

        if (MyColor == AllColor.green)
            spriteRen.sprite = mySprites[0];
        else if (MyColor == AllColor.yellow)
            spriteRen.sprite = mySprites[1];
        else if (MyColor == AllColor.blue)
            spriteRen.sprite = mySprites[2];
        else if (MyColor == AllColor.red)
            spriteRen.sprite = mySprites[3];
    }

    public void PlayAnimation(PlayerAnim anim)
    {
        animator.SetTrigger(anim.ToString());
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }


















    //// Контакт с коином.
    //// Player становится на позицию коина, 
    //// запускается следующий уровень через mainCon.
    //private void ContactCoin(GameObject collision)
    //{
    //    newPos.x = collision.transform.position.x;
    //    newPos.y = collision.transform.position.y;

    //    //soundCon.PlaySound("coin");

    //    //swipeCon.canSwipe = false;

    //    DeEnableMyColliders();

    //    Destroy(collision.gameObject);
    //    //StartCoroutine(mainCon.NextLevel());
    //}

    //// Контакт с квестом.
    //// Позиция Player рядом с кнопкой квеста.
    //// Отключение колайдеров и запуск квеста.
    //private void ContactQuest(GameObject collision)
    //{
    //    newPos.x = collision.transform.position.x;
    //    newPos.y = collision.transform.position.y;

    //    //if (!canMoveleft)
    //    //    newPos.x = collision.transform.position.x + 1.3f;
    //    //else if (!canMoveRight)
    //    //    newPos.x = collision.transform.position.x - 1.3f;
    //    //else if (!canMoveup)
    //    //    newPos.y = collision.transform.position.y - 1.3f;
    //    //else if (!canMovedown)
    //    //    newPos.y = collision.transform.position.y + 1.3f;

    //    DeEnableMyColliders();

    //    collision.GetComponent<ButtonQuest>().ActivateQuest();
    //    collision.GetComponent<ButtonQuest>().enabled = false;
    //}

}

public enum PlayerAnim
{
    Fall
}
