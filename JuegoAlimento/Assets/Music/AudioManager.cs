using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
