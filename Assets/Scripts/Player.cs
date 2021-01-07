using UnityEngine;

public class Player : ColorObject
{
    //private Rigidbody2D rigid;
    private SpriteRenderer spriteRen;

    private Vector3 newPos;
    private float speed = 3;
    private bool canMove = false;

    [SerializeField] private Sprite[] mySprites;

    //[SerializeField]
    //GameObject restartLVImage;

    [SerializeField] private GameObject[] myColliders;

    //private MoveObject objectTouch;

    private GameObject collisionObject;
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
                canMove = false;
        }
    }

    public void SetDirection(SwipeDirection direction)
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

    // Столкновение с каким-либо объектом.
    public void CollisionWithObjext(GameObject collision)
    {
        collisionObject = collision;

        if (collision.transform.tag == "block")
            ContactWithBlock();
        else if (collision.transform.tag == "wall")
            ContactWithWall();
        else if (collision.transform.tag == "exit")
            ContactWithExit();
        else if (collision.transform.tag == "colorChange")
            ContactWithChangeColor();
        else if (collision.transform.tag == "portal")
            ContactWithPortal();
        //else if (collision.transform.tag == "coinGold")
        //{
        //    ContactCoin(collision);
        //}
        //else if (collision.transform.tag == "colorChange")
        //{
        //    ColorController colorObj = collision.GetComponent<ColorController>();

        //    ChangeMyColor(colorObj);
        //}
        //else if (collision.transform.tag == "stop")
        //{
        //    newPos.x = collision.transform.position.x;
        //    newPos.y = collision.transform.position.y;

        //    //SideMoveTrue();

        //    DeEnableMyColliders();
        //}
        //else if (collision.transform.tag == "quest")
        //{
        //    string butArrow = collision.GetComponent<ButtonQuest>().MyArrow;

        //    if (butArrow != null)
        //    {
        //        //if (butArrow == sideNow)
        //        //    ContactQuest(collision);
        //        //else
        //        //    return;
        //    }
        //    else
        //        ContactQuest(collision);
        //}
    }

    private void ContactWithBlock()
    {
        Block block = collisionObject.GetComponent<Block>();

        if (myColor != block.MyColor)
        {
            if (directionMove == SwipeDirection.Up)
                newPos.y = block.transform.position.y - offsetBlock;
            else if (directionMove == SwipeDirection.Right)
                newPos.x = block.transform.position.x - offsetBlock;
            else if (directionMove == SwipeDirection.Down)
                newPos.y = block.transform.position.y + offsetBlock;
            else if (directionMove == SwipeDirection.Left)
                newPos.x = block.transform.position.x + offsetBlock;

            DeEnableMyColliders();
        }
    }

    private void DeEnableMyColliders()
    {
        foreach (var collider in myColliders)
        {
            collider.SetActive(false);
        }
    }

    private void ContactWithExit()
    {
        MainController.Instance.PlayerWinLevel();
        GetComponent<Animator>().SetTrigger("hide");
    }

    private void ContactWithWall()
    {
        MainController.Instance.PlayerDeath();
    }

    private void ContactWithChangeColor()
    {
        ColorObject colorObj = collisionObject.GetComponent<ColorObject>();

        if (colorObj.MyColor != MyColor)
        {
            MyColor = colorObj.MyColor;

            if (MyColor == AllColor.green)
                spriteRen.sprite = mySprites[0];
            else if (MyColor == AllColor.yellow)
                spriteRen.sprite = mySprites[1];
            else if (MyColor == AllColor.blue)
                spriteRen.sprite = mySprites[2];
            else if (MyColor == AllColor.red)
                spriteRen.sprite = mySprites[3];

            Destroy(colorObj.gameObject, .3f);
        }
    }

    private void ContactWithPortal()
    {

    }

    private void ContactWallPortal(Block wall)
    {
        //if (sideNow == wall.sideIn)
        //{
        //    DeEnableMyColliders();

        //    soundCon.PlaySound("portal");

        //    Vector3 exitPos = wall.ExitPortal.transform.position;

        //    if (wall.sideOut == "right")
        //    {
        //        myTransform.position = new Vector3(exitPos.x + 2, exitPos.y);
        //        SetDirectionPlayer("right");
        //    }
        //    else if (wall.sideOut == "left")
        //    {
        //        myTransform.position = new Vector3(exitPos.x - 2, exitPos.y);
        //        SetDirectionPlayer("left");
        //    }
        //    else if (wall.sideOut == "up")
        //    {
        //        myTransform.position = new Vector3(exitPos.x, exitPos.y + 2);
        //        SetDirectionPlayer("up");
        //    }
        //    else if (wall.sideOut == "down")
        //    {
        //        myTransform.position = new Vector3(exitPos.x, exitPos.y - 2);
        //        SetDirectionPlayer("down");
        //    }

        //    return;
        //}
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
