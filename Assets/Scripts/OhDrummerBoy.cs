using UnityEngine;
using System.Collections;

public class OhDrummerBoy : MonoBehaviour {


    public AudioClip[] drums;

	// Use this for initialization
	void Start () {
        int num = Random.Range(0, 4);
        GetComponent<AudioSource>().clip = drums[num];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
