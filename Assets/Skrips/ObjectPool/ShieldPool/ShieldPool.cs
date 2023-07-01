using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ShieldPool : MonoBehaviour
{
    [SerializeField] private int _quantity;

    [SerializeField] private Shield _shield;

    public ObjectPool<ShieldPool> _pool;

    public void Init(Shield shield)
    {
        _shield = shield;
        _pool = new ObjectPool<ShieldPool>(createFunc: () => Instantiate(this),
              actionOnGet: (obj) => obj.gameObject.SetActive(true),
              actionOnRelease: (obj) => obj.gameObject.SetActive(false),
              actionOnDestroy: (obj) => Destroy(obj.gameObject),
              collectionCheck: true,
              defaultCapacity: _quantity,
              maxSize: _quantity);
    }

    public virtual ShieldPool Spawn(Vector3 pos, Quaternion rot)
    {
        var inst = _pool.Get();
        inst.transform.SetPositionAndRotation(pos, rot);
        inst._pool = _pool;
        inst._shield = _shield;
        return inst;
    }

    public void Die()
    {
        _pool.Release(this);
    }
}
