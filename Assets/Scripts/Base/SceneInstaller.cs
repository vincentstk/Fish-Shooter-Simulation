using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject Pooler;

    public override void InstallBindings()
    {
        Container.BindFactory<Player, ShootSystem, ShootSystem.Factory>();
        Container.Bind<MainPooler>().FromComponentInNewPrefab(Pooler).AsSingle();
        Container.BindFactory<SpawnComponent, FishSpawnerSystem, FishSpawnerSystem.Factory>();
    }
}
