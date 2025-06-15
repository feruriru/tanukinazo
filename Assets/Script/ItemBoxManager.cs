using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxManager : MonoBehaviour
{
  public static ItemBoxManager Instance;

  public List<Item> savedItems = new List<Item>();

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }
  
  public void SaveItemBox()
  {
    savedItems.Clear();
    foreach (var slot in ItemBox.instance.GetSlots())
    {
      savedItems.Add(slot.GetItem());
    }
  }

  public void LoadItemBox()
  {
    Slot[] slots = ItemBox.instance.GetSlots();
    for(int i = 0; i < savedItems.Count && i < slots.Length; i++)
    {
      if(savedItems[i] !=null)
      {
        slots[i].Set(savedItems[i]);    
      }
    }
  }
}

