using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] ClipManager clipManager;
    [SerializeField] AvatarManager avatarManager;
    [SerializeField] AvatarPlayback avatarPlayback;
    [SerializeField] AssetLoader assetLoader;
    [SerializeField] InteractionInitializer interactionInitializer;

    public static bool SystemInitialized = false;

    public static bool ReloadSystem = false;

    private void OnDestroy()
    {
        ClipManager.clipButtonList.Clear();
    }

    private void Start()
    {
        if (SystemInitialized == true)
        {
            ReloadSystem = true;

            clipManager.AddClipButtons();
            clipManager.DrawTransitions();

            avatarManager.InstantiateAvatar();
            avatarManager.SetMode(AvatarState.Default, Handedness.Both);
            avatarPlayback.SetState(PlaybackState.InPlaybackState);

            assetLoader.Load();

            ReloadSystem = false;
        }

        if (SystemInitialized == false)
        {
            //executed when user first lands the scene
            interactionInitializer.InitializeDefaultInteraction();
            clipManager.AddClipButtons();
            clipManager.DrawTransitions();
            avatarManager.InstantiateAvatar();
            avatarManager.SetMode(AvatarState.Default, Handedness.Both);
            avatarPlayback.SetState(PlaybackState.InPlaybackState);

            SystemInitialized = true;
        }
    }
}
