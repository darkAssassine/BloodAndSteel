using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Screenshake : MonoBehaviour
{
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
        GameEvents.Instance.Screenshake += ShakeScreen;
    }




    private void ShakeScreen(AnimationCurve curve)
    {
        StartCoroutine(Shaking(curve));
    }

    private IEnumerator Shaking(AnimationCurve curve)
    {
        float elapsedTime = 0f;
        float duration = curve[curve.length - 1].time;

        while (elapsedTime < duration && Time.timeScale > 0.5f)
        {
            elapsedTime += Time.deltaTime;
            transform.localPosition += new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0) * curve.Evaluate(elapsedTime);
            yield return null;
        }
        transform.localPosition = startPos;
        yield return null;
    }
}
