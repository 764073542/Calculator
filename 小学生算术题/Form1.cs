using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 小学生算术题
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //定义为全局变量，一遍其他函数调用
        List<int> list_result = new List<int>(); //保存算数结果
        List<PictureBox> list_pic = new List<PictureBox>(); //保存结果对错对应的pic对象
        List<TextBox> list_input = new List<TextBox>(); //保存用户输入数据对应的textbox集合   
        List<Label> list_result_lable = new List<Label>(); //保存显示结果的label对象
        int right_rate = 0;
        int topic_size = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                topic_size = Int32.Parse(textBox1.Text.Trim());
            }
            catch (Exception)
            {
                MessageBox.Show("输入有误，将默认输出10道题目");
                topic_size = 10;
            }
            
            Random random = new Random(1000); //随机数种子            
            for (int i = 1; i <= topic_size; i++)
            {
                Label label_operand1 = new Label(); //运算数01
                Label label_0perator = new Label(); //运算符
                Label label_operand2 = new Label(); //运算数02
                Label label_equal = new Label(); //运算符 = 
                TextBox textBox = new TextBox(); // 用户输入的结果
                PictureBox pictureBox = new PictureBox(); //用户输入正误对应的pic
                Label label_result = new Label(); //结果显示label                
             
                DateTime date = DateTime.Now; //获取系统当前时间，添加时间变量，保证随机数不重复
                int num1 = (random.Next(1, 1000) + date.Millisecond) % 100;//生成1-100的随机数
                int num2 = (random.Next(1, 1000) + date.Millisecond) % 100;
                int Operator = (random.Next(1, 10) + date.Millisecond) % 2; //生成1/2的随机数来判断操作数

                //label_operand1
                label_operand1.AutoSize = true;
                label_operand1.Location = new System.Drawing.Point(40, 60 +(30* i)); //列布局               
                label_operand1.Size = new System.Drawing.Size(30, 12);
                label_operand1.TabIndex = 0;
                label_operand1.Text = num1 + "";

                //label_0perator
                label_0perator.AutoSize = true;
                label_0perator.Location = new System.Drawing.Point(80, 60 + (30 * i));                
                label_0perator.Size = new System.Drawing.Size(30, 12);
                label_0perator.TabIndex = 0;
                if (Operator % 2 == 0)
                {
                    label_0perator.Text = "+";
                    list_result.Add(num1 + num2);
                }
                else
                {
                    label_0perator.Text = "-";
                    list_result.Add(num1 - num2);
                }                

                //label_operand2
                label_operand2.AutoSize = true;
                label_operand2.Location = new System.Drawing.Point(120, 60 + (30 * i));               
                label_operand2.Size = new System.Drawing.Size(30, 12);
                label_operand2.TabIndex = 0;
                label_operand2.Text = num2 + "";

                //label_equal
                label_equal.AutoSize = true;
                label_equal.Location = new System.Drawing.Point(160, 60 + (30 * i));              
                label_equal.Size = new System.Drawing.Size(30, 12);
                label_equal.TabIndex = 0;
                label_equal.Text = "=";

                //textBox           
                textBox.Location = new System.Drawing.Point(200, 55 + (30 * i));                
                textBox.Size = new System.Drawing.Size(30, 20);
                textBox.TabIndex = 3;
                list_input.Add(textBox);

                //pictureBox        
                pictureBox.Location = new System.Drawing.Point(240, 50 + (30 * i));                
                pictureBox.Size = new System.Drawing.Size(30, 30);
                pictureBox.TabIndex = 5;
                pictureBox.TabStop = false;               
                list_pic.Add(pictureBox);

                //label_result
                label_result.AutoSize = true;
                label_result.Location = new System.Drawing.Point(280, 60 + (30 * i));
                label_result.Size = new System.Drawing.Size(30, 12);
                label_result.TabIndex = 0;
                list_result_lable.Add(label_result);
         

                //将创建的空间添加到布局上
                this.Controls.Add(label_operand1);
                this.Controls.Add(label_0perator);
                this.Controls.Add(label_operand2);
                this.Controls.Add(label_equal);
                this.Controls.Add(textBox);
                this.Controls.Add(pictureBox);
                this.Controls.Add(label_result);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            right_rate = 0;
             for(int i=0;i<list_input.Count;i++)
            {
                try
                {
                    int num = Int32.Parse(list_input[i].Text.Trim());

                    if (list_result[i] == num) //表示当前本条数据计算正确
                    {
                        list_pic[i].ImageLocation = System.Windows.Forms.Application.StartupPath + @"\\right.png";
                        right_rate++;
                    }
                    else
                    {
                        list_pic[i].ImageLocation = System.Windows.Forms.Application.StartupPath + @"\\fault.png";
                    }

                }
                catch (Exception)
                {
                    list_pic[i].ImageLocation = System.Windows.Forms.Application.StartupPath + @"\\fault.png";
                }                

            }
             label4.Text = ((float)right_rate/topic_size)*100 +"%";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i=0;i<list_result_lable.Count;i++)
            {
                list_result_lable[i].Text = list_result[i] + "";
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for(int i=0;i<list_input.Count;i++)
            {
                list_input[i].Text = list_result[i].ToString();
            }
            
        }
    }
}
