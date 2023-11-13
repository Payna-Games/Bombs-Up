using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateParticle : MonoBehaviour
{
    public static ParticleSystem particlePrefab;
    private Transform particleTransformm;

    

      public static CreateParticle Create(Vector3 lensTransform)
     {
     ParticleSystem particleTransform = Instantiate( GameAssets.i.effects[0], lensTransform, Quaternion.identity);
    
     CreateParticle createParticle = particleTransform.GetComponent<CreateParticle>();

     createParticle.particleTransformm.position = lensTransform;
     return createParticle;
     }

     
    // void Update()
    // {
    //     transform.position = .position;
    // }
}
    
