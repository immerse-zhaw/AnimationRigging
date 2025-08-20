using UnityEngine;

namespace Library.MediaPipeRig.RiggingTargets
{
    public class MediaPipeHipsEstimator : MonoBehaviour
    {
        [SerializeField] Transform m_LeftHip;
        [SerializeField] Transform m_RightHip;
        [SerializeField] Transform m_LeftShoulder;
        [SerializeField] Transform m_RightShoulder;

        void LateUpdate()
        {
            Vector3 hipsMid = (m_LeftHip.position + m_RightHip.position) * 0.5f;


            Vector3 up = (m_LeftShoulder.position + m_RightShoulder.position) * 0.5f - hipsMid;
            up.Normalize();
            Vector3 right = (m_LeftHip.position - m_RightHip.position).normalized;
            Vector3 forward = Vector3.Cross(up, right).normalized;

            transform.position = hipsMid;
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }
}