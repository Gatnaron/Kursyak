using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursyak
{
    public partial class Form1 : Form
    {
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;
        int[,] AMatrix;
        int[,] FWMatrix;

        //Выбранные вершины, для созданимя ребер.
        int selected1;
        int selected2;
        public int weight1;
        public int weight2;
        public Form1()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = new List<Edge>();
            sheet.Image = G.GetBitmap();
        }

        //Кнопка - Курсор
        private void selectButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
        }

        //Кнопка - создать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //Кнопка - создать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        //Кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //Кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            var MBSave = MessageBox.Show("Вы действительно хотите полностью удалить граф?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearSheet();
                sheet.Image = G.GetBitmap();
            }
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //нажата кнопка "курсор"
            if (selectButton.Enabled == false)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        if (selected1 != 1)
                        {
                            selected1 = 1;
                            G.clearSheet();
                            G.drawALLGraph(V, E);
                            sheet.Image = G.GetBitmap();
                        }
                        if (selected1 == -1)
                        {
                            G.drawSelectedVertex(V[i].x, V[i].y);
                            selected1 = i;
                            sheet.Image = G.GetBitmap();
                            break;
                        }
                    }
                }
            }

            //нажата кнопка "создать вершину"
            if (drawVertexButton.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y));
                G.drawVertex(e.X, e.Y, V.Count.ToString());
                sheet.Image = G.GetBitmap();
            }

            //нажата кнопка "создать ребро"
            
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button ==MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected2 = i;
                                Form2 form = new Form2(this);
                                form.ShowDialog();
                                E.Add(new Edge(selected1, selected2, weight1));
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1]);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                        }
                    }
                }

                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1)&&(Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        sheet.Image = G.GetBitmap();
                    }
                }
            }

            //нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //Удалили ли что-нибудь по данному клику
                //если вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].v1 == i) || (E[j].v2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].v1 > i) E[j].v1--;
                                if (E[j].v2 > i) E[j].v2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                //если ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].v1 == E[i].v2) //если петля
                        {
                            if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                    (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                //если было удалено, то обновляем граф на эране (sheet)
                if (flag)
                {
                    G.clearSheet();
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        //Матрица смежности
        private void buttonAdj_Click(object sender, EventArgs e)
        {
            AMatrix = new int[V.Count, V.Count];
            G.fillAdjacencymatrix(V.Count, E, AMatrix);
            try
            {
                if (V.Count == 0) throw new Exception("Графа нет");
                {
                    dataGridViewMatrix1.Rows.Clear();
                    dataGridViewMatrix1.Font = new Font("Comic Sans MS", 9);
                    dataGridViewMatrix1.RowCount = V.Count;
                    dataGridViewMatrix1.ColumnCount = V.Count;
                    dataGridViewMatrix1.RowHeadersWidth = 50;
                    dataGridViewMatrix1.ColumnHeadersHeight = 50;

                    for (int i = 0; i < V.Count; i++)
                    {
                        for (int j = 0; j < V.Count; j++)
                        {
                            dataGridViewMatrix1.Columns[j].Width = 30;
                            dataGridViewMatrix1.Rows[i].Height = 30;
                            dataGridViewMatrix1.Rows[i].HeaderCell.Value = $"V{i + 1}";
                            dataGridViewMatrix1.Columns[j].HeaderCell.Value = $"V{j + 1}";
                            dataGridViewMatrix1.Rows[i].Cells[j].Value = AMatrix[i, j];
                        }
                    }
                }
            }
            catch (Exception error) 
            {
                MessageBox.Show(error.Message, "Ошибка"); 
            }
        }

        private void buttonFW_Click(object sender, EventArgs e)
        {
            FWMatrix = new int[V.Count, V.Count];
            G.AlgorithmFW(V.Count, E, FWMatrix);
            try
            {
                if (V.Count == 0) throw new Exception("Графа нет");
                {
                    dataGridViewMatrix2.Rows.Clear();
                    dataGridViewMatrix2.Font = new Font("Comic Sans MS", 9);
                    dataGridViewMatrix2.RowCount = V.Count;
                    dataGridViewMatrix2.ColumnCount = V.Count;
                    dataGridViewMatrix2.RowHeadersWidth = 50;
                    dataGridViewMatrix2.ColumnHeadersHeight = 50;

                    for (int i = 0; i < V.Count; i++)
                    {
                        for (int j = 0; j < V.Count; j++)
                        {
                            dataGridViewMatrix2.Columns[j].Width = 30;
                            dataGridViewMatrix2.Rows[i].Height = 30;
                            dataGridViewMatrix2.Rows[i].HeaderCell.Value = $"V{i + 1}";
                            dataGridViewMatrix2.Columns[j].HeaderCell.Value = $"V{j + 1}";
                            dataGridViewMatrix2.Rows[i].Cells[j].Value = FWMatrix[i, j];
                        }
                    }
                }
            }
            catch (Exception error)
            { 
                    MessageBox.Show(error.Message, "Ошибка");
                   
            }
        }
    }
}
