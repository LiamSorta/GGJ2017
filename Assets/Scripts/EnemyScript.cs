using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    bool Stance;
    GameMaster GM;
    public Sprite[] sprites;
    SpriteRenderer sr;
    // Use this for initialization

        void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

    }
    void Start () {
        GM = GameObject.FindObjectOfType<GameMaster>();
        int value = Random.Range(0, 100);
        if (value >= 50)
        {
            Stance = false;
            sr.sprite = sprites[1];
        }
        else
        {
            Stance = true;
            sr.sprite = sprites[0];
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
        sr.color = colour;
    }
}
