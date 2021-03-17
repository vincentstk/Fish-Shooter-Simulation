using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hiraishin.Utilities;

public class GameController : BaseSingleton<GameController>
{

    private int Gold;

    protected override void OnAwake()
    {
        base.OnAwake();
    }
    // Start is called before the first frame update
    void Start()
    {
        Gold = 1000000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseGold()
    {
        Gold--;
    }
    public void AddGold(int gold)
    {
        Gold += gold;
    }
}
