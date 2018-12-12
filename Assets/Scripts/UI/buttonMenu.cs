using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class buttonMenu : MonoBehaviour {

    private GameObject player;
    private GameObject gm;
    private GameObject canvas;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindGameObjectWithTag("gm");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Destroy(player);
        Destroy(gm);
        Destroy(canvas);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void switchScene()
    {
        SceneManager.LoadScene(1);
    }
}
