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
            enemyParticle.transform.SetParent(null); //quando a moeda � coletada, ela � deletada. Para que a anima��o seja vista, � necess�rio mudar o Parent da particula.
            enemyParticle.Play();
        }
    }
}
