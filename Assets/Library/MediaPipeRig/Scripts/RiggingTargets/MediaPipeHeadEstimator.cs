using UnityEngine;

namespace Library.MediaPipeRig.RiggingTargets
{
    public class MediaPipeHeadEstimator : MonoBehaviour
    {
        [SerializeField] Transform m_LeftEar;
        [SerializeField] Transform m_RightEar;
        [SerializeField] Transform m_Nose;
        [SerializeField] Transform m_HeadParent;
        [SerializeField] Transform m_LeftShoulder;
        [SerializeField] Transform m_RightShoulder;

        void LateUpdate()
        {
            Vector3 center = (m_LeftEar.position + m_RightEar.position) * 0.5f;

            Vector3 forward = (center - m_Nose.position).normalized;

            Vector3 shoulderVector = (m_RightShoulder.position - m_LeftShoulder.position).normalized;
            Vector3 earVector = (m_RightEar.position - m_LeftEar.position).normalized;
            if (Vector3.Dot(shoulderVector, earVector) < 0)
            {
                forward = -forward;
            }

            transform.position = center;
            Quaternion worldRotation = Quaternion.LookRotation(forward, Vector3.up);
            transform.rotation = Quaternion.Inverse(m_HeadParent.rotation) * worldRotation;
        }
    }
}