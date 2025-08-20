using System.Collections.Generic;
using Mediapipe.Tasks.Vision.PoseLandmarker;
using UnityEngine;

namespace Library.MediaPipeRig
{
    public class BodyTrackerRig : MonoBehaviour
    {
        List<Transform> m_joints = new List<Transform>();

        [SerializeField] float m_MovementScale = 0.1f;
        void Start()
        {
            foreach (Transform child in transform)
            {
                // check if name starts with "Joint"
                if (child.name.StartsWith("Joint"))
                {
                    // add to list
                    m_joints.Add(child);
                }
            } 
            
        }
        public void ApplyPose(PoseLandmarkerResult result)
        {
            if (result.poseWorldLandmarks?.Count == 0)
            {
                return;
            }

            var landmarks3D = result.poseWorldLandmarks[0].landmarks;
            var landmarks2D = result.poseLandmarks[0].landmarks;

            Vector3 GetWorldPosition(int index) => new Vector3(landmarks3D[index].x, -landmarks3D[index].y, landmarks3D[index].z);
            Vector2 GetScreenPosition(int index) => new Vector2(landmarks2D[index].x, -landmarks2D[index].y);

            for (int i = 0; i < m_joints.Count; i++)
            {
                if (i < landmarks3D.Count)
                {
                    m_joints[i].localPosition = GetWorldPosition(i);
                }
                else
                {
                    m_joints[i].localPosition = Vector3.zero;
                }
            }

            Vector2 leftHip2D = GetScreenPosition(23);
            Vector2 rightHip2D = GetScreenPosition(24);

            Vector2 hipCenter2D = (rightHip2D + leftHip2D) * 0.5f + new Vector2(-0.5f, 0.5f);

            transform.localPosition = hipCenter2D * m_MovementScale;

     
        }
    }
}