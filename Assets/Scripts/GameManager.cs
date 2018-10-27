using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private Dictionary<string, int> weaponAmmo = new Dictionary<string, int>();
    private int playerCash = 0;
    private int playerScraps = 0;

    void Start(){
        weaponAmmo.Add("LMG", 0);
        weaponAmmo.Add("AR", 20);
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
