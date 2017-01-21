using UnityEngine;
using System.Collections;

public class ShieldFade : MonoBehaviour {

    SpriteRenderer SpRenderer;
    Vector3 bumPos;
    Vector3 crotchPos;

    float flashMe;

	// Use this for initialization
	void Start () {

        SpRenderer = GetComponent<SpriteRenderer>();
        crotchPos = transform.localPosition;
        bumPos = new Vector3(-crotchPos.x, crotchPos.y, crotchPos.z);
        Live(false);
    }
	
    public void Flasher()
    {
        flashMe = Time.time + 0.3f;
    }

    void Update()
    {
        if(flashMe > Time.time)
        {
            SpRenderer.enabled = !SpRenderer.enabled;
        }
        else
        {
            SpRenderer.enabled = true;
        }
    }

	public void Live(bool isInUse)
    {

        Flasher();

        if (isInUse)
        {

            Debug.Log("BOOP");
            transform.localPosition = crotchPos;
            transform.localScale = new Vector3(1,1,1);
            SpRenderer.sortingOrder = 40;
        }
        else
        {
            Debug.Log(crotchPos.x);
            transform.localPosition = bumPos;
            transform.localScale = new Vector3(-1, 1, 1);
            SpRenderer.sortingOrder = -40;
        }
    }
}
