using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaybackSlider : MonoBehaviour, IPointerDownHandler
{
    [Header("UI References")]
    [SerializeField] private Slider slider;

    [Header("Script References")]
    [SerializeField] PlaybackStateHandler playbackStateHandler;
    /////////////////////////////  SLIDER EVENTS  /////////////////////////////
    public void OnPointerDown(PointerEventData a)
    {
        playbackStateHandler.Set(PlaybackState.InSliderDragState);
    }

    public void OnPointerUp(PointerEventData a)
    {
        playbackStateHandler.Set(PlaybackState.InPlaybackState);
    }

    /////////////////////////////  GET/SET SLIDER VALUES  /////////////////////////////

    public void setValue(int currentIndex, int total)
    {
        slider.value = ((float)currentIndex / (float)total) * 100.0f;
    }

    public float getValue()
    {
        return slider.value;
    }
}
