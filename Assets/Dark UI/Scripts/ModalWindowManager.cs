using UnityEngine;

namespace Michsky.UI.Dark
{
    public class ModalWindowManager : MonoBehaviour
    {
        [Header("BRUSH ANIMATION")]
        public Animator brushAnimator;
        public bool enableSplash = true;
        public GameObject prevUI;

        private Animator mWindowAnimator;

        void Awake()
        {
            mWindowAnimator = gameObject.GetComponent<Animator>();
        }

        public void ModalWindowIn()
        {
            mWindowAnimator.Play("Modal Window In");

            if(enableSplash == true)
            {
                brushAnimator.Play("Transition Out");
            }

            prevUI?.SetActive(false);
        }

        public void ModalWindowOut()
        {
            mWindowAnimator.Play("Modal Window Out");

            if (enableSplash == true)
            {
                brushAnimator.Play("Transition In");
            }
        }
    }
}