using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace Player.Locomotion
{
    public class TeleportationManager : MonoBehaviour
    {
        [SerializeField] private InputActionAsset actionAsset;
        [SerializeField] private XRRayInteractor rayInteractor;
        [SerializeField] private TeleportationProvider provider;
        private InputAction _teleportActivate;


        void Start()
        {
            rayInteractor.enabled = false;

            _teleportActivate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
            _teleportActivate.performed += OnTeleportActivate;
            _teleportActivate.canceled += OnTeleportRelease;

            _teleportActivate.Enable();
        }

        private void OnTeleportActivate(InputAction.CallbackContext context)
        {
            rayInteractor.enabled = true;
        }

        private void OnTeleportRelease(InputAction.CallbackContext context)
        {
            rayInteractor.TryGetHitInfo(out Vector3 ReticlePos, out Vector3 _, out var _, out var isValidTarget);
            if (isValidTarget)
            {
                TeleportRequest request = new TeleportRequest()
                {
                    destinationPosition = ReticlePos,
                };

                provider.QueueTeleportRequest(request);
            }            
            rayInteractor.enabled = false;
        }

        private void OnDisable()
        {
            _teleportActivate.Disable();
        }
    }
}
