using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public float price = 1;
}

public class ItemList : MonoBehaviour {

    public List<Item> itemList;
    public Transform contentPanel;
    public ObjectPool buttonObjectPool;

    // Use this for initialization
    void Start () {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        AddButtons();
    }
	
    private void AddButtons()
    {
        for(int i=0; i<itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            ButtonScript sampleButton = newButton.GetComponent<ButtonScript>();
            sampleButton.Setup(item, this);
        }
    }
}
