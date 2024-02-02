using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    public List<GameObject> groups; // 存储所有群组的列表
    private int currentGroupIndex = 0; // 当前显示的群组索引

    void Start()
    {
        InitializeGroups();
    }

    void InitializeGroups()
    {
        // 隐藏所有群组
        foreach (var group in groups)
        {
            group.SetActive(false);
        }

        // 显示当前群组
        if (groups.Count > 0 && currentGroupIndex < groups.Count)
        {
            groups[currentGroupIndex].SetActive(true);
        }
    }

    public void ShowNextGroup()
    {
        // 隐藏当前群组
        groups[currentGroupIndex].SetActive(false);

        // 更新索引并显示下一个群组
        currentGroupIndex = (currentGroupIndex + 1) % groups.Count;
        groups[currentGroupIndex].SetActive(true);
        Debug.Log("Showing next group.");
    }

    // 附加：如果需要，可以添加一个方法来显示特定索引的群组
    public void ShowGroup(int index)
    {
        if (index >= 0 && index < groups.Count)
        {
            // 隐藏所有群组
            foreach (var group in groups)
            {
                group.SetActive(false);
            }

            // 显示指定索引的群组
            groups[index].SetActive(true);
            currentGroupIndex = index; // 更新当前群组索引
        }
    }

    // 接收AnimationFinished消息并触发ShowNextGroup方法
    public void ReceiveAnimationFinishedMessage()
    {
        ShowNextGroup();
    }
}
