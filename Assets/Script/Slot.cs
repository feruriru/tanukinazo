using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject backPanel = default; // 選択枠
    [SerializeField] Image image = default;
    Item item = null;
    private static Item selectedItem = null;
    private static Slot selectedSlot = null;

     private void Start()
    {
        // 初期状態では枠を非表示
        backPanel.SetActive(false);
    }

    // アイテムをセットする
    public void Set(Item item) 
    {
        this.item = item;
        image.sprite = item.sprite;
        Debug.Log("get")
;    }

     // アイテムをスロットから削除
    public void RemoveItem() 
    {
        item = null;
        image.sprite = null;      
        HideBackPanel(); // 枠も非表示にする
    }

    // アイテム情報を取得
    public Item GetItem() 
    {
        return item;
    }

    // スロットが空かどうかを判定する
    public bool IsEmpty() 
    {
        return item == null;
    }

     // アイテムを選択したときに枠を表示
    public void OnSelect()
    {
        backPanel.SetActive(true);      
    }

    // 選択を解除（枠を非表示）
    public void HideBackPanel()
    {
        backPanel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(selectedItem == null && item != null)
        {
            selectedItem = item;
            selectedSlot = this;

            RemoveItem();
            OnSelect();
        }
        else if(selectedItem != null)
        {
            if(this == selectedSlot)
            {
                Set(selectedItem);
                selectedItem = null;
                selectedSlot = null;
                HideBackPanel();
                return;
            }

            Item temp = item;
            Set(selectedItem);

            if(selectedSlot != null)
            {
                if(temp != null)
                  selectedSlot.Set(temp);
                else
                  selectedSlot.HideBackPanel();  
            }

            selectedItem = null;
            selectedSlot = null;
        }
    }

}

