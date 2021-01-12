using UnityEngine;

[RequireComponent(typeof(PlayerContacts))]
public class Player : ColorObject
{
    public delegate void Move();
    public event Move AfterMove;   

    [SerializeField] private float speed = 3;
    [SerializeField] private Sprite[] mySprites;
    [SerializeField] private GameObject[] myColliders;

    private SpriteRenderer spriteRen;

    private bool canMove = false;
    private Vector3 newPos;

    private SwipeDirection directionMove;
    private const float offsetBlock = 1f;
    private const float offsetswipe = 20f;

    void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

            if (transform.position == newPos)
            {
                canMove = false;
                MainController.Instance.PlayerEndMove();
            }
        }
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
        newPos = objectPos;

        if (offset)
        {
            if (directionMove == SwipeDirection.Up)
                newPos.y -= 1;
            else if (directionMove == SwipeDirection.Right)
                newPos.x -= 1;
            else if (directionMove == SwipeDirection.Down)
                newPos.y += 1;
            else if (directionMove == SwipeDirection.Left)
                newPos.x += 1;
        }
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
