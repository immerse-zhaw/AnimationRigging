using UnityEngine;


namespace Library.MediaPipeRig.RiggingTargets
{
    public class MediaPipeSpineEstimator : MonoBehaviour
    {
        [SerializeField] Transform m_LeftHip;
        [SerializeField] Transform m_RightHip;
        [SerializeField] Transform m_LeftShoulder;
        [SerializeField] Transform m_RightShoulder;

        [SerializeField, Range(-1f, 1f)] float m_Scale = 0.0f; // Scale factor to adjust the position of the spine

        void LateUpdate()
        {
            Vector3 hipsMid = (m_LeftHip.position + m_RightHip.position) * 0.5f;
            Vector3 shouldersMid = (m_LeftShoulder.position + m_RightShoulder.position) * 0.5f;


            Vector3 up = shouldersMid - hipsMid;
            up.Normalize();
            Vector3 right = (m_LeftShoulder.position - m_RightShoulder.position).normalized;
            Vector3 forward = Vector3.Cross(up, right).normalized;

            transform.position = shouldersMid;
            transform.localPosition += Vector3.forward * m_Scale;
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }
}