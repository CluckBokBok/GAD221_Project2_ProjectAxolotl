using UnityEngine;

public class SimpleUIToggle : MonoBehaviour
{
    public GameObject targetUI; 

    public void ToggleUI()
    {
        if (targetUI != null)
        {
            targetUI.SetActive(!targetUI.activeSelf);
        }
    }
}
