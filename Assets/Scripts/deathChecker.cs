using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathChecker : MonoBehaviour {

    public GameObject landerShip;
    public bool dead;

    public BoxCollider2D landersh;

    public Animator landerShipAnim;

    private playerController playerContr;

	// Use this for initialization
	void Start () {
        playerContr = FindObjectOfType<playerController>();
	}

    // Update is called once per frame
    void Update() {
        if (dead == true)
        {
            StartCoroutine(animationPlayer());
        }
    }

    IEnumerator animationPlayer()
    {
        landerShipAnim.SetBool("Dead", true);

        landersh.enabled = false;

        yield return new WaitForSeconds(1);

        landerShip.SetActive(false);
    }
}
