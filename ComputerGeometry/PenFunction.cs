using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TreeNodes;

namespace PenFunctions
{
    class PenFunction
    {
        public static Pen pen1=new Pen(Color.Red,4);
        public static Pen pen2 = new Pen(Color.Black, 4);

        //绘制点
        public void drawpoint(Graphics g, Point point)
        {
            //填充的点为左上角，如果想要让画的点为中心，那么就需要减去半径
            g.FillEllipse(Brushes.Red, point.X-2, point.Y-2, 4, 4);
        }
        public void drawLine(Graphics g,Point p1,Point p2)
        {
            g.DrawLine(pen1, p1, p2);
        }
        public void drawNodeLine(Graphics g,Node node1,Node node2)
        {
            g.DrawLine(pen2, node1.data, node2.data);
        }

        public void drawTriangle(Graphics g,Node node1,Node node2,Node node3,bool flag)
        {
            
            Point[] point = new Point[3];
            point[0] = node1.data;
            point[1] = node2.data;
            point[2] = node3.data;
            if (flag)
            {
                Brush brushes = new SolidBrush(Color.Red);
                g.FillPolygon(brushes,point);
            }
            else
            {
                Brush brushes = new SolidBrush(Color.Blue);
                g.FillPolygon(brushes, point);
            }
        }

        public void DrawPoint_Event(Graphics g, Node Nodes)
        {

            //黑为右边，蓝为左边
            if (Nodes.flag)
            {
                g.FillEllipse(Brushes.Black, Nodes.data.X - 4, Nodes.data.Y - 4, 8, 8);
            }
            else
            {
                g.FillEllipse(Brushes.Blue, Nodes.data.X - 4, Nodes.data.Y - 4, 8, 8);
            }

        }

        public void DrawNodes(Graphics g,List<Node>Nodes)
        {
            int num=1;
            while(num<=Nodes.Count)
            {
                int nums = 10000;
                while(nums>0)
                {
                    nums = nums - 1;
                }
                DrawPoint_Event(g, Nodes[num - 1]);
                num = num + 1;
            }
        }

    }
}
