using UnityEngine;

[RequireComponent(typeof(PlayerContacts))]
public class Player : Character
{
    [SerializeField] private Sprite[] mySprites;      

    protected override void EndMove()
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
