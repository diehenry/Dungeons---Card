using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Layout
{
    [AddComponentMenu("Layout/Extensions/Cards Layout")]
    public class CardsLayout : HorizontalOrVerticalLayoutGroup
    {        
        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();
            CalcAlongAxis(0, false);
        }
        public override void CalculateLayoutInputVertical()
        {
            CalcAlongAxis(1, false);
        }
        public override void SetLayoutHorizontal()
        {
            SetChildrenAlongBezier();
            //SetChildrenAlongAxis(0, false);
        }

        public override void SetLayoutVertical()
        {
            SetChildrenAlongBezier();
            //SetChildrenAlongAxis(1, false);
        }

        protected void SetChildrenAlongBezier()
        {
            //m_Tracker.Clear();
            float offest = 1f / (rectChildren.Count + 1);
            var width = rectTransform.rect.width;
            var height = rectTransform.rect.height;
            var rotation = -90f / (rectChildren.Count - 1);
            for (int i = 0; i < rectChildren.Count; i++)
            {
                RectTransform child = rectChildren[i];
                if (child != null)
                {
                    m_Tracker.Add(this, child,
                    DrivenTransformProperties.Anchors |
                    DrivenTransformProperties.AnchoredPosition
                    );
                    var vector = Bezier(new Vector2(0, 0), new Vector2(width, 0), new Vector2(width / 2, height), offest * (i + 1));

                    child.transform.eulerAngles = new Vector3(
                        0,
                        0,
                        rotation * i + (45f)
                    );
                    


                    child.anchoredPosition = vector;

                    //child.transform.localPosition = vector;
                }
            }
        }


        private Vector2 Bezier(Vector2 v0, Vector2 v1, Vector2 a0, float t)//根据当前时间t 返回路径  其中v0为起点 v1为终点 a为中间点   
        {
            Vector2 a;
            a = t * t * (v1 - 2 * a0 + v0) + v0 + 2 * t * (a0 - v0);//公式为B(t)=(1-t)^2*v0+2*t*(1-t)*a0+t*t*v1 其中v0为起点 v1为终点 a为中间点   
            return a;
        }
    }
}
