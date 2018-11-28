using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponButton : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void unHideElement(GameObject element)
    {
        element.SetActive(true);
    }
    public void hideElement(GameObject element)
    {
        element.SetActive(false);
    }
    public void hideAllChildren(GameObject parentOfChildren)
    {
        foreach(Transform child in parentOfChildren.transform)
        {
            child.gameObject.SetActive(false);
            hideAllChildren(child.gameObject);
        }
    }
    public void unhideAllChildren(GameObject parentOfChildren)
    {
        foreach (Transform child in parentOfChildren.transform)
        {
            child.gameObject.SetActive(true);
            hideAllChildren(child.gameObject);
        }
    }
}
