using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExplosion : MonoBehaviour
{
    [HideInInspector] public static BlockExplosion Instance;
    public GameObject ExplosionEffect;

    private void Awake()
    {
        Instance = this;                        
    }
    public void KillCubeEffect(Vector3 position) 
    {
        Instantiate(ExplosionEffect, position, Quaternion.identity);
    }
}
