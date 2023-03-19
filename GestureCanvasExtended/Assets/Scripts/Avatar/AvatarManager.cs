using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarManager : MonoBehaviour
{
    public static AvatarState currentAvatarState_R = AvatarState.Default;
    public static AvatarState currentAvatarState_L = AvatarState.Default;

    Vector3 Offset = new Vector3(0.0f, 0.0f, 0.9f);

    HandObject DefaultHandObject_R;
    HandObject DefaultHandObject_L;
    HandObject SkeletalHandObject_R;
    HandObject SkeletalHandObject_L;
    HandObject HighlightedHandObject_R;
    HandObject HighlightedHandObject_L;

    HMDObject HMDObject;

    GameObject DefaultHand_R;
    GameObject DefaultHand_L;
    GameObject SkeletalHand_R;
    GameObject SkeletalHand_L;
    GameObject HighlightedHand_R;
    GameObject HighlightedHand_L;

    GameObject HMD;

    [Header("Default Prefab to Instantiate")]
    [SerializeField] GameObject DefaultPrefab_R;
    [SerializeField] GameObject DefaultPrefab_L;

    [Header("Skeletal Prefab to Instantiate")]
    [SerializeField] GameObject SkeletalPrefab_R;
    [SerializeField] GameObject SkeletalPrefab_L;

    [Header("Highlighted Prefab to Instantiate")]
    [SerializeField] GameObject HighlightedPrefab_R;
    [SerializeField] GameObject HighlightedPrefab_L;

    [Header("HMD Prefab to Instantiate")]
    [SerializeField] GameObject HMDPrefab;

    [Header("Other Required References")]
    [SerializeField] private Transform playbackObjectHolder;

    public static Vector3 HMDDirection;
    public static Vector3 HMDPosition;
}
