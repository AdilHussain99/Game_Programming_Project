using UnityEngine;
using System.Collections;
/*
    Author: Adil Hussain
    Date Created: 22nd April 2016
    Description: Go To Level 2
    Last Modified: 22nd April 2016
*/
public class PortalToLevel2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTrigger2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            Application.LoadLevel("Level2");
        }
    }
}
