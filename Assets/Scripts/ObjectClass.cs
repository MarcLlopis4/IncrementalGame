using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
[Serializable]
public class ObjectClass
{
    [SerializeField] private string name;

    [SerializeField] private Sprite sprite;

    [SerializeField] private float damage;

    [SerializeField] private float fireRate;

    [SerializeField] private float bulletSize;

    [SerializeField] private float bulletNumber;

    [SerializeField] private float rebound; // 0 = not rebound  1 = rebound
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    public string Name { get { return name; } }

    public Sprite Sprite { get { return sprite; } }

    public float Damage { get { return damage; } }

    public float FireRate { get { return fireRate; } }

    public float BulletSize { get { return bulletSize; } }

    public float BulletNumber { get { return bulletNumber; } }

    public float Rebound { get { return rebound; } }
}
