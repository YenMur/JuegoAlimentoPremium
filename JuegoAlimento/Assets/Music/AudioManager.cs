using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("ASIGNAR MANUALMENTE")]
    [SerializeField] private Button volumeButton;   
    [SerializeField] private Sprite soundOnIcon;    
    [SerializeField] private Sprite soundOffIcon;   

    const string PREF_KEY = "muted";

    static bool s_initialized;
    static bool s_isMuted;

    Image iconImage; 

    void Awake()
    {
        if (volumeButton != null)
        {
            iconImage = volumeButton.targetGraphic as Image
                     ?? volumeButton.GetComponent<Image>()
                     ?? volumeButton.GetComponentInChildren<Image>(true);
        }

        if (!s_initialized)
        {
            s_isMuted = PlayerPrefs.GetInt(PREF_KEY, 0) == 1;
            s_initialized = true;
        }

        ApplyMute(s_isMuted);
        RefreshIcon(s_isMuted);
    }

    void OnEnable()
    {
        s_isMuted = PlayerPrefs.GetInt(PREF_KEY, 0) == 1;
        ApplyMute(s_isMuted);
        RefreshIcon(s_isMuted);
    }

    public void ToggleMute()
    {
        s_isMuted = !s_isMuted;
        PlayerPrefs.SetInt(PREF_KEY, s_isMuted ? 1 : 0);
        ApplyMute(s_isMuted);
        RefreshIcon(s_isMuted);
    }

    void ApplyMute(bool muted)
    {
        AudioListener.pause = muted; 
    }

    void RefreshIcon(bool muted)
    {
        if (iconImage != null && soundOnIcon != null && soundOffIcon != null)
            iconImage.sprite = muted ? soundOffIcon : soundOnIcon;
    }
}
