using UnityEngine;
using System.Collections;

public class hohohohoho : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetButtonDown("Submit"))
        {
            Application.LoadLevel(1);
        }
	}
}
