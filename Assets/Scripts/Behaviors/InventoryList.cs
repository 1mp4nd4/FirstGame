using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList<T> where T: class
{
    private T _item;
    public T item
    { 
        get { return _item; }
            
    }
        public InventoryList()
        {
            Debug.Log("Generic list initialized");
        }
    
    public void SetItem(T newItem)
    {
        _item = newItem;
        Debug.Log("New item added...");
    }
   
       
    
}
