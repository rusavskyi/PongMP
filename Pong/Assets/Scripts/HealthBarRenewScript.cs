using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarRenewScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("").GetComponentInChildren<Text>().text = this.GetComponent<PongPlayerController>().Health.ToString();
        //if (isLocalPlayer)
        {
            GameObject.Find("HealthText").GetComponent<Text>().text = this.GetComponent<PongPlayerController>().Health.ToString();
        }
        transform.GetChild(1).GetComponent<TextMesh>().text = this.GetComponent<PongPlayerController>().Health.ToString();
    }
}
