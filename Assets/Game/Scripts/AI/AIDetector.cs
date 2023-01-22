using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.ai
{
    public class AIDetector : MonoBehaviour
    {
        [Range(1f, 15)] [SerializeField] private float detectRange = 15f;

        [SerializeField] private float detectionCheckDelay = 1f;
        private bool detectionLoop = true;
        [SerializeField]
        private Transform target = null;

        [field:SerializeField]
        public bool TargetVisible { get; private set; }

        [SerializeField] private LayerMask playerLayerMask;

        [SerializeField] private LayerMask visibilityLayer;

        [Header("Gizmo sphere color")]
        public Color sphereColor = Color.blue;

        public Transform Target
        {
            get => target;
            set
            {
                target = value;
                TargetVisible = false;
            }
        }

        private void Start()
        {
            StartCoroutine(DetectCoroutine());
        }

        private void Update()
        {
            if (target != null)
            {
                TargetVisible = CheckTargetIsVisible();
            }
        }

        private bool CheckTargetIsVisible()
        {
            var result = Physics2D.Raycast(transform.position, Target.position - transform.position, detectRange,
                visibilityLayer);
            if (result.collider != null)
            {
                return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
            }

            return false;
        }
        
        private void DetectTarget()
        {
            if (target == null)
            {
                CheckPlayerInRange();
            }
            else if (target != null)
            {
                DetectIfPlayerOutOfRange();
            }
        }
        
        private void DetectIfPlayerOutOfRange()
        {
            if (Target == null
                || Target.gameObject.activeSelf == false
                || Vector2.Distance(transform.position, Target.position) > detectRange)
            {
                Target = null;
            }
        }

        private void CheckPlayerInRange()
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, detectRange, playerLayerMask);
            if (collider)
            {
                Target = collider.transform;
            }
        }

        IEnumerator DetectCoroutine()
        {
                yield return new WaitForSeconds(detectionCheckDelay);
                DetectTarget();
                StartCoroutine(DetectCoroutine());
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = sphereColor;
            Gizmos.DrawWireSphere(transform.position, detectRange);
        }
    }
}