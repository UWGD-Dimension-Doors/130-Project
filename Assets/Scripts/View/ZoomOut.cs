using UnityEngine;
using Platformer.Core;
using Platformer.Model;

namespace Platformer.View
{
    public class ZoomOut : MonoBehaviour
    {
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        private static float TargetOrthoSize = 3.5f;
        private static readonly float MinOrthoSize = 3.5f, MaxOrthoSize = 5.0f;
        private float Speed = 0.01f;

        void Start()
	    {
            TargetOrthoSize = model.virtualCamera.m_Lens.OrthographicSize;
        }

	    void Update()
	    {
            // Increase speed of zoom out as player grows.
            switch (model.player.transform.localScale.x)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                    Speed *= model.player.transform.localScale.x;
                    break;
            }

            // Zoom out by no more than speed/second per frame until reaching target.
            model.virtualCamera.m_Lens.OrthographicSize = Mathf.MoveTowards(model.virtualCamera.m_Lens.OrthographicSize, TargetOrthoSize, Speed * Time.deltaTime);
        }

        // Zoom the camera out as the player gets bigger.
        public static void IncrementalZoomOut()
        {
            float adjustedZoomChange = 0.1f;
            TargetOrthoSize += adjustedZoomChange;
            TargetOrthoSize = Mathf.Clamp(TargetOrthoSize, MinOrthoSize, MaxOrthoSize);
        }
    }
}

