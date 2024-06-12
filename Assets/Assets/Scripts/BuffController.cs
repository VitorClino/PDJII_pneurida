using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Colect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Collide();
        Destroy(this.gameObject);
    }
    public abstract void Collide();
    private void Awake()
    {
        transform.position = new Vector3(0, 0, GameManager.Instance.GetSpeed);
    }
}
public interface IUse
{
    public void SelfDestruction();
    public void Use();
}


