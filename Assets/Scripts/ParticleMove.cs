using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateParticle : MonoBehaviour
{
    public static ParticleSystem particlePrefab;
    private Transform particleTransformm;
    public  static Vector3 savedLensPosition;

    

      public static CreateParticle Create(Vector3 lensTransform)
     {
     ParticleSystem particleTransform = Instantiate( GameAssets.i.effects[0], lensTransform, Quaternion.identity);
    
     CreateParticle createParticle = particleTransform.GetComponent<CreateParticle>();

     createParticle.particleTransformm = particleTransform.transform;
     
     return createParticle;
     }


      public static void GetLensPosition(Vector3 lensTransform)
      {
          savedLensPosition = lensTransform;
          
      }

      

     
     void Update()
     {
         if (particleTransformm != null)
         {


             particleTransformm.position = CreateParticle.savedLensPosition;
         }
     }
}
    
