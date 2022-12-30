using UnityEngine;

namespace Game.Scripts
{
    public interface IFire
    {
        public void Fire();

        public void AddToIgnore(Collider2D rb);
    }
}