using UnityEngine;

namespace Game.Scripts.Tanks.Ammo
{
    public interface IFireable
    {
        public void Fire();

        public void AddToIgnore(Collider2D rb);
    }
}