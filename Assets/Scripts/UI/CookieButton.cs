using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CookieButton : MonoBehaviour
{
    [SerializeField] private Sprite mainSpriteCookie;
    [SerializeField] private Sprite[] spritesCookie;
    [SerializeField] private Image imageCookie;
    [SerializeField] private float timeChangeSpriteCookie;

    private bool alreadyClick;

    private void OnEnable()
    {
        imageCookie.sprite = mainSpriteCookie;
    }

    public void ClickButton()
    {
        alreadyClick = true;
        StartCoroutine(CoClickButton());
    }

    private IEnumerator CoClickButton()
    {
        for (int i = 0; i < spritesCookie.Length; i++)
        {
            imageCookie.sprite = spritesCookie[i];
            yield return new WaitForSeconds(timeChangeSpriteCookie);
        }

        UiController.Instance.ClickWinLevel();
        alreadyClick = false;
    }
}
