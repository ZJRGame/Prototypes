using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SandBox
{
    //TODO:Need singleton
    public class SynchronizationSystem : MonoBehaviour
    {
        public GameObject character1;
        public GameObject character2;
        [Header("Sync Test")]
        public Character up;
        public Character down;

        private void Awake()
        {
            up = new Character(character1.GetComponent<Rigidbody2D>());
            down = new Character(character2.GetComponent<Rigidbody2D>());
        }

        private void Update()
        {
            up.SyncWithOtherItem(down);
        }
    }
}