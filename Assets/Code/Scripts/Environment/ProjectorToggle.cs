using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class ProjectorToggle : MonoBehaviour
    {
        [SerializeField] private GameObject[] gameObjects;

        public void ToggleObjects()
        {
            foreach (GameObject item in gameObjects)
                item.SetActive(!item.activeSelf);
        }
    }
}
