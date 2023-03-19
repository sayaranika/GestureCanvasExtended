using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipButtonHandler : MonoBehaviour
{
    [Header("Clip Prefab")]
    [SerializeField] private GameObject clipPrefab;
    [SerializeField] Transform clipPanel;

    [Header("Script References")]
    [SerializeField] ClipHandler clipHandler;

    public static List<ClipButton> ClipButtonList { get; private set; }
    private List<GameObject> ClipButtonObjects = new List<GameObject>();

    private void Awake()
    {
        ClipButtonList = new List<ClipButton>();
    }

    public void ClearClipButtons()
    {
        if (ClipButtonObjects.Count > 0)
        {
            foreach (GameObject button in ClipButtonObjects)
            {
                Object.Destroy(button);
            }
            ClipButtonObjects.Clear();
        }
    }

    public void RefreshClipButtons()
    {
        int numberOfClips = clipHandler.ClipCount();

        if (numberOfClips > 0)
        {
            ClearClipButtons();

            foreach (ClipButton clipButton in ClipButtonList)
            {
                var button = GameObject.Instantiate(clipPrefab, clipPanel);
                button.transform.localPosition = new Vector3(0, 0, 0);
                button.transform.position = new Vector3(clipButton.StartPosition, button.transform.position.y, button.transform.position.z);
                Vector3 rescale = button.transform.localScale;

                float startVal = clipButton.StartPosition * 100.0f;
                float endVal = clipButton.EndPosition * 100.0f;

                rescale.x = ((endVal - startVal) * 2.0f);

                button.transform.localScale = rescale;

                Toggle buttonToggle = button.transform.GetChild(0).GetComponent<Toggle>();

                buttonToggle.onValueChanged.AddListener(delegate {
                    ToggleValueChanged(buttonToggle, clipButton.clip.Id);
                });

                ClipButtonObjects.Add(button);
            }
        }
    }

    void ToggleValueChanged(Toggle toggleButton, int clipId)
    {
        Clip selectedClip = null;

        foreach (ClipButton clipButton in ClipButtonList)
        {
            if (clipButton.clip.Id == clipId)
            {
                clipButton.isToggleOn = toggleButton.isOn;
                if (toggleButton.isOn == true) selectedClip = clipButton.clip;
                break;
            }
        }
    }
}
