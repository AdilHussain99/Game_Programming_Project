using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnPlayClick()
    {
        Application.LoadLevel("Level1");
    }
    public void OnHowToClick()
    {
        Application.LoadLevel("Controls");
    }
    public void OnLevel1Click()
    {
        Application.LoadLevel("Level1");
    }
    public void OnLevel2Click()
    {
        Application.LoadLevel("Level2");
    }
    public void OnLevel3Click()
    {
        Application.LoadLevel("Level3");
    }
    public void OnMenuClick()
    {
        Application.LoadLevel("Menu");
    }
}
