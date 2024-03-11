using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public bool PausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausePanel)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        _panel.SetActive(true);
        Time.timeScale = 0f;
        PausePanel = true;
    }

    public void Resume()
    {
        _panel.SetActive(false);
        Time.timeScale = 1f;
        PausePanel = false;
    }
}
