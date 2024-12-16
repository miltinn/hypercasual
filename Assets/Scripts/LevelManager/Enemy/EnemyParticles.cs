using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticles : MonoBehaviour
{
    public ParticleSystem enemyParticle;
    private void OnCollisionEnter(Collision collision)
    {
        if (enemyParticle != null)
        {
            enemyParticle.transform.SetParent(null); //quando a moeda é coletada, ela é deletada. Para que a animação seja vista, é necessário mudar o Parent da particula.
            enemyParticle.Play();
        }
    }
}
