using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathChecker : MonoBehaviour {

    public GameObject landerShip;
    public bool dead;
    private bool disableShip;

    public GameObject deathOverlay;

    public EdgeCollider2D landersh;

    public Animator landerShipAnim;

    private void Start()
    {
        deathOverlay = GameObject.Find("deathChecker");
    }

    // Update is called once per frame
    void Update() {
        if (disableShip == true)
        {
            landerShip.SetActive(false);
        }

        if (dead == true)
        {
            StartCoroutine(animationPlayer());
        }
    }

    IEnumerator animationPlayer()
    {

        landerShipAnim.SetBool("Dead", true);

        landersh.enabled = false;

        yield return new WaitForSeconds(0.2f);

        disableShip = true;
    }
}
