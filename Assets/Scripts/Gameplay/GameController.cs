using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hiraishin.Utilities;

public class GameController : BaseSingleton<GameController>
{

    [SerializeField]
    private int Gold;

    private int DolphinKill;
    private int HammerSharkKill;
    private int JellyFishKill;
    private int KoiFishKill;
    private int OrthoconeKill;
    private int TurtleKill;
    private int KillerWhaleKill;

    public int GetGold
    {
        get => Gold;
    }
    public int GetDolphinKill
    {
        get => DolphinKill;
    }
    public int GetHammerSharkKill
    {
        get => HammerSharkKill;
    }
    public int GetJellyFishKill
    {
        get => JellyFishKill;
    }
    public int GetKoiKill
    {
        get => KoiFishKill;
    }
    public int GetOrthoconeKill
    {
        get => KoiFishKill;
    }
    public int GetTurtleKill
    {
        get => TurtleKill;
    }
    public int GetKillerWhaleKill
    {
        get => KillerWhaleKill;
    }
    protected override void OnAwake()
    {
        base.OnAwake();
        Gold = 1000000;
        DolphinKill = 0;
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
    public void CountKill(FishType type)
    {
        switch (type)
        {
            case FishType.Dolphin:
                DolphinKill++;
                break;
            case FishType.HammerShark:
                HammerSharkKill++;
                break;
            case FishType.JellyFish:
                JellyFishKill++;
                break;
            case FishType.KoiFish:
                KoiFishKill++;
                break;
            case FishType.Orthocone:
                OrthoconeKill++;
                break;
            case FishType.Turtle:
                TurtleKill++;
                break;
            case FishType.KillerWhale:
                KillerWhaleKill++;
                break;
        }
        HUD.Instance.UpdateKill(type);
    }
}
