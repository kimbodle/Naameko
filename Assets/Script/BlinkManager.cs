using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public float duration = 1f;

    private void Start()
    {
        StartCoroutine(FadeText());
    }

    public IEnumerator FadeText()
    {
        while (true)
        {
            // 0에서 1로 서서히 변화시킵니다.
            for (float t = 0.01f; t < 1; t += Time.deltaTime / duration)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(0, 1, t));
                yield return null;
            }

            // 1에서 0으로 서서히 변화시킵니다.
            for (float t = 0.01f; t < 1; t += Time.deltaTime / duration)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(1, 0, t));
                yield return null;
            }
        }
    }
}
