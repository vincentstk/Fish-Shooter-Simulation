using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [Inject] MainPooler _ObjectPooler;

    [SerializeField]
    private float Speed;

    private const string BULLET = "Bullet";

    private GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
    public void Setup()
    {
        target = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        IGetNormalHit hit = other.GetComponent<IGetNormalHit>();
        if (hit != null)
        {
            if (target == null)
            {
                target = other.gameObject;
                hit.Hit();
                _ObjectPooler.ReturnToPool(BULLET, gameObject, true);
            }
        }
        else
        {
            Wall wall = other.GetComponent<Wall>();
            if (wall != null)
            {
                Vector3 ReflectDirection = Vector3.Reflect(transform.forward, wall.GetNormal);
                transform.rotation = Quaternion.LookRotation(ReflectDirection);
            }
        }
    }
}
