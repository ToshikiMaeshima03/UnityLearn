using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnd : MonoBehaviour
{
    //パーティクルの再生が終わった時に実行される
    private void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }
}
