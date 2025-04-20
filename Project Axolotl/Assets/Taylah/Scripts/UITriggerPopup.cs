using UnityEngine;
using UnityEngine.UI; // Needed for UI components
using System.Collections;

public class UITriggerPopup : MonoBehaviour
{
    public GameObject uiObject;
    public float animationDuration = 0.35f;
    public AnimationCurve animationCurve;

    public Vector3 hiddenScale = Vector3.zero;
    public Vector3 shownScale = Vector3.one;

    public Button toggleButton; // Reference to the button in the Inspector
    public Color enabledColor = Color.green;
    public Color disabledColor = Color.red;

    private Coroutine currentRoutine;
    private bool hasTriggered = false;

    // Static toggle for enabling/disabling all trigger boxes
    public static bool triggersEnabled = true;

    private void Awake()
    {
        if (uiObject != null)
        {
            uiObject.transform.localScale = hiddenScale;
            uiObject.SetActive(false);
        }

        UpdateButtonColor(); // Set initial color based on triggersEnabled
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggersEnabled) return;

        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            ShowUI();
            Time.timeScale = 0f;
        }
    }

    public void ClosePopup()
    {
        HideUI();
        Time.timeScale = 1f;
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

    
    public void ToggleTriggerBoxes()
    {
        triggersEnabled = !triggersEnabled;
        Debug.Log("Trigger boxes are now " + (triggersEnabled ? "enabled" : "disabled"));

        UpdateButtonColor();
    }

    private void UpdateButtonColor()
    {
        if (toggleButton != null)
        {
            ColorBlock colors = toggleButton.colors;
            colors.normalColor = triggersEnabled ? enabledColor : disabledColor;
            colors.highlightedColor = triggersEnabled ? enabledColor : disabledColor;
            toggleButton.colors = colors;

            
            if (toggleButton.image != null)
            {
                toggleButton.image.color = triggersEnabled ? enabledColor : disabledColor;
            }
        }
    }
}





