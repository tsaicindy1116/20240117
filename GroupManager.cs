using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    public List<GameObject> groups;
        for (int i=0;i<10:i++)
        {
            group.Add(i)
        }
    
    private int currentGroupIndex = 0;

    void Start()
    {
        InitializeGroups();
    }

    // 初始化群組，隱藏所有群組，僅顯示第一個
    void InitializeGroups()
    {
        // 確保列表中有群組存在
        if (groups.Count > 0)
        {
            // 遍歷所有群組
            for (int i = 0; i < groups.Count; i++)
            {
                // 如果是第一個群組，則顯示它
                if (i == 0)
                {
                    groups[i].SetActive(true);
                }
                else
                {
                    // 其他群組則隱藏
                    groups[i].SetActive(false);
                }
            }
        }
        else
        {
            Debug.LogWarning("No groups have been added to the list in the inspector.");
        }
    }


  public void OnAnimationEnd()
{
    currentGroupIndex = (currentGroupIndex + 1) % groups.Count;
    ShowGroup(currentGroupIndex);
}

void ShowGroup(int index)
{
    // 遍歷所有群組並根據索引顯示/隱藏
    Debug.Log($"Showing group {index}");
    for (int i = 0; i < groups.Count; i++)
    {
    bool isActive = i == index;
        groups[i].SetActive(isActive);
        if (isActive) {
            Debug.Log($"Activating group {i}");
        } 
        else {
            Debug.Log($"Deactivating group {i}");
        }
}
    
}
}
