using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuest : ColorObject
{
    // Спрайт активированной кнопки (нажатой)
    [SerializeField] protected Sprite spriteActivate;

    // Будет ли меняться цвет и у каких стен
    [SerializeField] protected bool changeColor;
    [SerializeField] protected Block[] wallsChange;

    // Цвет на который будет меняться
    [SerializeField] protected AllColor colorChange;

    // Название цвета изменения
    [SerializeField] protected string tageChange;
    // Спрайт цвета, на который будет меняться
    [SerializeField] protected Sprite spriteChange;

    // Будут ли активироваться какие-то объекты
    [SerializeField] protected bool activateObject;
    // Активирующиеся объекты
    [SerializeField] protected GameObject[] objectActive;

    // Будут ли диактивироваться какие-то объекты
    [SerializeField] protected bool deactivateObject;
    // Деактивирующиеся объекты
    [SerializeField] protected GameObject[] objectDeactive;

    [SerializeField] protected string myArrow;
    public string MyArrow { get { return myArrow; } }

    // Активация квеста.
    public virtual void ActivateQuest()
    {
        StartCoroutine(CoChangeSpriteButQuest());

        if (activateObject)
            ActivateObjects();


        if (deactivateObject)
            DeactivateObjects();

        if (changeColor)
            ChangeColor();
    }

    // Замена цвета определённым стенам, которые были выбраны заранее.
    // Изменение их тега.
    protected void ChangeColor()
    {
        for (int i = 0; i < wallsChange.Length; i++)
        {
            wallsChange[i].MyColor = colorChange;
            wallsChange[i].gameObject.tag = tageChange;
            //wallsChange[i].SpriteRen.sprite = spriteChange;
        }
    }

    // Деактивация объектов.
    // Включение анимации деактивации.
    // Затем отключение их, сразу же или с задержкой в секунду.
    protected void DeactivateObjects()
    {
        bool wait = false;

        for (int i = 0; i < objectDeactive.Length; i++)
        {
            if (objectDeactive[i].GetComponent<Animator>() != null)
            {
                objectDeactive[i].GetComponent<Animator>().SetTrigger("deact");
                wait = true;
            }
        }

        if (wait)
            StartCoroutine(CoDeactivateObj(1f));
        else
            StartCoroutine(CoDeactivateObj(.01f));
    }

    // Активация объектов,
    // анимация, затем 
    protected void ActivateObjects()
    {
        for (int i = 0; i < objectActive.Length; i++)
        {
            objectActive[i].SetActive(true);
        }

        for (int i = 0; i < objectActive.Length; i++)
        {
            if (objectActive[i].GetComponent<Animator>() != null)
                objectActive[i].GetComponent<Animator>().SetTrigger("activate");
        }
    }

    // Корутина деактивации объектов
    protected IEnumerator CoDeactivateObj(float time)
    {
        yield return new WaitForSeconds(time);

        for (int i = 0; i < objectDeactive.Length; i++)
        {
            objectDeactive[i].SetActive(false);
        }
    }

    // Корутина изменения спрайти кнопки квеста после её использования.
    protected IEnumerator CoChangeSpriteButQuest()
    {
        yield return new WaitForSeconds(.1f);

        GetComponentInChildren<SpriteRenderer>().sprite = spriteActivate;
    }
}
