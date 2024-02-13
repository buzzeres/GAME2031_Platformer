using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public interface ISpawnnable
{
    public void Respawn();
}

public class Element : MonoBehaviour, ISpawnnable
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _value = 1;

    public int Value
    {
        get
        {
            return _value;
        }
    }
  

    public void Respawn()
    {
        Vector3 pos = new Vector3 (Random.Range(_spawnPoint.position.x-5, _spawnPoint.position.x+5), _spawnPoint.position.y, _spawnPoint.position.z);
        transform.position = pos;
        Debug.Log(pos.x);
        GetComponent<Rigidbody2D>().velocity=Vector3.zero;
    }
    // Start is called before the first frame update

    //void Start()
    //{


    //}

    //void Update()
    //{
        
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Respawn();
    }
}

