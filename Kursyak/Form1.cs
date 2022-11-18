using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
                    if (Math.Pow((V[i].X - e.X), 2) + Math.Pow((V[i].Y - e.Y), 2) <= G.R * G.R)
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
                            G.drawSelectedVertex(V[i].X, V[i].Y);
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
                G.Points.Add(new Vertex(e.X, e.Y));
                sheet.Image = G.GetBitmap();
            }

            //нажата кнопка "создать ребро"
            
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button ==MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].X - e.X), 2) + Math.Pow((V[i].Y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].X, V[i].Y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].X, V[i].Y);
                                selected2 = i;
                                Form2 form = new Form2(this);
                                form.ShowDialog();
                                Edge temp = new Edge(selected1, selected2, weight1);
                                temp.print();
                                E.Add(temp);
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
                    if ((selected1 != -1)&&(Math.Pow((V[selected1].X - e.X), 2) + Math.Pow((V[selected1].Y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].X, V[selected1].Y, (selected1 + 1).ToString());
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
                    if (Math.Pow((V[i].X - e.X), 2) + Math.Pow((V[i].Y - e.Y), 2) <= G.R * G.R)
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
                            if ((Math.Pow((V[E[i].v1].X - G.R - e.X), 2) + Math.Pow((V[E[i].v1].Y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].v1].X - G.R - e.X), 2) + Math.Pow((V[E[i].v1].Y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].v1].X) * (V[E[i].v2].Y - V[E[i].v1].Y) / (V[E[i].v2].X - V[E[i].v1].X) + V[E[i].v1].Y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].X) * (V[E[i].v2].Y - V[E[i].v1].Y) / (V[E[i].v2].X - V[E[i].v1].X) + V[E[i].v1].Y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].X <= V[E[i].v2].X && V[E[i].v1].X <= e.X && e.X <= V[E[i].v2].X) ||
                                    (V[E[i].v1].X >= V[E[i].v2].X && V[E[i].v1].X >= e.X && e.X >= V[E[i].v2].X))
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
                            if (AMatrix[i, j] != 101)
                                dataGridViewMatrix1.Rows[i].Cells[j].Value = AMatrix[i, j];
                            else
                                dataGridViewMatrix1.Rows[i].Cells[j].Value = "∞";
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
            //G.AlgorithmFW1(V.Count, E, AMatrix);
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

                    FWMatrix =  G.AlgorithmFW1(V.Count, E, AMatrix);

                    for (int i = 0; i < V.Count; i++)
                    {
                        for (int j = 0; j < V.Count; j++)
                        {
                            dataGridViewMatrix2.Columns[j].Width = 30;
                            dataGridViewMatrix2.Rows[i].Height = 30;
                            dataGridViewMatrix2.Rows[i].HeaderCell.Value = $"V{i + 1}";
                            dataGridViewMatrix2.Columns[j].HeaderCell.Value = $"V{j + 1}";
                            //dataGridViewMatrix2.Rows[i].Cells[j].Value = AMatrix[i, j];
                            dataGridViewMatrix2.Rows[i].Cells[j].Value = FWMatrix[i, j];
                        }
                    }
                }
                dataGridViewMatrix2.Refresh();
                dataGridViewMatrix2.Update();
            }
            catch (Exception error)
            { 
                    MessageBox.Show(error.Message, "Ошибка");
                   
            }
        }

        public void SaveGraph()
        {
            if (true)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить граф как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Файл графа (*.xml)|*.xml|Изображение (*.PNG)|*.png";

                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    /*if (savedialog.FileName.EndsWith(".png"))
                    {
                        try
                        {
                            picture.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            var dr = MessageBox.Show("Изображение успешно сохранено"
                                + Environment.NewLine
                                + "Просмотреть файл?", "Выполнено",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dr == DialogResult.Yes)
                                Process.Start(savedialog.FileName);
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить изображение", "Ошибка!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }*/
                    if (savedialog.FileName.EndsWith(".xml"))
                    {
                        try
                        {
                            G.SaveXML(savedialog.FileName);
                            var dr = MessageBox.Show("Граф успешно сохраненён", "Выполнено",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("Невозможно сохранить граф", "Ошибка!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Невозможно сохранить граф - пустой файл", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveGraph();
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Открыть файл графа...";
            opf.CheckPathExists = true;
            opf.Filter = "Файл графа (*.xml)|*.xml";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                G.clearSheet();
                try
                {
                    var GrObj = G.OpenXML(opf.FileName);
                    for (int i = 0; i < GrObj.X.Count; i++)
                    {
                        //drawVertex(GrObj.X[i], GrObj.Y[i], (i + 1).ToString());
                        V.Add(new Vertex(GrObj.X[i], GrObj.Y[i]));
                        Console.WriteLine(GrObj.X[i] + " " + GrObj.Y[i] + " " + (i + 1).ToString());
                    }
                    for (int i = 0; i < GrObj.v1.Count; i++)
                    {
                        //drawEdge(this.Points[GrObj.v1[i]], this.Points[GrObj.v2[i]], new Edge(GrObj.v1[i], GrObj.v2[i], GrObj.weight[i]));
                        E.Add(new Edge(GrObj.v1[i], GrObj.v2[i], GrObj.weight[i]));
                        Console.WriteLine(GrObj.v1[i] + " " + GrObj.v2[i] + " " + GrObj.weight[i]);
                    }
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
