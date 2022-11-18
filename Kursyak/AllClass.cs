using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Kursyak
{
    class Vertex
    {
        private int x_, y_;
        public List<Edge> ways = new List<Edge>();
        public int X { get { return x_; } set { x_ = value; } }
        public int Y
        { get { return y_; } set { y_ = value; } }

        public Vertex() { }

        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vertex(Vertex point)
        {
            X = point.X; Y = point.Y;
        }
    }   

    class Edge : IPrint
    {
        private int V1, V2;
        int Weight;

        public int v1 { get { return V1; } set { V1 = value; } }
        public int v2 { get { return V2; } set { V2 = value; } }
        public int weight { get { return Weight; } set { Weight = value; } }

        /*public List<Vertex> Points = new List<Vertex>();*/
        public Edge() { }

        public Edge(int v1_, int v2_, int weight_)
        {
            v1 = v1_;
            v2 = v2_;
            weight = weight_;
            /*Points.Add(v1); Points.Add(v2);*/
        }
        public Edge(Edge edge)
        {
            v1 = edge.v1; v2 = edge.v2; weight = edge.weight;
            /*Points.Add(v1); Points.Add(v2);*/
        }
        public void print()
        {
            Console.WriteLine(weight);
        }
    }

    [Serializable]
    public class GraphObj
    {
        public List<int> X = new List<int>();
        public List<int> Y = new List<int>();

        public List<int> v1 = new List<int>();
        public List<int> v2 = new List<int>();
        public List<int> weight = new List<int>();

        public GraphObj() { }

        public GraphObj(List<int> x, List<int> y, List<int> v1, List<int> v2, List<int> weight)
        {
            X = x;
            Y = y;
            this.v1 = v1;
            this.v2 = v2;
            this.weight = weight;
        }
    }

    interface IPrint
    {
        void print();
    }

    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGreenPen;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 15; //Радиус окружности вершины

        public List<Vertex> Points = new List<Vertex>();
        public List<Edge> Ways = new List<Edge>();

        XmlSerializer xmlS = new XmlSerializer(typeof(GraphObj));

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            darkGreenPen = new Pen(Color.DarkGreen);
            darkGreenPen.Width = 2;
            fo = new Font("Arial", 15);
            br = Brushes.Black;
        }
        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void drawVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
            /*this.Points.Add(new Vertex(x, y));*/
        }
        
        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E)
        {
            if (E.v1 == E.v2)
            {
                gr.DrawArc(darkGreenPen, (V1.X - 2 * R), (V1.Y - 2 * R), 2 * R, 2 * R, 90, 270);
                point = new PointF(V1.X - (int)(2.75 * R), V1.Y - (int)(2.75 * R));
                gr.DrawString(((int)(E.weight)).ToString(), fo, br, point);
                drawVertex(V1.X, V1.Y, (E.v1 + 1).ToString());
            }
            else
            {
                gr.DrawLine(darkGreenPen, V1.X, V1.Y, V2.X, V2.Y);
                point = new PointF((V1.X + V2.X) / 2, (V1.Y + V2.Y) / 2);
                gr.DrawString(((int)(E.weight)).ToString(), fo, br, point);
                drawVertex(V1.X, V1.Y, (E.v1 + 1).ToString());
                drawVertex(V2.X, V2.Y, (E.v2 + 1).ToString());
            }
            this.Ways.Add(E);
        }

        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            //Рисуем ребра
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].v1 == E[i].v2)
                {
                    gr.DrawArc(darkGreenPen, (V[E[i].v1].X - 2 * R), (V[E[i].v1].Y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[E[i].v1].X - (int)(2.75 * R), V[E[i].v1].Y - (int)(2.75 * R));
                    gr.DrawString(((int)(E[i].weight)).ToString(), fo, br, point);
                }
                else
                {
                    gr.DrawLine(darkGreenPen, V[E[i].v1].X, V[E[i].v1].Y, V[E[i].v2].X, V[E[i].v2].Y);
                    point = new PointF((V[E[i].v1].X + V[E[i].v2].X) / 2, (V[E[i].v1].Y + V[E[i].v2].Y) / 2);
                    gr.DrawString(((int)(E[i].weight)).ToString(), fo, br, point);
                }
            }
            
            //Рисуем вершины
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].X, V[i].Y, (i + 1).ToString());
            }
        }

        //Заполнение матрицы смежности
        public void fillAdjacencymatrix(int numberV, List<Edge> E, int[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
            {
                for (int j = 0; j < numberV; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, E[i].v2] = E[i].weight;
                matrix[E[i].v2, E[i].v1] = E[i].weight;
            }
            for (int i = 0; i < numberV; i++)
            {
                for (int j = 0; j < numberV; j++)
                {
                    if (matrix[i, j] == 0 && i != j)
                    {
                        matrix[i, j] = 101;
                    }
                }
            }
        }
        
        //Алгоритм Флойда - Уоршелла
        public int[,] AlgorithmFW1(int numberV, List<Edge> E, int[,] matrix)
        {
            int[,] result = new int[numberV, numberV];
            for (int k = 0; k < numberV; k++)
            {
                for (int i = 0; i < numberV; i++)
                {
                    for (int j = 0; j < numberV; j++)
                    {
                        if (matrix[i, k] + matrix[k, j] < matrix[i, j])
                        {
                            if (matrix[i,j] == 101)
                            {
                                matrix[i, j] = matrix[i, k] + matrix[k, j];
                            }
                            result[i, j] = matrix[i, k] + matrix[k, j];
                        }
                    }
                }
            }
            for (int i = 0; i < numberV; i++)
            {
                for (int j = 0; j < numberV; j++)
                {
                    if (result[i,j]==0 && i!=j)
                    {
                        result[i, j] = matrix[i, j];
                    }
                }
            }
            return result;
        }

        public void SaveXML(string path)
        {
            List<int> x_ = new List<int>();
            List<int> y_ = new List<int>();

            List<int> v1 = new List<int>();
            List<int> v2 = new List<int>();
            List<int> weight = new List<int>();

            foreach (var item in this.Points)
            {
                x_.Add(item.X);
                y_.Add(item.Y);
            }
            foreach (var item in this.Ways)
            {
                v1.Add(item.v1);
                v2.Add(item.v2);
                weight.Add(item.weight);
            }
            var graphObj = new GraphObj(x_, y_, v1, v2, weight);
            if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate))
            {
                xmlS.Serialize(fs, graphObj);
                fs.Close();
            }
        }

        public GraphObj OpenXML(string path)
        {
            GraphObj GrObj = new GraphObj();
            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate))
            {
                try { GrObj = xmlS.Deserialize(fs) as GraphObj; }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                fs.Close();
            }
            Points.Clear();
            Ways.Clear();
            
            return GrObj;
        }
    }
}
