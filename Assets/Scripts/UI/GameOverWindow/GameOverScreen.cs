using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Window
{
    [SerializeField] private AudioSource _sourceGameOver;

    public event UnityAction RestartButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
        _sourceGameOver.Stop();
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
        _sourceGameOver.Play();
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
