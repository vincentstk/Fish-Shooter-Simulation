using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FishSpawnerSystem
{
    [Inject] MainPooler _ObjectPooling;

    private const string DOLPHIN = "Dolphin";
    private const string HAM_SHARK = "HammerShark";
    private const string JELLY = "JellyFish";
    private const string KOI = "Koi";
    private const string ORTHOCONE = "Orthocone";
    private const string TURTLE = "Turtle";
    private const string KIL_WHALE = "KillerWhale";

    private float DolphinTimer = 0;
    private float HammerSharkTimer = 0;
    private float JellyFishTimer = 0;
    private float KoiFishTimer = 0;
    private float OrthoconeTimer = 0;
    private float TurtleTimer = 0;
    private float KillerWhaleTimer = 0;
    private Camera cam;
    private float MinX = 0;
    private float MinZ = 0;
    private float MaxX = 0;
    private float MaxZ = 0;


    public FishSpawnerSystem(SpawnComponent spawnComp)
    {
        cam = Camera.main;
        Vector2 ScreenPos = new Vector2(Screen.width, Screen.height);
        Vector3 CameraBound = cam.ScreenToWorldPoint(ScreenPos);
        CameraBound.y = 0;
        MinX = -CameraBound.x;
        MinZ = -CameraBound.z;
        MaxX = CameraBound.x;
        MaxZ = CameraBound.z;
    }
    private void Spawn(FishType fishType)
    {
        float RandomEdge = Random.Range(0f, 1f);
        Vector3 SpawnPosition = Vector3.zero;
        if (RandomEdge <= 0.25f)
        {
            SpawnPosition = new Vector3(MinX, 0f, Random.Range(MinZ, MaxZ));
        }
        else if (RandomEdge > 0.25f && RandomEdge <= 0.5f)
        {
            SpawnPosition = new Vector3(MaxX, 0f, Random.Range(MinZ, MaxZ));
        }
        else if (RandomEdge > 0.5f && RandomEdge <= 0.75f)
        {
            SpawnPosition = new Vector3(Random.Range(MinX, MaxX), 0f, MinZ);
        }
        else
        {
            SpawnPosition = new Vector3(Random.Range(MinX, MaxX), 0f, MaxZ);
        }
        CreateFish(SpawnPosition, fishType);
    }
    private void CreateFish(Vector3 Position, FishType fishType)
    {
        GameObject SpawnedFish = null;
        switch (fishType)
        {
            case FishType.Dolphin:
                SpawnedFish = _ObjectPooling.SpawnObject(DOLPHIN, Position, Quaternion.LookRotation(-Position));
                break;
            case FishType.HammerShark:
                SpawnedFish = _ObjectPooling.SpawnObject(HAM_SHARK, Position, Quaternion.LookRotation(-Position));
                break;
            case FishType.JellyFish:
                SpawnedFish = _ObjectPooling.SpawnObject(JELLY, Position, Quaternion.LookRotation(-Position));
                break;
            case FishType.KoiFish:
                SpawnedFish = _ObjectPooling.SpawnObject(KOI, Position, Quaternion.LookRotation(-Position));
                break;
            case FishType.Orthocone:
                SpawnedFish = _ObjectPooling.SpawnObject(ORTHOCONE, Position, Quaternion.LookRotation(-Position));
                break;
            case FishType.Turtle:
                SpawnedFish = _ObjectPooling.SpawnObject(TURTLE, Position, Quaternion.LookRotation(-Position));
                break;
            case FishType.KillerWhale:
                SpawnedFish = _ObjectPooling.SpawnObject(KIL_WHALE, Position, Quaternion.LookRotation(-Position));
                break;
        }
        Fish fish = SpawnedFish.GetComponent<Fish>();
        fish.SetupWay();
    }

    public void Tick(ref SpawnComponent spawnComp)
    {
        DolphinTimer -= Time.deltaTime;
        HammerSharkTimer -= Time.deltaTime;
        JellyFishTimer -= Time.deltaTime;
        KoiFishTimer -= Time.deltaTime;
        OrthoconeTimer -= Time.deltaTime;
        TurtleTimer -= Time.deltaTime;
        KillerWhaleTimer -= Time.deltaTime;
        if (DolphinTimer <= 0)
        {
            Spawn(FishType.Dolphin);
            DolphinTimer = spawnComp.SpawnTime / spawnComp.DolphinPerSec;
        }
        if (HammerSharkTimer <= 0)
        {
            Spawn(FishType.HammerShark);
            HammerSharkTimer = spawnComp.SpawnTime / spawnComp.HammerSharkPerSec;
        }
        if (JellyFishTimer <= 0)
        {
            Spawn(FishType.JellyFish);
            JellyFishTimer = spawnComp.SpawnTime / spawnComp.JellyFishPerSec;
        }
        if (KoiFishTimer <= 0)
        {
            Spawn(FishType.KoiFish);
            KoiFishTimer = spawnComp.SpawnTime / spawnComp.KoiFishPerSec;
        }
        if (OrthoconeTimer <= 0)
        {
            Spawn(FishType.Orthocone);
            OrthoconeTimer = spawnComp.SpawnTime / spawnComp.OrthoconePerSec;
        }
        if (TurtleTimer <= 0)
        {
            Spawn(FishType.Turtle);
            TurtleTimer = spawnComp.SpawnTime / spawnComp.TurtlePerSec;
        }
        if (KillerWhaleTimer <= 0)
        {
            Spawn(FishType.KillerWhale);
            KillerWhaleTimer = spawnComp.SpawnTime / spawnComp.KillerWhalePerSec;
        }
    }
    public class Factory : PlaceholderFactory<SpawnComponent, FishSpawnerSystem> { }
}
