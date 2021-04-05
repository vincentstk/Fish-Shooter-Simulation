using Pixeye.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;

public class Fish : MonoBehaviour, IGetNormalHit
{
    [Inject] MainPooler _ObjectPooler;

    private string TAG;

    [Foldout("Components", true)]
    [SerializeField]
    private FishComponent fishComp;

    // Start is called before the first frame update
    void Start()
    {
        switch (fishComp.Type)
        {
            case FishType.Dolphin:
                TAG = "Dolphin";
                break;
            case FishType.HammerShark:
                TAG = "HammerShark";
                break;
            case FishType.JellyFish:
                TAG = "JellyFish";
                break;
            case FishType.KoiFish:
                TAG = "Koi";
                break;
            case FishType.Orthocone:
                TAG = "Orthocone";
                break;
            case FishType.Turtle:
                TAG = "Turtle";
                break;
            case FishType.KillerWhale:
                TAG = "KillerWhale";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CompleteTravelCallback()
    {
        _ObjectPooler.ReturnToPool(TAG, gameObject, true);
    }

    public void SetupWay()
    {
        Vector3 TargetPosition = transform.position;
        TargetPosition *= -1;
        transform.DOMove(TargetPosition, fishComp.SwimTime).SetEase(Ease.Linear).OnComplete(CompleteTravelCallback).SetId(GetInstanceID());
    }
    public void Hit()
    {
        float RandomResult = Random.Range(0f, 1f);
        if (RandomResult <= fishComp.KillRate)
        {
            DOTween.Kill(GetInstanceID());
            GameController.Instance.AddGold(fishComp.Gold);
            GameController.Instance.CountKill(fishComp.Type);
            _ObjectPooler.ReturnToPool(TAG, gameObject, true);
        }
    }
}
