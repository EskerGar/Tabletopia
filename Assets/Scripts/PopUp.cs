using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] private Image imageColor;
    [SerializeField] private Text text;

    public void Show(Color color)
    {
        StopAllCoroutines();
        text.color = Color.black;
        imageColor.color = color;
        StartCoroutine(LerpFunction(Color.clear, 3f));
    }
    
    private IEnumerator LerpFunction( Color endValue, float duration)
    {
        float time = 0;
        var startImageValue =  imageColor.color;
        var startTextValue = text.color;
        while (time < duration)
        {
            imageColor.color = Color.Lerp(startImageValue, endValue, time / duration);
            text.color = Color.Lerp(startTextValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        imageColor.color = endValue;
        text.color = endValue;
    }

    private void Start()
    {
        imageColor.color = Color.clear;
        text.color = Color.clear;
    }
}
