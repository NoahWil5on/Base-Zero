using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Dictionary<string, int> weaponAmmo = new Dictionary<string, int>();
    public int playerCash = 0;
    public int playerScraps = 0;
    public int startingAmmo = 500;
    void Start(){
        weaponAmmo.Add("LMG", startingAmmo);
        weaponAmmo.Add("AR", startingAmmo);
    }
    public int GetPlayerCash(){
        return playerCash;
    }
    public int GetPlayerScraps(){
        return playerScraps;
    }
    public void AddScraps(int scraps){
        playerScraps += scraps;
    }
    public void AddCash(int cash){
        playerCash += cash;
    }
    public int CheckAmmo(string ammoType){


        return weaponAmmo[ammoType];
    }
    public void AddAmmo(string ammoType, int ammoCount){
        weaponAmmo[ammoType] += ammoCount;
        Mathf.Clamp(weaponAmmo[ammoType], 0, 2000);
    }
}
