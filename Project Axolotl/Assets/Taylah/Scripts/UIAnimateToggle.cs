using UnityEngine;
using System.Collections;

public class UIAnimateToggle : MonoBehaviour
{
    public GameObject uiObject;
    public float animationDuration = 0.35f;
    public AnimationCurve animationCurve; // Add this in Inspector

    public Vector3 hiddenScale = Vector3.zero;
    public Vector3 shownScale = Vector3.one;

    private Coroutine currentRoutine;

    private void Awake()
    {
        if (uiObject != null)
        {
            uiObject.transform.localScale = hiddenScale;
            uiObject.SetActive(false);
        }
    }

    public void ShowUI()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        uiObject.SetActive(true);
        uiObject.transform.localScale = hiddenScale;
        currentRoutine = StartCoroutine(ScaleUI(shownScale, true));
    }

    public void HideUI()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(ScaleUI(hiddenScale, false));
    }

    private IEnumerator ScaleUI(Vector3 targetScale, bool setActiveOnEnd)
    {
        float time = 0f;
        Vector3 startScale = uiObject.transform.localScale;

        while (time < animationDuration)
        {
            float curveValue = animationCurve.Evaluate(time / animationDuration);
            uiObject.transform.localScale = Vector3.LerpUnclamped(startScale, targetScale, curveValue);
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        uiObject.transform.localScale = targetScale;

        if (!setActiveOnEnd)
            uiObject.SetActive(false);
    }
}


