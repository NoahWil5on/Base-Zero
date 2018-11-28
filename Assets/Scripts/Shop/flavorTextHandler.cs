using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class flavorTextHandler : MonoBehaviour {

    public GameObject statHeaders;
    public GameObject background;

    public GameObject flavorTextManager;
    public Text damageText;
    public Text fireRateText;
    public Text accuracyText;
    public Text recoilText;
    public Text magSizeText;
    public Text flavorText;

    public GameObject akRef;
    public GameObject m4Ref;
    public GameObject battleRifleRef;

    // Use this for initialization
    void Start () {
		
	}

    public void hideAllChildren()
    {
        foreach (Transform child in flavorTextManager.transform)
        {
            child.gameObject.SetActive(false);
            hideAllChildren();
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (akRef.activeSelf == true)
        {
            background.SetActive(true);
            statHeaders.SetActive(true);

            damageText.text = "30";
            fireRateText.text = "Fast";
            accuracyText.text = "20";
            recoilText.text = "High";
            magSizeText.text = "30";

            flavorText.text = "This gun is commonly used by jihadists and residents of Chicago, IL.";
        }
        else if (m4Ref.activeSelf == true)
        {
            background.SetActive(true);
            statHeaders.SetActive(true);

            damageText.text = "50";
            fireRateText.text = "Medium";
            accuracyText.text = "40";
            recoilText.text = "Medium";
            magSizeText.text = "30";

            flavorText.text = "army gun good";
        }
        else if (battleRifleRef.activeSelf == true)
        {
            background.SetActive(true);
            statHeaders.SetActive(true);

            damageText.text = "60";
            fireRateText.text = "Low";
            accuracyText.text = "40";
            recoilText.text = "Low";
            magSizeText.text = "20";

            flavorText.text = "cool gun here";
        }
        else
        {
            background.SetActive(false);
            statHeaders.SetActive(false);
           
        }

    }

}
