using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public Button button;
    public Text nameText;
    public Image iconImg;
    public Text priceText;

    private Item it;
    private ItemList il;
	// Use this for initialization
	void Start () {
        button.onClick.AddListener(HandleClick) ;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void Setup(Item currentItem, ItemList list)
    {
        it = currentItem;
        nameText.text = it.itemName;
        priceText.text = it.price.ToString();
        iconImg.sprite = it.icon;

        il = list; 
    }

    public void HandleClick()
    {
        PlayerPrefs.SetString("clickedButton", this.nameText.text);
        SceneManager.LoadScene("doMagic");
    }
}
