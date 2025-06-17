using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] Slot targetSlot;
    [SerializeField] Text targetText;
    [SerializeField] string changedMessage;

    private Item lastItem =null;

    // Update is called once per frame
    void Update()
    {
        Item currentItem = targetSlot.GetItem();

        // スロットに新しいアイテムが入ったら
        if (currentItem != null && currentItem != lastItem)
        {
            targetText.text = changedMessage;
            lastItem = currentItem;
        }
    }
}
