using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    int activePlayers = 4                       ;
    public GameObject confetti;
    public GameObject Restart;
    GameMaster GM;
    AudioSource[] DeathPlayer;

    void Awake()
    {
        GM = GameObject.FindObjectOfType<GameMaster>();
        DeathPlayer = gameObject.GetComponents<AudioSource>();
        
        Restart.SetActive(false);
    }

    public void DeadPlayer()
    {
        int Index = Random.Range(0, GM.Deaths.Count);
        DeathPlayer[0].clip = GM.Deaths[Index];
        DeathPlayer[0].Play();
        GM.Deaths.RemoveAt(Index);
        //Debug.Log(activePlayers);
        activePlayers--;
        if(activePlayers == 1)
        {
            Victory();
        }
    }

	void Victory()
    {
        GM.SetPlaying(false);
        Restart.SetActive(true);
        confetti.SetActive(true);
        confetti.GetComponent<AudioSource>().Play();

    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") && !GM.GetPlaying())
        {
            foreach (SpriteRenderer each in GM.Warnings)
            {
                Destroy(each.gameObject);
            }
            
            DestroyObject(GM);
            Application.LoadLevel(0);
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
