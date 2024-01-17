using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image dialogueBoxImage;
    public Text dialogueText;
    public Button nextButton;
    public Button previousButton;

    private string[] dialogueLines;
    private int currentLine = 0;

    // 新增角色相關屬性
    public Image[] characters;
    public Vector3[] characterPositionusing UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image dialogueBoxImage;
    public Text dialogueText;
    public Button nextButton;
    public Button previousButton;

    private string[] dialogueLines;
    private int currentLine = 0;

    // 新增角色相關屬性
    public Image[] characters;
    public Vector3[] characterPositions;
    public Vector3 characterHiddenPosition;

    void Start()
    {
        dialogueBoxImage.gameObject.SetActive(false);
        nextButton.onClick.AddListener(() => DisplayNextLine());
        previousButton.onClick.AddListener(GoToPreviousLine);

        // Load dialogue data or set it programmatically
        dialogueLines = new string[]
        {
            //軍事科技1
            "今天將大家召集在這裡是因為我們發現了海洋上面有一大片的石油",
            "我們目前監測它的擴散的範圍已經超過一個台灣那麼大了…",
            //水產養殖3
            "難怪最近養殖場內的魚都出現了大量中毒甚至死亡的狀況！",
            "害我損失慘重!",
            //觀光遊憩5
            "我們才慘吧…",
            "原本都會爆滿的遊客也因為聽到了海上漏油事件而不敢來海邊",
            "一周內大量的珊瑚開始白化，整個旅遊業都受到了很大的影響耶…",
            //水產養殖8
            "只不過到底是因為什麼原因，海洋上會出現這麼大規模的石油外漏呢?",
            "難道是哪一艘船沒有定期向船舶輪機領域的人檢測維修船隻?",
            "還是檢測出現了疏失才會…. ",
            //船舶輪機11
            "這怎麼可能!",
            "我們檢測船都是嚴謹又認真的去檢測，我也是很納悶為什麼會有漏油事件",
            "說不定是海底石油管道破裂才導致海洋上面的石油汙染呢? ",
            //商船運輸14
            "大家先別吵是誰的責任了",
            "目前為了確保安全港口都已經關閉，我們船上的所有貨物都只能卡在海面上",
            "現在最重要的是趕快將海面上的石油清理乾淨我們才有辦法繼續正常的運行吧? ",
            //海洋科學17
            "我們要先去海上採集樣本回到實驗室來看是哪一個類型的石油",
            "才知道如何回溯是誰的責任，以及評估大概會有多少生物受到影響",
            "不過清理石油污染的話我們還需要海洋工程的幫忙",
            //海洋工程20
            "那有什麼問題",
            "我們有先進的設備以及清理石油的技術，我們會盡可能地來清理海面上的石油",
            //海洋法律22
            "我們會多加派海巡人員，維護海上的安全",
            "等海洋科學的人檢測出來過後就能知道責問題的來源",
            "大家先別爭吵了，各領域的專家們心協力解決這次的困難吧!",
        };

        dialogueText.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        previousButton.gameObject.SetActive(true);

        StartDialogue();
    }

    void StartDialogue()
    {
        dialogueBoxImage.gameObject.SetActive(true);
        DisplayNextLine();
    }

    void DisplayNextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];

            // 在特定對話句之後更換角色及位置
            ChangeCharacterAndPosition();

            currentLine++;
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueBoxImage.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        previousButton.gameObject.SetActive(false);

            // 隱藏所有角色
        for (int i = 0; i < characters.Length; i++)
        {
            HideCharacter(i);
        }
        

        // Additional logic after the dialogue ends
    }

    void GoToPreviousLine()
    {
        if (currentLine > 0)
        {
            currentLine--;

            // 先更換角色及位置
            ChangeCharacterAndPosition();

            // 更新對話文本
            dialogueText.text = dialogueLines[currentLine];
        }
    }


void ChangeCharacterAndPosition()
{
    // // 在這裡實現更換角色及位置的邏輯

    //  if (currentLine == 2 || currentLine == 4 || currentLine == 7 || currentLine == 10 || currentLine == 13 || currentLine == 16 || currentLine == 19 || currentLine == 21)
    // {
    //     // 根據 currentLine 切換到前一個角色
    //     ChangeCharacter(currentLine / 3 - 1);

    //     // 移動到前一個角色的位置
    //     MoveCharacterToPosition(currentLine / 3 - 1);
    // }
    
    if (currentLine == 1)
    {
        ChangeCharacter(0); // 切換到第一個角色
        MoveCharacterToPosition(0); // 移動到第一個角色的位置
    }
    else if (currentLine == 2)
    {
        ChangeCharacter(1); // 切換到第二個角色
        MoveCharacterToPosition(1); // 移動到第二個角色的位置
    }
    else if (currentLine == 4)
    {
        ChangeCharacter(2); // 切換到第三個角色
        MoveCharacterToPosition(2); // 移動到第三個角色的位置
    }
    else if (currentLine == 7)
    {
        ChangeCharacter(1); // 切換到第三個角色
        MoveCharacterToPosition(1); // 移動到第三個角色的位置
    }
    else if (currentLine == 10)
    {
        ChangeCharacter(3); // 切換到第四個角色
        MoveCharacterToPosition(3); // 移動到第四個角色的位置
    }
    else if (currentLine == 13)
    {
        ChangeCharacter(4); // 切換到第五個角色
        MoveCharacterToPosition(4); // 移動到第五個角色的位置
    }
    else if (currentLine == 16)
    {
        ChangeCharacter(5); // 切換到第六個角色
        MoveCharacterToPosition(5); // 移動到第六個角色的位置
    }
    else if (currentLine == 19)
    {
        ChangeCharacter(6); // 切換到第七個角色
        MoveCharacterToPosition(6); // 移動到第七個角色的位置
    }
    else if (currentLine == 21)
    {
        ChangeCharacter(7); // 切換到第八個角色
        MoveCharacterToPosition(7); // 移動到第八個角色的位置
    }

}


    void ChangeCharacter(int characterIndex)
    {
        if (characters != null && characterIndex < characters.Length)
        {
                // 隱藏所有角色
                for (int i = 0; i < characters.Length; i++)
                {
                    HideCharacter(i);
                }

        // 如果 characterHiddenPosition 有效，則使用它；否則使用 Vector3.zero
        Vector3 newPosition = characterHiddenPosition != null ? characterHiddenPosition : Vector3.zero;

        characters[characterIndex].gameObject.SetActive(true);
        characters[characterIndex].transform.position = newPosition;
        // 可以根據需要更換角色圖片
        }
    }

    void HideCharacter(int characterIndex)
    {
        if (characters != null && characterIndex < characters.Length)
        {
            characters[characterIndex].gameObject.SetActive(false);
        }
    }


    void MoveCharacterToPosition(int characterIndex)
    {
        // 在這裡實現移動角色到指定位置的邏輯
        if (characterPositions.Length > characterIndex)
        {
            characters[characterIndex].transform.position = characterPositions[characterIndex];
        }
    }
}s;
    public Vector3 characterHiddenPosition;

    void Start()
    {
        dialogueBoxImage.gameObject.SetActive(false);
        nextButton.onClick.AddListener(() => DisplayNextLine());
        previousButton.onClick.AddListener(GoToPreviousLine);

        // Load dialogue data or set it programmatically
        dialogueLines = new string[]
        {
            //軍事科技1
            "今天將大家召集在這裡是因為我們發現了海洋上面有一大片的石油",
            "我們目前監測它的擴散的範圍已經超過一個台灣那麼大了…",
            //水產養殖3
            "難怪最近養殖場內的魚都出現了大量中毒甚至死亡的狀況！",
            "害我損失慘重!",
            //觀光遊憩5
            "我們才慘吧…",
            "原本都會爆滿的遊客也因為聽到了海上漏油事件而不敢來海邊",
            "一周內大量的珊瑚開始白化，整個旅遊業都受到了很大的影響耶…",
            //水產養殖8
            "只不過到底是因為什麼原因，海洋上會出現這麼大規模的石油外漏呢?",
            "難道是哪一艘船沒有定期向船舶輪機領域的人檢測維修船隻?",
            "還是檢測出現了疏失才會…. ",
            //船舶輪機11
            "這怎麼可能!",
            "我們檢測船都是嚴謹又認真的去檢測，我也是很納悶為什麼會有漏油事件",
            "說不定是海底石油管道破裂才導致海洋上面的石油汙染呢? ",
            //商船運輸14
            "大家先別吵是誰的責任了",
            "目前為了確保安全港口都已經關閉，我們船上的所有貨物都只能卡在海面上",
            "現在最重要的是趕快將海面上的石油清理乾淨我們才有辦法繼續正常的運行吧? ",
            //海洋科學17
            "我們要先去海上採集樣本回到實驗室來看是哪一個類型的石油",
            "才知道如何回溯是誰的責任，以及評估大概會有多少生物受到影響",
            "不過清理石油污染的話我們還需要海洋工程的幫忙",
            //海洋工程20
            "那有什麼問題",
            "我們有先進的設備以及清理石油的技術，我們會盡可能地來清理海面上的石油",
            //海洋法律22
            "我們會多加派海巡人員，維護海上的安全",
            "等海洋科學的人檢測出來過後就能知道責問題的來源",
            "大家先別爭吵了，各領域的專家們心協力解決這次的困難吧!",
        };

        dialogueText.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        previousButton.gameObject.SetActive(true);

        StartDialogue();
    }

    void StartDialogue()
    {
        dialogueBoxImage.gameObject.SetActive(true);
        DisplayNextLine();
    }

   void DisplayNextLine()
{
    if (currentLine < dialogueLines.Length)
    {
        dialogueText.text = dialogueLines[currentLine];

        // 在特定对话句之后更换角色及位置
        ChangeCharacterAndPositionForDialogue();

        currentLine++;
    }
    else
    {
        EndDialogue();
    }
}

void ChangeCharacterAndPositionForDialogue()
{
    // 在这里实现更换角色及位置的逻辑

    // 根据对话内容判断是否需要切换角色
    switch (currentLine)
    {
        case 2:
        case 4:
        case 7:
        case 10:
        case 13:
        case 16:
        case 19:
        case 21:
            // 在这里添加切换角色的逻辑
            ChangeCharacterAndPosition();
            break;
        // 如果有其他需要判断的对话内容，可以在这里继续添加 case 语句
    }
}

    void EndDialogue()
    {
        dialogueBoxImage.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        previousButton.gameObject.SetActive(false);

            // 隱藏所有角色
        for (int i = 0; i < characters.Length; i++)
        {
            HideCharacter(i);
        }
        

        // Additional logic after the dialogue ends
    }

    void GoToPreviousLine()
    {
        if (currentLine > 0)
        {
            currentLine--;

            // 先更換角色及位置
            ChangeCharacterAndPosition();

            // 更新對話文本
            dialogueText.text = dialogueLines[currentLine];
        }
    }


void ChangeCharacterAndPosition()
{
    // // 在這裡實現更換角色及位置的邏輯

    //  if (currentLine == 2 || currentLine == 4 || currentLine == 7 || currentLine == 10 || currentLine == 13 || currentLine == 16 || currentLine == 19 || currentLine == 21)
    // {
    //     // 根據 currentLine 切換到前一個角色
    //     ChangeCharacter(currentLine / 3 - 1);

    //     // 移動到前一個角色的位置
    //     MoveCharacterToPosition(currentLine / 3 - 1);
    // }
    
    if (currentLine == 1)
    {
        ChangeCharacter(0); // 切換到第一個角色
        MoveCharacterToPosition(0); // 移動到第一個角色的位置
    }
    else if (currentLine == 2)
    {
        ChangeCharacter(1); // 切換到第二個角色
        MoveCharacterToPosition(1); // 移動到第二個角色的位置
    }
    else if (currentLine == 4)
    {
        ChangeCharacter(2); // 切換到第三個角色
        MoveCharacterToPosition(2); // 移動到第三個角色的位置
    }
    else if (currentLine == 7)
    {
        ChangeCharacter(1); // 切換到第三個角色
        MoveCharacterToPosition(1); // 移動到第三個角色的位置
    }
    else if (currentLine == 10)
    {
        ChangeCharacter(3); // 切換到第四個角色
        MoveCharacterToPosition(3); // 移動到第四個角色的位置
    }
    else if (currentLine == 13)
    {
        ChangeCharacter(4); // 切換到第五個角色
        MoveCharacterToPosition(4); // 移動到第五個角色的位置
    }
    else if (currentLine == 16)
    {
        ChangeCharacter(5); // 切換到第六個角色
        MoveCharacterToPosition(5); // 移動到第六個角色的位置
    }
    else if (currentLine == 19)
    {
        ChangeCharacter(6); // 切換到第七個角色
        MoveCharacterToPosition(6); // 移動到第七個角色的位置
    }
    else if (currentLine == 21)
    {
        ChangeCharacter(7); // 切換到第八個角色
        MoveCharacterToPosition(7); // 移動到第八個角色的位置
    }

}


    void ChangeCharacter(int characterIndex)
    {
        if (characters != null && characterIndex < characters.Length)
        {
                // 隱藏所有角色
                for (int i = 0; i < characters.Length; i++)
                {
                    HideCharacter(i);
                }

        // 如果 characterHiddenPosition 有效，則使用它；否則使用 Vector3.zero
        Vector3 newPosition = characterHiddenPosition != null ? characterHiddenPosition : Vector3.zero;

        characters[characterIndex].gameObject.SetActive(true);
        characters[characterIndex].transform.position = newPosition;
        // 可以根據需要更換角色圖片
        }
    }

    void HideCharacter(int characterIndex)
    {
        if (characters != null && characterIndex < characters.Length)
        {
            characters[characterIndex].gameObject.SetActive(false);
        }
    }


    void MoveCharacterToPosition(int characterIndex)
    {
        // 在這裡實現移動角色到指定位置的邏輯
        if (characterPositions.Length > characterIndex)
        {
            characters[characterIndex].transform.position = characterPositions[characterIndex];
        }
    }
}
