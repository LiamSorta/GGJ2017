using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    public GameObject gameMaster;

	// Use this for initialization
	void Awake () {
	    if(GameMaster.instance == null)
        {
            Instantiate(gameMaster);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
