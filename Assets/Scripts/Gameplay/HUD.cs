using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pixeye.Unity;
using Hiraishin.Utilities;

public class HUD : BaseSingleton<HUD>
{
    [Foldout("Text", true)]
    public TextMeshProUGUI txtGold;
    public TextMeshProUGUI txtDolphinKillCount;
    public TextMeshProUGUI txtHammerSharkKillCount;
    public TextMeshProUGUI txtJellyFishKillCount;
    public TextMeshProUGUI txtKoiKillCount;
    public TextMeshProUGUI txtOrthoconeKillCount;
    public TextMeshProUGUI txtTurtleKillCount;
    public TextMeshProUGUI txtKillerWhaleKillCount;

    // Start is called before the first frame update
    void Start()
    {
        txtGold.SetText("Gold: " + GameController.Instance.GetGold.ToString());
        txtDolphinKillCount.SetText("Dolphin Kill: " + GameController.Instance.GetDolphinKill.ToString());
        txtHammerSharkKillCount.SetText("Ham Shark Kill: " + GameController.Instance.GetHammerSharkKill.ToString());
        txtJellyFishKillCount.SetText("Jelly Fish Kill: " + GameController.Instance.GetJellyFishKill.ToString());
        txtKoiKillCount.SetText("Koi Kill: " + GameController.Instance.GetKoiKill.ToString());
        txtOrthoconeKillCount.SetText("Orthocone Kill: " + GameController.Instance.GetOrthoconeKill.ToString());
        txtTurtleKillCount.SetText("Turtle Kill: " + GameController.Instance.GetTurtleKill.ToString());
        txtKillerWhaleKillCount.SetText("Killer Whale Kill: " + GameController.Instance.GetKillerWhaleKill.ToString());
    }
    public void UpdateGold()
    {
        txtGold.SetText("Gold: " + GameController.Instance.GetGold.ToString());
    }
    public void UpdateKill(FishType type)
    {
        switch (type)
        {
            case FishType.Dolphin:
                txtDolphinKillCount.SetText("Dolphin Kill: " + GameController.Instance.GetDolphinKill.ToString());
                break;
            case FishType.HammerShark:
                txtHammerSharkKillCount.SetText("Ham Shark Kill: " + GameController.Instance.GetHammerSharkKill.ToString());
                break;
            case FishType.JellyFish:
                txtJellyFishKillCount.SetText("Jelly Fish Kill: " + GameController.Instance.GetJellyFishKill.ToString());
                break;
            case FishType.KoiFish:
                txtKoiKillCount.SetText("Koi Kill: " + GameController.Instance.GetKoiKill.ToString());
                break;
            case FishType.Orthocone:
                txtOrthoconeKillCount.SetText("Orthocone Kill: " + GameController.Instance.GetOrthoconeKill.ToString());
                break;
            case FishType.Turtle:
                txtTurtleKillCount.SetText("Turtle Kill: " + GameController.Instance.GetTurtleKill.ToString());
                break;
            case FishType.KillerWhale:
                txtKillerWhaleKillCount.SetText("Killer Whale Kill: " + GameController.Instance.GetKillerWhaleKill.ToString());
                break;
        }
        
    }
}
