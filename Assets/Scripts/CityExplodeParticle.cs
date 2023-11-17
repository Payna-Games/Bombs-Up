using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityExplodeParticle : MonoBehaviour
{
    [SerializeField] private Transform[] cityParticleTransform;
    private int randomPrefab;
    private int index;
    List<int> availablePositions = new List<int>();
    List<int> availablePref = new List<int>();
    private bool firstTime;
     
    private void Start()
    {
        firstTime = true;
    }
    private void FillAvailablePositions()
    {
        for (int i = 0; i < index; i++)
        {
            availablePositions.Add(i);
        }
    }
   
    
    
    public void CreateCityParticle()
    {
        
        if (KiloTonCalculate.kiloTonCalculate.KiloTon >= 100 && KiloTonCalculate.kiloTonCalculate.KiloTon < 200)
        {
            index = 8;
            
        }
        else if (KiloTonCalculate.kiloTonCalculate.KiloTon >=200 && KiloTonCalculate.kiloTonCalculate.KiloTon < 300)
        {
            index = 16;
            
        }
        else if (KiloTonCalculate.kiloTonCalculate.KiloTon >=300 && KiloTonCalculate.kiloTonCalculate.KiloTon < 400)
        {
            index = 24;
        }
        else if (KiloTonCalculate.kiloTonCalculate.KiloTon >=400 )
        {
            index = 32;
        }
        FillAvailablePositions();
        for (int i = 0; i < index; i++)
        {
            if (firstTime)
            {
                for (int a = 0; a < 4; a++)
                {
                    Inst();
                }
                
                firstTime = false;
            }
            else if(!firstTime)
            {
                StartCoroutine(ParticleBombTime());
            }
            
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


 
}
