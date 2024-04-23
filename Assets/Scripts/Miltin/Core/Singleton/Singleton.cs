using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.Core.Singleton
{

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour //<T> class type
    {
        //padrão de referência para singletons
        public static T Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = GetComponent<T>();
            else
                Destroy(gameObject);
        }
    }
}