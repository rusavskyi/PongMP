using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EffectsSpawnerController : NetworkBehaviour
{
    public float defaultSpawnCooldown = 15f;
    private float spawnCooldown = 10f;
    public GameObject[] EffectPrefabs;

    [SyncVar]
    public bool effectIsAvailable = false;

    public GameObject effect;

    void Update()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
        {
            CmdSpawnEffect();
        }
    }

    [Command]
    void CmdSpawnEffect()
    {
        int index = Random.Range(0, 4);
       
        //choose random effect

        Vector3 position = transform.GetChild(index).transform.position;
        Quaternion rotation = transform.GetChild(index).transform.rotation;
        effect = (GameObject)Instantiate(EffectPrefabs[Random.Range(0, EffectPrefabs.Length)], position, rotation);
        NetworkServer.Spawn(effect);
        effectIsAvailable = true;
        spawnCooldown = defaultSpawnCooldown;
    }
}
