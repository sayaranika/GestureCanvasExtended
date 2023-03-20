using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertHandler : MonoBehaviour
{
    [SerializeField] private GameObject AlertPanel;
    [SerializeField] private TMPro.TextMeshProUGUI AlertTxt;
    void Start()
    {
        AlertPanel.SetActive(false);
    }


    public IEnumerator ShowAlert(string msg, float waitTime)
    {
        AlertPanel.SetActive(true);
        AlertTxt.text = msg;
        yield return new WaitForSeconds(waitTime);
        AlertPanel.SetActive(false);
    }
}
