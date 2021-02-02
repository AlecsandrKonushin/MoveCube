using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerContacts))]
public class Player : Character
{
    [SerializeField] private Sprite[] mySprites;

    [SerializeField]private Enemy enemyCollision;
    public Enemy SetEnemyCollision { set => enemyCollision = value; }

    [SerializeField] private float timeSpikeDamage = 1f;

    protected override void EndMove()
    {
        base.EndMove();

        MainController.Instance.PlayerEndMove();
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

    public void PushEnemy()
    {
        AfterMove -= PushEnemy;

        enemyCollision.SetNewPosition(directionMove);
    }

    public void PlayAnimation(PlayerAnim anim)
    {
        animator.SetTrigger(anim.ToString());
    }

    public void Damage()
    {
        AfterMove -= Damage;

        PlayAnimation(PlayerAnim.SpikeDamage);
        Invoke(nameof(Death), timeSpikeDamage);
    }

    protected override void Death()
    {
        MainController.Instance.PlayerDeath();
    }

    // TODO: нужно сделать более совершенно определение момента,
    //       когда player приходит на место bottle и надо менять цвет.
    //       Пока сделано коряво, через задержку, на глаз.
    public void ChangeColor(Bottle bottle)
    {
        StartCoroutine(CoContactWithBottle(bottle));
    }

    private IEnumerator CoContactWithBottle(Bottle bottle)
    {
        yield return new WaitForSeconds(.2f);

        ChangePlayerColor(bottle.MyColor);
        Destroy(bottle.gameObject);
    }

    private void ChangePlayerColor(AllColor color)
    {
        spriteRen.sprite = mySprites[(int)color];
        myColor = color;
    }
}

public enum PlayerAnim
{
    SpikeDamage
}
