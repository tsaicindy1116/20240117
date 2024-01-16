using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonInteraction : MonoBehaviour
{
    [System.Serializable]
    public struct ButtonGroup
    {
        public Button buttonA;
        public Button buttonA1;
        public Button buttonA2;
        public Button buttonA3;
        public A3Controller a3Controller;  // 新增 A3Controller 物件
        public string groupName;
    }

    public ButtonGroup[] buttonGroups;

    private bool isDragging = false;
    private bool isAOverA1 = false;
    private Vector2 initialPosition;

    void Awake()
    {
        for (int i = 0; i < buttonGroups.Length; i++)
        {
            int index = i;

            if (buttonGroups[i].buttonA.gameObject.activeInHierarchy)
            {
                buttonGroups[i].buttonA.onClick.AddListener(() => { OnAClick(index); });
                buttonGroups[i].buttonA1.onClick.AddListener(() => { OnA1Click(index); });
                buttonGroups[i].buttonA2.onClick.AddListener(() => { OnA2Click(index); });

                // 添加拖曳事件
                EventTrigger trigger = buttonGroups[i].buttonA.gameObject.AddComponent<EventTrigger>();
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.BeginDrag;
                entry.callback.AddListener((data) => { OnBeginDrag(index, (PointerEventData)data); });
                trigger.triggers.Add(entry);

                entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.Drag;
                entry.callback.AddListener((data) => { OnDrag(index, (PointerEventData)data); });
                trigger.triggers.Add(entry);

                entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.EndDrag;
                entry.callback.AddListener((data) => { OnEndDrag(index, (PointerEventData)data); });
                trigger.triggers.Add(entry);

                if (buttonGroups[i].buttonA3 == null)
                {
                    Debug.LogError("ButtonA3 not connected in ButtonGroup " + i);
                    return;
                }

                // 記錄按鈕的初始位置
                initialPosition = buttonGroups[index].buttonA.GetComponent<RectTransform>().anchoredPosition;
                SetA2ButtonActive(index, false);
            }
        }
    }

    void OnAClick(int groupIndex)
    {
        // 如果正在拖曳 A 按鈕，不觸發點擊事件
        if (isDragging)
            return;

        if (!isAOverA1)
        {
            switch (buttonGroups[groupIndex].groupName)
            {
                case "Group1":
                    SceneManager.LoadScene("2");
                    break;
                case "Group2":
                    SceneManager.LoadScene("03");
                    break;
                default:
                    break;
            }
        }

        // 新增：切換 A3 按鈕的顯示狀態
        buttonGroups[groupIndex].a3Controller.ToggleA3Visibility();
    }

    void OnA1Click(int groupIndex)
    {
        // 切換 A3 按鈕的顯示狀態
        buttonGroups[groupIndex].a3Controller.ToggleA3Visibility();
    }

    void OnA2Click(int groupIndex)
    {
        // 切換 A3 按鈕的顯示狀態
        buttonGroups[groupIndex].a3Controller.ToggleA3Visibility();
    }

    void OnBeginDrag(int groupIndex, PointerEventData eventData)
    {
        // 在拖曳開始時
        isDragging = true;
        isAOverA1 = false; // 重置狀態
        SetA2ButtonActive(groupIndex, false); // 隱藏 A2 按鈕
        SetA3ButtonActive(groupIndex, false); // 隱藏 A3 按鈕
    }

    void OnDrag(int groupIndex, PointerEventData eventData)
    {
        if (isDragging)
        {
            // 將按鈕的位置跟隨鼠標移動
            RectTransform rt = buttonGroups[groupIndex].buttonA.GetComponent<RectTransform>();
            Vector2 localPointerPosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rt.parent as RectTransform, eventData.position, eventData.pressEventCamera, out localPointerPosition);
            rt.localPosition = localPointerPosition;

            // 檢測A按鈕是否被拖拉到A1按鈕上
            isAOverA1 = IsPointerOverButton(eventData.position, buttonGroups[groupIndex].buttonA1);
        }
    }

    void OnEndDrag(int groupIndex, PointerEventData eventData)
    {
        isDragging = false;

        // 在 LateUpdate 中確保 A2 按鈕的顯示和隱藏判斷
        StartCoroutine(DelayedShowA2(groupIndex, isAOverA1));

        // 新增：拖曳結束後恢復按鈕到初始位置
        if (gameObject.activeInHierarchy)  // 檢查遊戲物件是否處於活動狀態
        {
            StartCoroutine(MoveButtonToInitialPosition(groupIndex));
        }

        // 移除拖曳結束後取消的點擊事件
        buttonGroups[groupIndex].buttonA.onClick.RemoveAllListeners();
        // 重新添加點擊事件
        buttonGroups[groupIndex].buttonA.onClick.AddListener(() => { OnAClick(groupIndex); });

        // 新增：除錯輸出
        Debug.Log("OnEndDrag - A3 Visibility: " + buttonGroups[groupIndex].a3Controller.IsActive());
    }

    IEnumerator MoveButtonToInitialPosition(int groupIndex)
    {
        if (!gameObject.activeInHierarchy)
        {
            yield break;  // 如果遊戲物件不處於活動狀態，則中止協程
        }

        // 等待一幀，確保 UI 更新完畢
        yield return null;

        // 恢復按鈕到初始位置
        buttonGroups[groupIndex].buttonA.GetComponent<RectTransform>().anchoredPosition = initialPosition;
    }

    IEnumerator DelayedShowA2(int groupIndex, bool shouldShow)
    {
        yield return new WaitForSeconds(0.01f); // 簡短的延遲等待 UI 更新

        // 根據檢測結果顯示/隱藏A2按鈕
        SetA2ButtonActive(groupIndex, shouldShow);
    }

    void SetA2ButtonActive(int groupIndex, bool active)
    {
        CanvasGroup canvasGroupA2 = buttonGroups[groupIndex].buttonA2.GetComponent<CanvasGroup>();

        if (canvasGroupA2 != null)  // 確保 canvasGroupA2 不為空
        {
            if (active)
            {
                // A2 出現時隱藏 A1 與 A 按鈕
                buttonGroups[groupIndex].buttonA1.gameObject.SetActive(false);
                buttonGroups[groupIndex].buttonA.gameObject.SetActive(false);

                canvasGroupA2.alpha = 1f;
                canvasGroupA2.interactable = true;
                canvasGroupA2.blocksRaycasts = true;
            }
            else
            {
                // A2 隱藏時顯示 A1 與 A 按鈕
                buttonGroups[groupIndex].buttonA1.gameObject.SetActive(true);
                buttonGroups[groupIndex].buttonA.gameObject.SetActive(true);

                canvasGroupA2.alpha = 0f;
                canvasGroupA2.interactable = false;
                canvasGroupA2.blocksRaycasts = false;
            }
        }
        else
        {
            Debug.LogError("CanvasGroupA2 is null in ButtonGroup " + groupIndex);
        }
    }

    void SetA3ButtonActive(int groupIndex, bool active)
    {
        A3Controller a3Controller = buttonGroups[groupIndex].buttonA3.GetComponent<A3Controller>();

        if (a3Controller != null)
        {
            a3Controller.ToggleA3Visibility();
        }
    }

    bool IsPointerOverButton(Vector2 position, Button button)
    {
        // 檢測滑鼠位置是否在按鈕上
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        Vector2 localPointerPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, position, null, out localPointerPosition);

        // 調整位置以更靈活地判斷是否在按鈕上
        Rect rect = new Rect(rectTransform.localPosition.x - rectTransform.rect.width / 2f,
                             rectTransform.localPosition.y - rectTransform.rect.height / 2f,
                             rectTransform.rect.width, rectTransform.rect.height);
        return rect.Contains(localPointerPosition);
    }
}
