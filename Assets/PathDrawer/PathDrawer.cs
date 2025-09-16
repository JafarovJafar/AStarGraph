using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shafir
{
    public class PathDrawer : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float fillDuration = 1f;

        private readonly int FillPropName = Shader.PropertyToID("_Fill");

        private Coroutine _fillCoroutine;
        private Material _material;

        private void Start()
        {
            _material = lineRenderer.material;
        }

        public void SetPoints(List<Vector3> points)
        {
            SetFill(0f);

            if (_fillCoroutine != null)
                StopCoroutine(_fillCoroutine);

            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
            _fillCoroutine = StartCoroutine(FillCoroutine());
        }

        private IEnumerator FillCoroutine()
        {
            var t = 0f;
            var speed = 1f / fillDuration;

            do
            {
                t += speed * Time.deltaTime;
                SetFill(t);
                yield return null;
            } while (t < 1f);
        }

        private void SetFill(float fill)
        {
            _material.SetFloat(FillPropName, fill);
        }
    }
}