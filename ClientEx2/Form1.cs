using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Build.Tasks.Xaml;

namespace ClientEx2
{
    public partial class Form1 : Form
    {
        ClassData classData = new ClassData();
        public Form1()
        {
            InitializeComponent();
            label1.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNIM.Text != "" &&
                txtNama.Text != "" &&
                txtProdi.Text != "" &&
                txtAngkatan.Text != "")
            {
                if (txtNIM.Text.Length <= 12 &&
                txtAngkatan.Text.Length <= 4 &&
                txtProdi.Text.Length <= 30 &&
                txtNama.Text.Length <= 20)
                {
                    try
                    {
                        Mahasiswa mhs = new Mahasiswa();
                        mhs.nim = txtNIM.Text;
                        mhs.nama = txtNama.Text;
                        mhs.prodi = txtProdi.Text;
                        mhs.angkatan = txtAngkatan.Text;

                        ClassData classData = new ClassData();
                        classData.updateDatabase(mhs);
                        MessageBox.Show("Data successfuly updated");
                        clear();
                        dataGridView1.DataSource = classData.getAllData();
                    }
                    catch
                    {
                        label6.Text = "Server Error";
                    }
                }
                else
                {
                    MessageBox.Show("Please check your data");
                }
            }
            else
            {
                MessageBox.Show("Please check your data");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = classData.getAllData();
            }
            catch
            {
                label6.Text = "Server error";
            }
        }
        public void clear()
        {
            txtNIM.Text = "";
            txtNama.Text = "";
            txtProdi.Text = "";
            txtAngkatan.Text = "";
            button3.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = true;
            label6.Text = "";
            dataGridView1.DataSource = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string data = classData.sumData();
                label1.Enabled = true;
                label6.Text = data.ToString();
            }
            catch (Exception ex)
            {
                label7.Text = "Server Error";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ClassData classData = new ClassData();
                    classData.deleteMahasiswa(txtNIM.Text);
                    clear();
                    dataGridView1.DataSource = classData.getAllData();
                    MessageBox.Show("Data successfuly deleted");
                }
                catch (Exception ex)
                {
                    label7.Text = "Server Error";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNIM.Text != "" &&
                txtNama.Text != "" &&
                txtProdi.Text != "" &&
                txtAngkatan.Text != "")
            {
                if (txtNIM.Text.Length <= 12 &&
                txtAngkatan.Text.Length <= 4 &&
                txtProdi.Text.Length <= 30 &&
                txtNama.Text.Length <= 20)
                {
                    try
                    {
                        string nim = txtNIM.Text;
                        string nama = txtNama.Text;
                        string prodi = txtProdi.Text;
                        string angkatan = txtAngkatan.Text;
                        classData.insertMahasiswa(nim, nama, prodi, angkatan);
                        clear();
                        dataGridView1.DataSource = classData.getAllData();
                        MessageBox.Show("Data successfuly inserted");
                    }
                    catch (Exception ex)
                    {
                        label6.Text = "Server Error";
                    }
                }
                else
                {
                    MessageBox.Show("Please check your data");
                }
            }
            else
            {
                MessageBox.Show("Please check your data");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNIM.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            txtNama.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            txtProdi.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            txtAngkatan.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);

            button2.Enabled = true;
            button3.Enabled = true;
            button1.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtNIM.Text != "")
            {
                string nim = txtNIM.Text;
                List<Mahasiswa> mhs = new List<Mahasiswa>();
                mhs.Add(classData.search(nim));
                clear();
                dataGridView1.DataSource = mhs;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tI_UMYDataSet.Mahasiswa' table. You can move, or remove it, as needed.
            this.mahasiswaTableAdapter.Fill(this.tI_UMYDataSet.Mahasiswa);

        }
    }
}
