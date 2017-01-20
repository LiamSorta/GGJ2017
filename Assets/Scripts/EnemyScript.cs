using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    bool Stance;

	// Use this for initialization
	void Start () {
        int value = Random.Range(0, 100);
        if (value >= 50)
        {
            Stance = false;
        }
        else
        {
            Stance = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.right * EnemyController.Speed * Time.deltaTime);
	}

    public void DIE()
    {
        GameObject.Destroy(gameObject);
    }

    public bool GetStance()
    {
        return Stance;
    }

    public void SetColor(Color32 colour)
    {

    }
}
