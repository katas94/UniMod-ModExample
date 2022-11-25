using System.Collections.Generic;
using UnityEngine;

namespace Katas.UniMod.ModExample
{
    /// <summary>
    /// Can cycle through a list of materials when the user clicks on the screen and makes Suzanne to float up and down.
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class SuzanneController : MonoBehaviour
    {
        public List<Material> materials;
        public float floatingSpeed = 180.0f;
        public float floatingAmplitude = 1.0f;
        
        private MeshRenderer _meshRenderer;
        private int _materialIndex;
        private float _floatingPhase;
        
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            // transition between the materials list when the user clicks on the screen
            if (Input.GetMouseButtonDown(0))
                ApplyNextMaterial();
            
            // perform the floating animation
            _floatingPhase += floatingSpeed * Time.deltaTime * Mathf.Deg2Rad;
            Vector3 localPosition = transform.localPosition;
            localPosition.y = floatingAmplitude * Mathf.Sin(_floatingPhase);
            transform.localPosition = localPosition;
        }

        private void ApplyNextMaterial()
        {
            if (++_materialIndex >= materials.Count)
                _materialIndex = 0;
            
            _meshRenderer.sharedMaterial = materials[_materialIndex];
        }
    }
}