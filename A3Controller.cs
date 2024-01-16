using UnityEngine;

public class A3Controller : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup component not found on " + gameObject.name);
        }
    }

    public void ToggleA3Visibility()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = (canvasGroup.alpha == 0) ? 1 : 0;
            canvasGroup.interactable = !canvasGroup.interactable;
            canvasGroup.blocksRaycasts = !canvasGroup.blocksRaycasts;
        }
    }

    public bool IsActive()
    {
        return (canvasGroup != null) ? canvasGroup.alpha > 0 : false;
    }
}
