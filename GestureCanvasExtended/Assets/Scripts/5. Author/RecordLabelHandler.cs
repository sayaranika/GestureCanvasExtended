using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordLabelHandler : MonoBehaviour
{
    [SerializeField] GameObject RecordLabel;

    private void Start()
    {
        HideRecordLabel();
    }

    public void ShowRecordLabel()
    {
        RecordLabel.SetActive(true);
    }

    public void HideRecordLabel()
    {
        RecordLabel.SetActive(false);
    }
}
