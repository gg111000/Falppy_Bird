using UnityEngine;

public class AudioOnOff : MonoBehaviour
{
    public bool IsOn;

    private void Start()
    {
        IsOn = true;
    }

    public void OnOffSound()
    {
        if (!IsOn)
        {
            AudioListener.volume = 1f;
            IsOn = true;
        }
        else if (IsOn)
        {
            AudioListener.volume = 0f;
            IsOn = false;
        }
    }
}
