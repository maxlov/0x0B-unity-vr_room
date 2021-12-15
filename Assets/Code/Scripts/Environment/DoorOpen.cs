using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class DoorOpen : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void Open()
        {
            animator.SetBool("character_nearby", !animator.GetBool("character_nearby"));
        }
    }
}
