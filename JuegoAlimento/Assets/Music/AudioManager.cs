using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private bool isMuted = false;

    [SerializeField] private Image iconButton;
    [SerializeField] private Sprite soundOnIcon;
    [SerializeField] private Sprite soundOffIcon;

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;

        if(iconButton != null)
        {
            iconButton.sprite = isMuted ? soundOffIcon : soundOnIcon;
        }
    }
}
