using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetPlayback : MonoBehaviour
{
    public static Clip current = null;
    public static Clip previous = null;

    public static bool refreshVirtualObjectList = false;

    private void Update()
    {
        if (Manager.SystemInitialized == true && Manager.ReloadSystem == false)
        {
            Clip selectedClip = null;
            foreach (Clip clip in ClipHandler.ClipList)
            {
                if (AvatarPlayback.currentFrame >= clip.startIndex && AvatarPlayback.currentFrame < clip.endIndex)
                {
                    selectedClip = clip;
                    break;
                }
            }

            if (selectedClip != current)
            {
                previous = current;
                current = selectedClip;

                RefreshVirtualObjectList();

            }

            if (refreshVirtualObjectList == true)
            {
                RefreshVirtualObjectList();
                refreshVirtualObjectList = false;
            }
        }


    }


    public void DeactivateAllAssets()
    {
        GameObject[] b = GameObject.FindGameObjectsWithTag("SpawnedVFX");
        if (b.Length > 0)
        {
            //deactivate
            foreach (var obj in b)
            {
                obj.SetActive(false);
            }

        }


        GameObject[] a = GameObject.FindGameObjectsWithTag("SpawnedObject");
        if (a.Length > 0)
        {
            //deactivate
            foreach (var obj in a)
            {
                obj.SetActive(false);
            }

        }
    }

    public void RefreshVirtualObjectList()
    {
        DeactivateAllAssets();

        Clip selectedClip = null;

        foreach (Clip clip in ClipHandler.ClipList)
        {
            if (AvatarPlayback.currentFrame >= clip.startIndex && AvatarPlayback.currentFrame < clip.endIndex)
            {
                selectedClip = clip;
                break;
            }
        }

        if (selectedClip != null)
        {
            foreach (VFXObject obj in selectedClip.vfxObjects)
            {
                obj.vfxRef.SetActive(true);
            }

            foreach (VirtualObject obj in selectedClip.virtualObjects)
            {
                obj.objectRef.SetActive(true);
            }
        }


    }
}
