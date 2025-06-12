using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    // 取得するアイテムの種類を設定
    public Item.Type type = default;

    // アイテムをクリックしたときの処理
    public void OnClickObject()
    {
        // アイテムデータベースからアイテム情報を取得
        Item item = ItemDatabase.instance.Spawn(type);
        // アイテムボックスにアイテムを追加
        if (item != null)
        {
            ItemBox.instance.SetItem(item);
        }

        // クリックしたアイテムを非表示にする
        gameObject.SetActive(false);
    }
}