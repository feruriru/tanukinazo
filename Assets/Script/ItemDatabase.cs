using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    // どこからでもアクセスできるようにする
    public static ItemDatabase instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] ItemDatabaseEntity itemDatabaseEntity = default;

    // アイテムを取得する関数
    public Item Spawn(Item.Type type)
    {
        foreach (Item itemData in itemDatabaseEntity.items)
        {
            Debug.Log("seikou");
            // データベースから一致するアイテムを探す
            if (itemData.type == type)
            {
                return new Item(itemData);
            }
        }
        return null;
    }
}
