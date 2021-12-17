using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Environment
{
    public class ProjectorConsole : MonoBehaviour
    {
        [SerializeField] private XRSocketInteractor[] artSockets;
        private XRSimpleInteractable projectorConsole;

        private Renderer consoleMeshRenderer;
        [SerializeField] private Material goodMaterial;
        [SerializeField] private Material badMaterial;

        private void Start()
        {
            projectorConsole = gameObject.GetComponent<XRSimpleInteractable>();
            consoleMeshRenderer = gameObject.GetComponent<Renderer>();
        }

        public void SocketCheck()
        {
            foreach (XRSocketInteractor socket in artSockets)
            {
                Debug.Log(socket.name + ": " + socket.hasSelection.ToString());
                if (!socket.hasSelection)
                {
                    ConsoleDisable();
                    return;
                }
            }
            ConsoleEnable();
        }

        private void ConsoleEnable()
        {
            projectorConsole.enabled = true;
            consoleMeshRenderer.materials = new Material[]{ consoleMeshRenderer.materials[0], goodMaterial };
        }

        private void ConsoleDisable()
        {
            projectorConsole.enabled = false;
            Debug.Log(consoleMeshRenderer.materials);
            consoleMeshRenderer.materials = new Material[]{ consoleMeshRenderer.materials[0], badMaterial };
        }
    }
}
