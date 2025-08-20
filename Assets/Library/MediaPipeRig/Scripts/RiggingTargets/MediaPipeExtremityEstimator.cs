using UnityEngine;

namespace Library.MediaPipeRig.RiggingTargets
{
    public class MediaPipeExtremityEstimator : MonoBehaviour
    {
        [SerializeField] Transform m_UpperJoint;
        [SerializeField] Transform m_LowerJoint;
        [SerializeField] Transform m_ReferenceUpperJoint;


        void LateUpdate()
        {
            Vector3 direction = (m_LowerJoint.position - m_UpperJoint.position).normalized;

            transform.position = m_ReferenceUpperJoint.position + direction * 2.0f;
        }
    }
}
