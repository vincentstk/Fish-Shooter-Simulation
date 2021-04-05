using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hiraishin.Utilities;
using Zenject;
using Pixeye.Unity;

public class Spawner : BaseSingleton<Spawner>
{
    [Inject] FishSpawnerSystem.Factory _SpawnerFactory;
    private FishSpawnerSystem _SpawnerSystem;

    [Foldout("Components", true)]
    [SerializeField]
    private SpawnComponent spawnComp;


    // Start is called before the first frame update
    void Start()
    {
        _SpawnerSystem = _SpawnerFactory.Create(spawnComp);
    }

    // Update is called once per frame
    void Update()
    {
        _SpawnerSystem.Tick(ref spawnComp);
    }
    
}
