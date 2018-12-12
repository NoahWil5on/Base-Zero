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

    public GameObject m9Ref;
    public GameObject thompsonRef;
    public GameObject saigaRef;
    public GameObject akRef;
    public GameObject m4Ref;
    public GameObject svdRef;
    public GameObject magRef;
    

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
        if(m9Ref.activeSelf == true)
        {
            background.SetActive(true);
            statHeaders.SetActive(true);

            damageText.text = "20";
            fireRateText.text = "Fast";
            accuracyText.text = "50";
            recoilText.text = "Low";
            magSizeText.text = "15";

            flavorText.text = "The latest in miltary sidearms, this handgun features high capacity magazines with great accuracy.";
        }
        else if (saigaRef.activeSelf == true)
        {
            background.SetActive(true);
            statHeaders.SetActive(true);

            damageText.text = "30";
            fireRateText.text = "Fast";
            accuracyText.text = "20";
            recoilText.text = "High";
            magSizeText.text = "30";

            flavorText.text = "Saiga.";
        }
        else if (thompsonRef.activeSelf == true)
        {
            background.SetActive(true);
            statHeaders.SetActive(true);

            damageText.text = "30";
            fireRateText.text = "Fast";
            accuracyText.text = "20";
            recoilText.text = "High";
            magSizeText.text = "30";

            flavorText.text = "Heavy SMG.";
        }
        else if (akRef.activeSelf == true)
        {
            background.SetActive(true);
            statHeaders.SetActive(true);

            damageText.text = "30";
            fireRateText.text = "Fast";
            accuracyText.text = "20";
            recoilText.text = "High";
            magSizeText.text = "30";

            flavorText.text = "Durable and powerful, this assault rifle is used by both military forces and terrorist forces alike.";
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

            flavorText.text = "The M4 carbine is one of the most reliable and field-tested rifles out there. Trust it.";
        }
        else if (svdRef.activeSelf == true)
        {
            background.SetActive(true);
            statHeaders.SetActive(true);

            damageText.text = "50";
            fireRateText.text = "Medium";
            accuracyText.text = "40";
            recoilText.text = "Medium";
            magSizeText.text = "30";

            flavorText.text = "SVD.";
        }
        else if (magRef.activeSelf == true)
        {
            background.SetActive(true);
            statHeaders.SetActive(true);

            damageText.text = "50";
            fireRateText.text = "Medium";
            accuracyText.text = "40";
            recoilText.text = "Medium";
            magSizeText.text = "30";

            flavorText.text = "MAG.";
        }
        else
        {
            background.SetActive(false);
            statHeaders.SetActive(false);
           
        }

    }

}
