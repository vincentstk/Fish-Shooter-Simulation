using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShootSystem
{
    [Inject] MainPooler _MainPooler;

    private const string BULLET = "Bullet";
    private readonly Vector3 SHOOT_POINT = new Vector3(0f, 0f, 0.25f);
    
    private Player Owner;

    public ShootSystem(Player owner)
    {
        Owner = owner;
    }
    private void Shoot()
    {
        GameObject BulletObject = _MainPooler.SpawnObjectNotFill(BULLET, Owner.transform.TransformPoint(SHOOT_POINT), Owner.transform.rotation);
        if (BulletObject == null)
        {
            return;
        }
        GameController.Instance.UseGold();
    }
    public void Tick(ref ShootComponent shootComp)
    {
        if (shootComp.CurrentDelay > 0)
        {
            shootComp.CurrentDelay -= Time.deltaTime;
        }
        else
        {
            Shoot();
            shootComp.CurrentDelay = 1 / shootComp.FireRate;
        }
    }
    public class Factory : PlaceholderFactory<Player, ShootSystem> { }
}
