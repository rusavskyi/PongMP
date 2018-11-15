using UnityEngine;
using System.Collections;

public class PlayerGateScript : MonoBehaviour {

    // Use this for initialization

    GameObject wallFound;
    bool destroyedWall = false;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!destroyedWall)
        {
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
            foreach (GameObject wall in walls)
            {
                if (Vector3.Distance(wall.transform.position, this.transform.position) < 1f)
                {
                    print("Disabling wall!");
                    wall.SetActive(false);
                    destroyedWall = true;
                    wallFound = wall;
                }
            }
        }
    }

    void OnDestroy()
    {
        print("ONDESTROY called");
        wallFound.SetActive(true);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            PongPlayerController pc = GetComponentInParent<PongPlayerController>();
            pc.LoseHealth();
            //Debug.Log("GateControler.OnTrigerEnter(); //hp lose " + pc.player.GetHeath());
            Destroy(other.gameObject);
        }
    }
}
