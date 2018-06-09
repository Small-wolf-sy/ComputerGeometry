using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TreeNodes
{
    public class Node
    {
        //节点本身数据
        public Point data;
        //左节点
        public Node left;
        //右节点
        public Node right;
        //判断是左链还是右链
        //true为右，false为左
        public bool flag;
    }
}
