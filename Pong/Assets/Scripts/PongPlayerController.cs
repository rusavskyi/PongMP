using UnityEngine;
using UnityEngine.Networking;
using PongClasses;
using UnityEngine.UI;

public class PongPlayerController : NetworkBehaviour
{
    [SyncVar]
    public string Name;
    [SyncVar]
    public int Health = 20;
    [SyncVar]
    public Color playerColor;
    protected int maxHealth = 20;

    public Effect StoredEffect { get; set; }

    //stored effect must be here

    void Start()
    {
        Health = maxHealth;
        transform.GetChild(0).GetComponent<TextMesh>().text = Name;
        transform.GetChild(1).GetComponent<TextMesh>().text = Health.ToString();
        transform.GetChild(0).GetComponent<TextMesh>().color = playerColor;
        transform.GetChild(1).GetComponent<TextMesh>().color = playerColor;
        if (isLocalPlayer)
        {
            GetComponentInChildren<PlayerMovementControl>().enabled = true;
            GetComponentInChildren<Camera>().enabled = true;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update()
    {
        if(isLocalPlayer)
        {
            GameObject.Find("HealthText").GetComponent<Text>().text = Health.ToString();
        }
        transform.GetChild(1).GetComponent<TextMesh>().text = Health.ToString();
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    #region HP methods
    public void LoseHealth()
    {
        if (Health > 0)
            Health--;
    }

    public void AddHealth()
    {
        if (Health < maxHealth)
            Health++;
    }

    public void AddHealth(int value)
    {
        if (Health <= maxHealth - value)
            maxHealth += value;
        else if (Health < maxHealth)
            Health = maxHealth;
    }
    #endregion
}
