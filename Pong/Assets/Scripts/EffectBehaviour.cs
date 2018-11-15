using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using PongClasses;

public class EffectBehaviour : NetworkBehaviour
{
    [SyncVar]
    public GameObject spawner;
    [SyncVar]
    private float lifeTime = 10f;
    public Effect effect;

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        transform.Rotate(new Vector3(1, 1, -1));
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
            spawner.GetComponent<EffectsSpawnerController>().effectIsAvailable = false;
            spawner = null;
        }
    }
}
