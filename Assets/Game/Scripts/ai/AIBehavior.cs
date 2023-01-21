using UnityEngine;

namespace Game.Scripts.ai
{
    public abstract class AIBehavior: MonoBehaviour
    {

        public abstract void PerformAction(GameObject target);

    }
}