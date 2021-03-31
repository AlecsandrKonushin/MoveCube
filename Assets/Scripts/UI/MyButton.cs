using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MyButton : MonoBehaviour
{
    public UnityEvent OnClick;
    public UiSound soundClick = UiSound.ButtonClick;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickByButton);
    }

    public virtual void ClickByButton()
    {
        AudioController.Instance.PlayUiSound(soundClick);
        OnClick.Invoke();
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveListener(ClickByButton);
    }    
}
