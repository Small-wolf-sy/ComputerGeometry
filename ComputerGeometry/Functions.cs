using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodes;
using System.Drawing;

namespace MyFunctions
{
    //本类用于提供各种通用型算法
    class Functions
    {
        /// <summary>
        /// 根据输入的节点，按照从上到下的顺序进行排序
        /// </summary>
        /// <param name="originNode"></param>
        /// <param name="EventNode"></param>
        public void ArrangeNodes(List<Node> originNode, out List<Node> EventNode)
        {
            EventNode = new List<Node>();
            while(originNode.Count>0)
            {
                Node checkNode = originNode[0];
                for(int i=0;i<originNode.Count;i++)
                {
                    //发现了更高的点,但因为C#的Y轴在屏幕上是竖直向下的，所以我们要找的是Y尽量小的点
                    if( (checkNode.data.Y>originNode[i].data.Y)||((checkNode.data.Y==originNode[i].data.Y)&&(checkNode.data.X>originNode[i].data.X)))
                    {
                        checkNode = originNode[i];
                    }
                }
                EventNode.Add(checkNode);
                originNode.Remove(checkNode);
            }
        }

        //将初始点转变为节点
        public void ConvertNodes(List<Point>originPoints,out List<Node>originNode,out Node TopNode)
        {
            originNode = new List<Node>();
            
            Node start = new Node();
            start.data = originPoints[0];
            start.flag = true;
            bool check_flag = true;
            originNode.Add(start);
            //将节点转换
            for (int i=1;i<originPoints.Count;i++)
            {
                Node newNode=new Node();
                newNode.data=originPoints[i];
                originNode[i - 1].right = newNode;
                newNode.left = originNode[i - 1];


                if (check_flag)
                {
                    //说明还是在下头的
                    if (newNode.data.Y >= originNode[i - 1].data.Y)
                    {
                        //相同
                        newNode.flag = check_flag;
                    }
                    else
                    {
                        //取相反
                        check_flag = !check_flag;
                        newNode.flag = check_flag;
                    }
                }

                //已经到了终止点了
                if(!check_flag)
                {
                    newNode.flag = check_flag;
                }


                originNode.Add(newNode);

            }
            originNode[0].left = originNode[originNode.Count-1];
            originNode[originNode.Count - 1].right = originNode[0];
            TopNode = originNode[0];

        }

        //计算夹角
        public void ComputeAngle(Node first,Node cen,Node second,out bool flag)
        {
            const double M_PI = 3.1415926535897;

            double ma_x = first.data.X - cen.data.X;
            double ma_y = first.data.Y - cen.data.Y;
            double mb_x = second.data.X - cen.data.X;
            double mb_y = second.data.Y - cen.data.Y;
            double v1 = (ma_x * mb_x) + (ma_y * mb_y);
            double ma_val = Math.Sqrt(ma_x * ma_x + ma_y * ma_y);
            double mb_val = Math.Sqrt(mb_x * mb_x + mb_y * mb_y);
            double cosM = v1 / (ma_val * mb_val);
            double angleAMB = Math.Acos(cosM) * 180 / M_PI;

            if (second.data.X>cen.data.X)
            {
                angleAMB=360-angleAMB;
            }

            if (angleAMB < 180)
            //if (angleAMB < 180)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
    }
}
