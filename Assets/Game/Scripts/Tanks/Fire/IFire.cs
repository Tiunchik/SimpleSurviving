using UnityEngine;

namespace Game.Scripts.Tanks.Fire
{
    public interface IFire
    {
        public void Fire();

        public void AddToIgnore(Collider2D rb);
    }
}