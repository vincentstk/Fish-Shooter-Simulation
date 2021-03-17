using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hiraishin.Utilities;
using Zenject;
using Pixeye.Unity;

public class Spawner : BaseSingleton<Spawner>
{
    [Inject] MainPooler _ObjectPooling;

    [Foldout("Components", true)]
    [SerializeField]
    private SpawnComponent spawnComp;

    private const string DOLPHIN = "Dolphin";

    private float Timer = 0;
    private Camera cam;
    private float MinX = 0;
    private float MinZ = 0;
    private float MaxX = 0;
    private float MaxZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Timer = spawnComp.SpawnRate;
        Vector2 ScreenPos = new Vector2(Screen.width, Screen.height);
        Vector3 CameraBound = cam.ScreenToWorldPoint(ScreenPos);
        CameraBound.y = 0;
        MinX = -CameraBound.x;
        MinZ = -CameraBound.z;
        MaxX = CameraBound.x;
        MaxZ = CameraBound.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
            Spawn();
    }
    private void Spawn()
    {
        if (spawnComp.FishCount <= 0)
        {
            return;
        }
        float RandomEdge = Random.Range(0f, 1f);
        GameObject SpawnedFish = null;
        Fish fish = null;
        if (RandomEdge <= 0.5f)
        {
            Vector3 LeftSpawnPosition = new Vector3(MinX, 0f, Random.Range(MinZ, MaxZ));
            SpawnedFish = _ObjectPooling.SpawnObject(DOLPHIN, LeftSpawnPosition, Quaternion.LookRotation(-LeftSpawnPosition));
            fish = SpawnedFish.GetComponent<Fish>();
            fish.SetupWay();
            UpdateFishCount();
            Timer = spawnComp.SpawnRate;
            return;
        }
        Vector3 TopSpawnPosition = new Vector3(Random.Range(MinX, MaxX), 0f, MaxZ);
        SpawnedFish = _ObjectPooling.SpawnObject(DOLPHIN, TopSpawnPosition, Quaternion.LookRotation(-TopSpawnPosition));
        fish = SpawnedFish.GetComponent<Fish>();
        fish.SetupWay();
        UpdateFishCount();
        Timer = spawnComp.SpawnRate;
    }
    private void UpdateFishCount()
    {
        spawnComp.FishCount--;
    }
}
