using Pixeye.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;

public class Fish : MonoBehaviour, IGetNormalHit
{
    [Inject] MainPooler _ObjectPooler;

    private const string DOLPHIN = "Dolphin";

    [Foldout("Components", true)]
    [SerializeField]
    private FishComponent fishComp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupWay()
    {
        Vector3 TargetPosition = transform.position;
        TargetPosition *= -1;
        transform.DOMove(TargetPosition, fishComp.SwimTime);
    }
    public void Hit()
    {
        float RandomResult = Random.Range(0f, 1f);
        if (RandomResult <= fishComp.KillRate)
        {
            GameController.Instance.AddGold(fishComp.Gold);
            _ObjectPooler.ReturnToPool(DOLPHIN, gameObject, true);
        }
    }
}
