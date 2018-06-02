using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Layout
{
    public class CardsLayout : LayoutGroup
    {

        [SerializeField] protected float m_Spacing = 0;
        public float spacing { get { return m_Spacing; } set { SetProperty(ref m_Spacing, value); } }

        [SerializeField] protected bool m_ChildForceExpandWidth = true;
        public bool childForceExpandWidth { get { return m_ChildForceExpandWidth; } set { SetProperty(ref m_ChildForceExpandWidth, value); } }

        [SerializeField] protected bool m_ChildForceExpandHeight = true;
        public bool childForceExpandHeight { get { return m_ChildForceExpandHeight; } set { SetProperty(ref m_ChildForceExpandHeight, value); } }

        [SerializeField] protected bool m_ChildControlWidth = true;
        public bool childControlWidth { get { return m_ChildControlWidth; } set { SetProperty(ref m_ChildControlWidth, value); } }

        [SerializeField] protected bool m_ChildControlHeight = true;
        public bool childControlHeight { get { return m_ChildControlHeight; } set { SetProperty(ref m_ChildControlHeight, value); } }
        public override void CalculateLayoutInputVertical()
        {
            base.CalculateLayoutInputHorizontal();
            CalcAlongAxis(0, false);
        }
        public override void CalculateLayoutInputHorizontal()
        {
            CalcAlongAxis(1, false);
        }
        public override void SetLayoutHorizontal()
        {
            SetChildrenAlongBezier();
        }

        public override void SetLayoutVertical()
        {
            SetChildrenAlongBezier();
        }

        protected void SetChildrenAlongBezier()
        {
            Vector3[] worldCorners = new Vector3[4];
            rectTransform.GetWorldCorners(worldCorners);
            var parent= gameObject.transform.parent.gameObject;
            var bottomLeft = gameObject.transform.InverseTransformDirection(worldCorners[0]);
            var bottomRight = gameObject.transform.InverseTransformDirection(worldCorners[3]);
            //var middleTop = gameObject.transform.InverseTransformDirection((worldCorners[2] + worldCorners[0]) / 2);
            var middleTop = gameObject.transform.InverseTransformDirection(new Vector3((worldCorners[3].x + worldCorners[0].x) / 2, worldCorners[2].y, 0));
            float offest = 1f / (rectChildren.Count + 1);
            

            for (int i = 0; i < rectChildren.Count; i++)
            {
                RectTransform child = rectChildren[i];
                if (child != null)
                {
                    var vector = Bezier(bottomLeft, bottomRight, middleTop, offest * (i+1));
                    child.position = vector;
                }
            }
        }

        private void GetChildSizes(RectTransform child, int axis, bool controlSize, bool childForceExpand,
            out float min, out float preferred, out float flexible)
        {
            if (!controlSize)
            {
                min = child.sizeDelta[axis];
                preferred = min;
                flexible = 0;
            }
            else
            {
                min = LayoutUtility.GetMinSize(child, axis);
                preferred = LayoutUtility.GetPreferredSize(child, axis);
                flexible = LayoutUtility.GetFlexibleSize(child, axis);
            }

            if (childForceExpand)
                flexible = Mathf.Max(flexible, 1);
        }

        private Vector2 Bezier(Vector2 v0, Vector2 v1, Vector2 a0, float t)//根据当前时间t 返回路径  其中v0为起点 v1为终点 a为中间点   
        {
            Vector2 a;
            a = t * t * (v1 - 2 * a0 + v0) + v0 + 2 * t * (a0 - v0);//公式为B(t)=(1-t)^2*v0+2*t*(1-t)*a0+t*t*v1 其中v0为起点 v1为终点 a为中间点   
            return a;
        }

        protected void CalcAlongAxis(int axis, bool isVertical)
        {
            //padding.horizontal=left+right
            //padding.vertical=top+bottom
            float combinedPadding = (axis == 0 ? padding.horizontal : padding.vertical);
            bool controlSize = (axis == 0 ? m_ChildControlWidth : m_ChildControlHeight);
            bool childForceExpandSize = (axis == 0 ? childForceExpandWidth : childForceExpandHeight);

            float totalMin = combinedPadding;
            float totalPreferred = combinedPadding;
            float totalFlexible = 0;

            //XOR
            bool alongOtherAxis = (isVertical ^ (axis == 1));
            for (int i = 0; i < rectChildren.Count; i++)
            {
                RectTransform child = rectChildren[i];
                float min, preferred, flexible;
                GetChildSizes(child, axis, controlSize, childForceExpandSize, out min, out preferred, out flexible);

                if (alongOtherAxis)
                {
                    totalMin = Mathf.Max(min + combinedPadding, totalMin);
                    totalPreferred = Mathf.Max(preferred + combinedPadding, totalPreferred);
                    totalFlexible = Mathf.Max(flexible, totalFlexible);
                }
                else
                {
                    totalMin += min + spacing;
                    totalPreferred += preferred + spacing;

                    // Increment flexible size with element's flexible size.
                    totalFlexible += flexible;
                }
            }

            if (!alongOtherAxis && rectChildren.Count > 0)
            {
                totalMin -= spacing;
                totalPreferred -= spacing;
            }
            totalPreferred = Mathf.Max(totalMin, totalPreferred);
            SetLayoutInputForAxis(totalMin, totalPreferred, totalFlexible, axis);
        }

        #if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();

            // For new added components we want these to be set to false,
            // so that the user's sizes won't be overwritten before they
            // have a chance to turn these settings off.
            // However, for existing components that were added before this
            // feature was introduced, we want it to be on be default for
            // backwardds compatibility.
            // Hence their default value is on, but we set to off in reset.
            m_ChildControlWidth = false;
            m_ChildControlHeight = false;
        }

#endif
    }
}
