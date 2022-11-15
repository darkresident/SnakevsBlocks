using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class FoodTrigger : MonoBehaviour
{
    public SnakeTail SnakeTail;    
    public int MinSphereCount = 1;
    public int MaxSphereCount = 4;
    Random rnd = new Random();
    private int addSphereCount;
    public TMP_Text AddSphereCount;
            
    private void Start()
    {
        addSphereCount = rnd.Next(MinSphereCount, MaxSphereCount);
        AddSphereCount.text = addSphereCount.ToString();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < addSphereCount; i++)
        {
            SnakeTail.AddSphere();
        }        
        Destroy(gameObject);
    }
}
