using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hiraishin.Utilities;

public class GameController : BaseSingleton<GameController>
{

    [SerializeField]
    private int Gold;
    [SerializeField]
    private int KillCount;

    public int GetGold
    {
        get => Gold;
    }
    public int GetKillCount
    {
        get => KillCount;
    }
    protected override void OnAwake()
    {
        base.OnAwake();
        Gold = 1000000;
        KillCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseGold()
    {
        Gold--;
        HUD.Instance.UpdateGold();
    }
    public void AddGold(int gold)
    {
        Gold += gold;
        HUD.Instance.UpdateGold();
    }
    public void CountKill()
    {
        KillCount++;
        HUD.Instance.UpdateKill();
    }
}
