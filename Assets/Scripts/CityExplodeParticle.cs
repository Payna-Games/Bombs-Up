using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityExplodeParticle : MonoBehaviour
{
    [SerializeField] private Transform[] cityParticleTransform;
    private int randomPrefab;
    List<int> availablePositions = new List<int>();
    List<int> availablePref = new List<int>();
     
    private void Start()
    {
        FillAvailablePositions();
    }
    private void FillAvailablePositions()
    {
        for (int i = 0; i < 32; i++)
        {
            availablePositions.Add(i);
        }
    }
    public void CreateCityParticle()
    {
        
        for (int i = 0; i < 9; i++)
        {
            StartCoroutine(ParticleBombTime());
        }
        

    }

    private int RandomPos()
    {
        
        int randomPosition = Random.Range(0, availablePositions.Count);
        return randomPosition;
    }

    private void Inst()
    {
        int randomPoss = RandomPos();
        int randomPrefabb = Random.Range(2, 6);
        ParticleSystem particle = Instantiate(GameAssets.i.effects[randomPrefabb], cityParticleTransform[randomPoss].position, Quaternion.identity);
        particle.Play();
        availablePositions.Remove(randomPoss);
    }

    private IEnumerator ParticleBombTime()
    {
        float randomSecond = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(randomSecond);
        Inst();
        
    }


    // private int RandomPrefab()
    // {
    //     for (int i = 0; i < 4; i++)
    //     {
    //         availablePref.Add(i);
    //         int randomPrefab = Random.Range(0, availablePref.Count);
    //         return randomPrefab;
    //     }
    // }
}
