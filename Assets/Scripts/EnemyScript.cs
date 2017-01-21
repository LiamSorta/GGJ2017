using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    bool Stance;
    GameMaster GM;
    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
        GM = GameObject.FindObjectOfType<GameMaster>();
        int value = Random.Range(0, 100);
        if (value >= 50)
        {
            Stance = false;
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else
        {
            Stance = true;
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(-Vector3.right * GM.GetSpeed());
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
