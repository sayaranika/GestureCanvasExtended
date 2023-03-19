using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AvatarPlaybackSlider : MonoBehaviour, IPointerDownHandler
{
    [Header("Script References")]
    [SerializeField] AvatarPlayback avatarPlayback;

    [Header("UI References")]
    [SerializeField] private Slider slider;

    #region IPOINTERDOWN EVENTS
    public void OnPointerDown(PointerEventData a)
    {
        avatarPlayback.SetState(PlaybackState.InSliderDragState);
    }

    public void OnPointerUp(PointerEventData a)
    {
        avatarPlayback.SetState(PlaybackState.InPlaybackState);
    }
    #endregion

    #region SLIDER VALUE GET SET
    public void setValue(int currentIndex, int total)
    {
        slider.value = ((float)currentIndex / (float)total) * 100.0f;
    }

    public float getValue()
    {
        return slider.value;
    }
    #endregion
}
