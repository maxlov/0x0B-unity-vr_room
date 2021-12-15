using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Environment
{
    public class ConsoleFix : MonoBehaviour
    {
        [SerializeField] private GameObject door;
        private Renderer doorMeshRenderer;
        private XRSimpleInteractable doorInteractable;

        [SerializeField] private Material doorGoodMaterial;

        private Rigidbody rb;

        private bool doorFixed = false;

        private void Start()
        {
            doorMeshRenderer = door.GetComponent<Renderer>();
            doorInteractable = door.GetComponent<XRSimpleInteractable>();

            rb = gameObject.GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!doorFixed && (collision.gameObject.CompareTag("Weapon") || collision.relativeVelocity.magnitude > 10f))
            {
                rb.constraints = RigidbodyConstraints.None;
                doorMeshRenderer.materials = new Material[]{ doorMeshRenderer.materials[0], doorGoodMaterial };
                doorInteractable.enabled = true;
                doorFixed = true;
            }
        }
    }
}