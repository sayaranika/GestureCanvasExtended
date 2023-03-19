using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    /// <summary>
    /// Blinking Effect of the Rec Label in Record Scene
    /// </summary>

    public Color startColor = Color.red;
    public Color endColor = Color.black;
    [Range(0, 10)]
    public float speed = 1;

    Image imgComp;

    void Awake()
    {
        imgComp = GetComponent<Image>();
    }

    void Update()
    {
        imgComp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
    }
}
