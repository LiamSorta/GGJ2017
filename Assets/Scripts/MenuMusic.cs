using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {
    AudioSource[] AS;

	// Use this for initialization
	void Start () {
        AS = GetComponents<AudioSource>();
        Debug.Log(AS[0].clip.samples);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            AS[1].Play();
        }
	}
}
