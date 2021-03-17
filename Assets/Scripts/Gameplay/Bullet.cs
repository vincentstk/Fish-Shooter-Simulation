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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        IGetNormalHit hit = other.GetComponent<IGetNormalHit>();
        if (hit != null)
        {
            hit.Hit();
            _ObjectPooler.ReturnToPool(BULLET, gameObject, true);
        }
    }
}
