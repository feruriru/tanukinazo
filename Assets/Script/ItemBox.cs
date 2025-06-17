using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    // アイテムボックスがすべてのスロットを取得
    [SerializeField] Slot[] slots = default;

    // どこからでもアクセスできるようにする
    public static ItemBox instance;
    Slot selectSlot; // 選択中のスロット
    public GameObject ItemBoxCanvas;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }     
    }

    private IEnumerator Start()
    {
        yield return null;

        if(ItemBoxManager.Instance != null)
        {
          ItemBoxManager.Instance.LoadItemBox();
        }
    }

    // アイテムを受け取る処理
    public void SetItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            if (slot.IsEmpty()) // 空のスロットがあるかチェック
            {
                slot.Set(item); // アイテムをスロットにセット
                break;
            }
        }
    }

    public Slot[] GetSlots()
    {
        return slots;
    }

    // スロットをクリックしたら選択状態にする
    public void OnSlotClick(int position)
    {
        if (slots[position].IsEmpty()) return; // 空のスロットなら何もしない

        // すべてのスロットの選択枠を非表示にする
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].HideBackPanel();
        }

        // クリックしたスロットの枠を表示
        slots[position].OnSelect();
        selectSlot = slots[position]; // 選択状態として保存
    }

    // 選択中のアイテムが特定のタイプかどうか判定
    public bool CheckSelectItem(Item.Type useItemType)
    {
        if (selectSlot == null) return false;
        return selectSlot.GetItem().type == useItemType;
    }

    // 選択中のアイテムを使用して削除
    public void UseSelectItem()
    {
        selectSlot.RemoveItem();
        selectSlot = null;
    }
}