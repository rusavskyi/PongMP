using UnityEngine;
using UnityEngine.Networking;

using System.Collections;

public class BallsSpawnerController : NetworkBehaviour
{
    public int minNumberOfBalls = 1;
    public int maxNumberOfBalls = 5;
    public int currentNumberOfBalls;
    public GameObject BallPrefab;
    private float spawnCooldownTime = 3f;
    private float spawnCooldown = 0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentNumberOfBalls = GameObject.FindGameObjectsWithTag("Ball").Length;
        spawnCooldown -= Time.deltaTime;
        if(spawnCooldown <= 0f || currentNumberOfBalls < minNumberOfBalls)
        {
            if(currentNumberOfBalls < maxNumberOfBalls)
            {
                CmdCreateBall();
                spawnCooldown = spawnCooldownTime;
            }
        }
    }

    [Command]
    void CmdCreateBall()
    {
        int index = Random.Range(0, 4);
        Vector3 position = transform.GetChild(index).transform.position;
        Quaternion rotation = transform.GetChild(index).transform.rotation;
        GameObject ball = (GameObject)Instantiate(BallPrefab, position, rotation);
        NetworkServer.Spawn(ball);
    }
}
