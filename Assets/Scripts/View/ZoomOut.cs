using UnityEngine;
using Platformer.Core;
using Platformer.Model;

namespace Platformer.View
{
    public class ZoomOut : MonoBehaviour
    {
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        private static float TargetOrthoSize = 3.5f;
        private float speed = 0.03f;

        void Start()
	    {
            TargetOrthoSize = model.virtualCamera.m_Lens.OrthographicSize;
        }

	    void Update()
	    {
            // Zoom out more quickly as player gets bigger.
            if (model.player.transform.localScale.x > 3)
            {
                speed = 0.05f;
            }
            else if (model.player.transform.localScale.x > 4)
            {
                speed = 0.08f;
            }
            else if (model.player.transform.localScale.x > 5)
            {
                speed = 0.1f;
            }
            else if (model.player.transform.localScale.x > 6)
            {
                speed = 0.2f;
            }

            // Zoom out by no more than speed/second per frame until reaching target.
            model.virtualCamera.m_Lens.OrthographicSize = Mathf.MoveTowards(model.virtualCamera.m_Lens.OrthographicSize, TargetOrthoSize, speed * Time.deltaTime);
        }

        // Zoom the camera out as the player gets bigger.
        public static void IncrementalZoomOut()
        {
            float adjustedZoomChange = 0.1f;
            TargetOrthoSize += adjustedZoomChange;
        }
    }
}

