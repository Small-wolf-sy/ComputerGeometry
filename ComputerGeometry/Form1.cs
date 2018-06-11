using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PenFunctions;
using TreeNodes;
using MyFunctions;

namespace ComputerGeometry
{
    public partial class Form1 : Form
    {
        //构造画笔
        public static Pen pen = new Pen(Color.Red, 1);
        public static Pen pen2 = new Pen(Color.White, 1);
        PenFunction mypen = new PenFunction();
        public static List<Point> AllPoints = new List<Point>();
        Node TopNode = new Node();
        public static List<Node> AllNodes = new List<Node>();
        public static List<Node> EventNodes = new List<Node>();
        Functions funcs = new Functions();
        int num = 1;
        bool flag_y = true;
        float y_last = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBoxShow_Click(object sender, MouseEventArgs e)
        {
            Graphics g = PictureBoxShow.CreateGraphics();
            float x = e.X;
            float y = e.Y;
            //如果保持下降趋势
            if ((y>y_last)&&flag_y)
            {
                y_last = y;
            }
            else if ((y > y_last) && !flag_y)
            {
                MessageBox.Show("这不符合单调多边形规则，请重新绘制");
                g.Clear(Color.White);
                AllPoints.Clear();
                AllNodes.Clear();
                EventNodes.Clear();
                num = 1;
                return;
            }
            else if ((y < y_last) && flag_y)
            {
                y_last = y;
                flag_y = false;
            }
            Point p = new Point();
            p.X = Convert.ToInt32(x);
            p.Y = Convert.ToInt32(y);
            mypen.drawpoint(g, p);
            string s = num.ToString()+"号点";
            mypen.drawText(g, p, s);
            AllPoints.Add(p);
            num = num + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int[] x = new int[] { 10, 20, 26, 19, 15, 14, 5, 4, 3, 1 };
            int[] y = new int[] { 5, 21, 48, 65, 69, 75, 55, 37, 30, 15 };
            Graphics g = PictureBoxShow.CreateGraphics();

            for (int i = 0; i < x.Length; i++)
            {
                Point p = new Point(x[i] * 15, y[i] * 5);
                //按单调排序
                AllPoints.Add(p);
                mypen.drawpoint(g, p);
            }

            //绘制线条
            for (int i = 1; i <= AllPoints.Count - 1; i++)
            {
                mypen.drawLine(g, AllPoints[i], AllPoints[i - 1]);
            }
            mypen.drawLine(g, AllPoints[AllPoints.Count - 1], AllPoints[0]);

            //开始处理节点
            //起点位置
            funcs.ConvertNodes(AllPoints, out AllNodes, out TopNode);
            funcs.ArrangeNodes(AllNodes, out EventNodes);

            mypen.DrawNodes(g, EventNodes);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EventNodes.Count == 0)
            {
                MessageBox.Show("请规划点再进行三角剖分！");
                return;
            }

            Graphics g = PictureBoxShow.CreateGraphics();
            bool flag;
            bool color_flag = true;
            //起始的2个节点
            List<Node> VerNode = new List<Node>();
            Node nodes1 = EventNodes[0];
            VerNode.Add(nodes1);
            Node nodes2 = EventNodes[1];
            VerNode.Add(nodes2);
            for (int i = 2; i < EventNodes.Count; i++)
            {
                Node checkNode = EventNodes[i];

                VerNode.Add(checkNode);

                if (i == EventNodes.Count - 1)
                {
                    if (VerNode.Count > 3)
                    {
                        checkNode.flag = !nodes2.flag;
                    }
                }

                if (checkNode.flag != nodes2.flag)
                {
                    //不包括第一个和第二个

                    if (i == EventNodes.Count - 1)
                    {

                        for (int j = 1; j < VerNode.Count - 1; j++)
                        {
                            mypen.drawNodeLine(g, checkNode, VerNode[j]);
                            mypen.drawTriangle(g, checkNode, VerNode[j], VerNode[j - 1], color_flag);
                            color_flag = !color_flag;
                        }
                        //画完线，开始删除顶点,只需要最后2个新的
                        nodes1 = VerNode[VerNode.Count - 2];
                        nodes2 = VerNode[VerNode.Count - 1];
                        VerNode = new List<Node>() { nodes1, nodes2 };
                        continue;
                    }

                    for (int j = 1; j < VerNode.Count - 1; j++)
                    {
                        mypen.drawNodeLine(g, checkNode, VerNode[j]);
                        mypen.drawTriangle(g, checkNode, VerNode[j], VerNode[j - 1], color_flag);
                        color_flag = !color_flag;
                    }
                    //画完线，开始删除顶点,只需要最后2个新的
                    nodes1 = VerNode[VerNode.Count - 2];
                    nodes2 = VerNode[VerNode.Count - 1];
                    VerNode = new List<Node>() { nodes1, nodes2 };
                }
                else
                {
                    Node node3 = VerNode[VerNode.Count - 3];
                    funcs.ComputeAngle(node3, nodes2, checkNode, out flag);
                    if (flag)
                    {
                        mypen.drawNodeLine(g, checkNode, node3);
                        mypen.drawTriangle(g, checkNode, node3, nodes2, color_flag);
                        color_flag = !color_flag;
                        VerNode.Remove(nodes2);
                        nodes2 = VerNode[VerNode.Count - 1];
                    }
                    else
                    {
                        nodes2 = VerNode[VerNode.Count - 1];
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = PictureBoxShow.CreateGraphics();
            //绘制线条
            for (int i = 1; i <= AllPoints.Count - 1; i++)
            {
                mypen.drawLine(g, AllPoints[i], AllPoints[i - 1]);
            }
            mypen.drawLine(g, AllPoints[AllPoints.Count - 1], AllPoints[0]);

            //开始处理节点
            //起点位置
            funcs.ConvertNodes(AllPoints, out AllNodes, out TopNode);
            funcs.ArrangeNodes(AllNodes.ToList(), out EventNodes);

            mypen.DrawNodes(g, EventNodes);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g=PictureBoxShow.CreateGraphics();
            g.Clear(Color.White);
            AllPoints.Clear();
            AllNodes.Clear();
            EventNodes.Clear();
            num = 1;
        }
    }
}
