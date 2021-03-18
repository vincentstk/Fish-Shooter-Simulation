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
    public TextMeshProUGUI txtKillCount;

    // Start is called before the first frame update
    void Start()
    {
        txtGold.SetText("Gold: " + GameController.Instance.GetGold.ToString());
        txtKillCount.SetText("Kill: " + GameController.Instance.GetKillCount.ToString());
    }
    public void UpdateGold()
    {
        txtGold.SetText("Gold: " + GameController.Instance.GetGold.ToString());
    }
    public void UpdateKill()
    {
        txtKillCount.SetText("Kill: " + GameController.Instance.GetKillCount.ToString());
    }
}
