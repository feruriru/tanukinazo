using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] Slot targetSlot;
    [SerializeField] Text targetText;
    [SerializeField] string changedMessage;
    [SerializeField] GameObject objectToHide; 
    [SerializeField] GameObject nextButtonObject;

    private Item lastItem =null;
    private bool hasTriggered = false;

    void Start()
    {
        if(nextButtonObject != null)
          nextButtonObject.SetActive(false);
    }

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

        if(!hasTriggered && targetText.text == changedMessage)
        {
            hasTriggered = true;

            if(objectToHide != null)
              objectToHide.SetActive(false);

            if(nextButtonObject != null)
              nextButtonObject.SetActive(true);
        }
    }
}
