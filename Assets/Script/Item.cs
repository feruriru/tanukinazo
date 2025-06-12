using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Inspectorに表示できる
public class Item
{
    // アイテムの種類
    public enum Type
    {
        raccoon,
        knife,
        // アイテムを追加
    }

    // アイテムのタイプ保持
    public Type type;

    // アイテムの画像保持
    public Sprite sprite;

    // コンストラクタ＝アイテム情報コピー
    public Item(Item item)
    {
        this.type = item.type;
        this.sprite = item.sprite;
    }
}
