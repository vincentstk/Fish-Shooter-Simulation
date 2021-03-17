using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hiraishin.Utilities;

public class GameController : BaseSingleton<GameController>
{

    [SerializeField]
    private int Gold;

    public int GetGold
    {
        get => Gold;
    }
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
