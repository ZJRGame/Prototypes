using System;
using JetBrains.Annotations;
using UnityEngine;

namespace SandBox
{
    [Serializable]
    public class Character : IMatchableItem
    {
        [NotNull] private readonly Rigidbody2D m_CharacterRig;

        public Transform characterTrans
        {
            get => m_CharacterRig.gameObject.transform;
            set => m_CharacterRig.gameObject.transform.position = value.position + new Vector3(0, 20, 0);
        }
        public Vector2 velocity
        {
            get => m_CharacterRig.velocity;
            set => m_CharacterRig.velocity = value;
        }


        public Character(Rigidbody2D player)
        {
            m_CharacterRig = player;
            if (m_CharacterRig == null)
                throw new Exception($"Can't find rigidbody2D in {player.gameObject}");
        }

        private void SyncWithOtherCharacter(Character target)
        {
            target.characterTrans = characterTrans;
            target.velocity = velocity;
        }

        public void SyncWithOtherItem(IMatchableItem targetItem)
        {
            if (targetItem is not Character target) throw new Exception("Item is not match.");
            SyncWithOtherCharacter(target);
        }
    }
}