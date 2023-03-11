using UnityEngine;

namespace IDED_Scripting_GitDemo
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        private float vVal, hVal;

        // Update is called once per frame
        private void Update()
        {
            hVal = Input.GetAxis("Horizontal");

            if (hVal != 0)
            {
                transform.Translate(Vector3.right * hVal * speed * Time.deltaTime);
            }

            vVal = Input.GetAxis("Vertical");

            if (vVal != 0)
            {
                transform.Translate(Vector3.up * vVal * speed * Time.deltaTime);
            }
        }
    }
}