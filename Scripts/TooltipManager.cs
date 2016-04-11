using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ifup.ui
{
    [RequireComponent(typeof(Canvas))]
    public class TooltipManager : Singleton<TooltipManager>
    {
        [SerializeField]
        public Text tooltipText;

        private Vector2[] upperDeltas = new Vector2[] { new Vector2(15, -10), new Vector2(0, -30), new Vector2(-15, -10) };
        private Vector2[] middleDelta = new Vector2[] { new Vector2(15, 0), new Vector2(0, 20), new Vector2(-15, 0) };
        private Vector2[] lowerDelta = new Vector2[] { new Vector2(15, 0), new Vector2(0, 20), new Vector2(-15, 0) };

        private class AnchorData
        {
            public TextAnchor anchor;
            public Vector2 delta;
        }

        void Start()
        {
            tooltipText.enabled = false;
        }

        public void Show(string msg)
        {
            AnchorData data = GetAnchorData();
            tooltipText.enabled = true;
            tooltipText.alignment = data.anchor;
            tooltipText.text = msg;
            tooltipText.rectTransform.position = Input.mousePosition + new Vector3(data.delta.x, data.delta.y, 0);
        }

        public void Hide()
        {
            tooltipText.enabled = false;
        }

        private AnchorData GetAnchorData()
        {
            AnchorData data = new AnchorData();

            if (Input.mousePosition.y < Screen.height * 1 / 3) {
                //text.rectTransform.position
                if (Input.mousePosition.x < Screen.width * 1 / 3) {
                    data.delta = lowerDelta[0];
                    data.anchor = TextAnchor.LowerLeft;
                    return data;
                } else if (Input.mousePosition.x < Screen.width * 2 / 3) {
                    data.delta = lowerDelta[1];
                    data.anchor = TextAnchor.LowerCenter;
                    return data;
                } else {
                    data.delta = lowerDelta[2];
                    data.anchor = TextAnchor.LowerRight;
                    return data;
                }
            } else if (Input.mousePosition.y < Screen.height * 2 / 3) {
                if (Input.mousePosition.x < Screen.width * 1 / 3) {
                    data.delta = middleDelta[0];
                    data.anchor = TextAnchor.MiddleLeft;
                    return data;
                } else if (Input.mousePosition.x < Screen.width * 2 / 3) {
                    data.delta = middleDelta[1];
                    data.anchor = TextAnchor.MiddleCenter;
                    return data;
                } else {
                    data.delta = middleDelta[2];
                    data.anchor = TextAnchor.MiddleRight;
                    return data;
                }
            } else {
                if (Input.mousePosition.x < Screen.width * 1 / 3) {
                    data.delta = upperDeltas[0];
                    data.anchor = TextAnchor.UpperLeft;
                    return data;
                } else if (Input.mousePosition.x < Screen.width * 2 / 3) {
                    data.delta = upperDeltas[1];
                    data.anchor = TextAnchor.UpperCenter;
                    return data;
                } else {
                    data.delta = upperDeltas[2];
                    data.anchor = TextAnchor.UpperRight;
                    return data;
                }
            }
        }

    }
}

