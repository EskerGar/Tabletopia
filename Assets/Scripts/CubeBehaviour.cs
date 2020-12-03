using System.Collections;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject clickText;

    private Color _cubeColor;
    private TextMesh _textMesh;
    private Vector3 _textPositionOffset;

    public void ShowText()
    {
        StopAllCoroutines();
        clickText.transform.position = transform.position + _textPositionOffset;
        clickText.transform.up = Vector3.up;
        _textMesh.color = _cubeColor;
        StartCoroutine(LerpFunction(Color.clear, 3));
    }
    
    private IEnumerator LerpFunction( Color endValue, float duration)
    {
        float time = 0;
        var startValue =  _textMesh.color;

        while (time < duration)
        {
            _textMesh.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            clickText.transform.position  += new Vector3(0f, Time.deltaTime, 0f);
            yield return null;
        }
        _textMesh.color = endValue;
    }

    private void Start()
    {
        _cubeColor = GetComponent<MeshRenderer>().material.color;
        _textMesh = clickText.GetComponent<TextMesh>();
        _textMesh.color = Color.clear;
        _textPositionOffset = clickText.transform.position - transform.position;
    }
}