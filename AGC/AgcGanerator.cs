using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AGC.attributes;
using AGC.entity;

namespace AGC
{
    /// <summary>
    /// AGC生成器
    /// @author wenzq
    /// @date   2018.3.23
    /// </summary>
    public class AgcGanerator
    {
        private int X;
        private int Y;
        /// <summary>
        /// 设置
        /// </summary>
        private AgcSetting mSetting = new AgcSetting();
        /// <summary>
        /// 要添加生成控件的容器
        /// </summary>
        private Control mContainer;

        public AgcGanerator(Control container)
        {
            mContainer = container;
            init();
        }

        public AgcGanerator(Control container, AgcSetting agcSetting)
        {
            mContainer = container;
            mSetting = agcSetting;
            init();
        }

        private void init()
        {
            X = mSetting.MarginLeft;
            Y = mSetting.MarginTop;
        }

        public void generate(List<AgcBase> agcBaseList)
        {
            agcBaseList.Sort(delegate(AgcBase a1, AgcBase a2) { return a1.Index.CompareTo(a2.Index); });
            int betterY = 0;
            foreach (AgcBase agcBase in agcBaseList)
            {
                agcBase.init();
                agcBase.beforeGenerate();
                agcBase.generate();
                agcBase.afterGenerate();

                if (X != mSetting.MarginLeft && (agcBase.NewRow || 
                    (X + agcBase.MarginLeft + agcBase.TotalWidth + agcBase.MarginRight + mSetting.MarginRight) > mContainer.Width))
                {
                    X = mSetting.MarginLeft;
                    Y += betterY;
                    betterY = 0;
                }

                int tempX = X + agcBase.MarginLeft;
                int tempY = Y + agcBase.MarginTop;
                
                foreach (AgcControl agcCtl in agcBase.MAgcCtlList)
                {
                    int cX = tempX + agcCtl.MarginLeft;
                    agcCtl.MControl.Location = new System.Drawing.Point(cX, tempY + agcCtl.MarginTop);
                    mContainer.Controls.Add(agcCtl.MControl);

                    tempX += (agcCtl.MarginLeft + agcCtl.MControl.Width + agcCtl.MarginRight);
                }

                agcBase.theEnd();
                X += (agcBase.MarginLeft + agcBase.TotalWidth + agcBase.MarginRight + agcBase.AfterX + mSetting.SpacingX);
                int tY = (agcBase.MarginTop + agcBase.TotalHeight + agcBase.MarginButtom + agcBase.AfterY + mSetting.SpacingY);
                betterY = betterY > tY ? betterY : tY;
            }

            if (mSetting.ResetHeight)
            {
                mContainer.Height = Y + betterY + mSetting.MarginButtom;
            }
        }

    }
}
