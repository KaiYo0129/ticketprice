using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticketprice
{
    public partial class Form1 : Form
    {
        private List<MyPrice> south;
        private List<MyPrice> north;

        public Form1()
        {
            InitializeComponent();
            var north = TicketDateNorth();
            var south = TicketDateSouth();
            var n = north.GroupBy((x) => x.startstation);
            foreach (var item in n)
            {
                comboBox1.Items.Add(item.Key);
                comboBox1.DisplayMember = item.Key;
            }
        }



        private List<MyPrice> TicketDateSouth()
        {
            List<MyPrice> _myPrice1 = new List<MyPrice>();
            _myPrice1.Add(new MyPrice { startstation = "新竹", endstation = "台北", ticketprice = 177 });
            _myPrice1.Add(new MyPrice { startstation = "台中", endstation = "台北", ticketprice = 375 });
            _myPrice1.Add(new MyPrice { startstation = "台中", endstation = "新竹", ticketprice = 197 });
            _myPrice1.Add(new MyPrice { startstation = "嘉義", endstation = "台北", ticketprice = 598 });
            _myPrice1.Add(new MyPrice { startstation = "嘉義", endstation = "新竹", ticketprice = 421 });
            _myPrice1.Add(new MyPrice { startstation = "嘉義", endstation = "台中", ticketprice = 224 });
            _myPrice1.Add(new MyPrice { startstation = "台南", endstation = "台北", ticketprice = 738 });
            _myPrice1.Add(new MyPrice { startstation = "台南", endstation = "新竹", ticketprice = 560 });
            _myPrice1.Add(new MyPrice { startstation = "台南", endstation = "台中", ticketprice = 363 });
            _myPrice1.Add(new MyPrice { startstation = "台南", endstation = "嘉義", ticketprice = 139 });
            _myPrice1.Add(new MyPrice { startstation = "高雄", endstation = "台北", ticketprice = 842 });
            _myPrice1.Add(new MyPrice { startstation = "高雄", endstation = "新竹", ticketprice = 755 });
            _myPrice1.Add(new MyPrice { startstation = "高雄", endstation = "台中", ticketprice = 469 });
            _myPrice1.Add(new MyPrice { startstation = "高雄", endstation = "嘉義", ticketprice = 245 });
            _myPrice1.Add(new MyPrice { startstation = "高雄", endstation = "台南", ticketprice = 106 });
            return _myPrice1;
        }
        private List<MyPrice> TicketDateNorth()
        {
            List<MyPrice> _myPrice = new List<MyPrice>();
            _myPrice.Add(new MyPrice { startstation = "台北" ,endstation = "新竹" ,ticketprice = 177});
            _myPrice.Add(new MyPrice { startstation = "台北", endstation = "台中", ticketprice = 375});
            _myPrice.Add(new MyPrice { startstation = "台北", endstation = "嘉義", ticketprice = 598});
            _myPrice.Add(new MyPrice { startstation = "台北", endstation = "台南", ticketprice = 738});
            _myPrice.Add(new MyPrice { startstation = "台北", endstation = "高雄", ticketprice = 842});
            _myPrice.Add(new MyPrice { startstation = "新竹", endstation = "台中", ticketprice = 197});
            _myPrice.Add(new MyPrice { startstation = "新竹", endstation = "嘉義", ticketprice = 421});
            _myPrice.Add(new MyPrice { startstation = "新竹", endstation = "台南", ticketprice = 560});
            _myPrice.Add(new MyPrice { startstation = "新竹", endstation = "高雄", ticketprice = 755});
            _myPrice.Add(new MyPrice { startstation = "台中", endstation = "嘉義", ticketprice = 224});
            _myPrice.Add(new MyPrice { startstation = "台中", endstation = "台南", ticketprice = 363});
            _myPrice.Add(new MyPrice { startstation = "台中", endstation = "高雄", ticketprice = 469});
            _myPrice.Add(new MyPrice { startstation = "嘉義", endstation = "台南", ticketprice = 139});
            _myPrice.Add(new MyPrice { startstation = "嘉義", endstation = "高雄", ticketprice = 245});
            _myPrice.Add(new MyPrice { startstation = "台南", endstation = "高雄", ticketprice = 106});
            
            return _myPrice;
        }

        

        


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                var north = TicketDateNorth();
                switch (comboBox1.Text)
                {
                    case "台北":
                        var check  = north.FindAll((x)=>x.startstation == comboBox1.Text).Find((x)=>x.endstation ==comboBox2.Text);
                        if (check!=null)
                        {
                            var an = north.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if(checkBox1.Checked==true)
                                {
                                    if(checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final,Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                               
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "新竹":
                        check = north.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = north.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "台中":
                        check = north.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check!=null)
                        {
                            var an = north.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "嘉義":
                        check = north.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = north.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "台南":
                        
                        check = north.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = north.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "高雄":
                        check = north.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = north.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    default:
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                }
            }
            else if (radioButton2.Checked == true)
            {
                var south = TicketDateSouth();
                switch (comboBox1.Text)
                {
                    case "台北":
                        var check = south.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = south.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "新竹":
                        check = south.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = south.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "台中":
                        check = south.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = south.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "嘉義":
                        check = south.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = south.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "台南":
                        
                        check = south.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = south.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                } 

                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    case "高雄":
                        check = south.FindAll((x) => x.startstation == comboBox1.Text).Find((x) => x.endstation == comboBox2.Text);
                        if (check != null)
                        {
                            var an = south.Where((x) => x.startstation == comboBox1.Text).Where((x) => x.endstation == comboBox2.Text);
                            foreach (var item in an)
                            {
                                if (checkBox1.Checked == true)
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.81)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                }
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        var final = item.ticketprice;
                                        final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                                        label4.Text = final.ToString();
                                    }
                                    else
                                    {
                                        var final = item.ticketprice;
                                        label4.Text = final.ToString();
                                    }

                                }
                            }
                        }
                        else
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                    default:
                        {
                            label4.Text = "查無此票";
                        }
                        break;
                        }

                }
            else
            {
                label4.Text = "??";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var north = TicketDateNorth();
            var south = TicketDateSouth();
            
            
            /*comboBox1.Items.Add("台北");
            comboBox1.Items.Add("新竹");
            comboBox1.Items.Add("台中");
            comboBox1.Items.Add("嘉義");
            comboBox1.Items.Add("台南");
            comboBox1.Items.Add("高雄");*/
            comboBox2.Items.Add("台北");
            comboBox2.Items.Add("新竹");
            comboBox2.Items.Add("台中");
            comboBox2.Items.Add("嘉義");
            comboBox2.Items.Add("台南");
            comboBox2.Items.Add("高雄");
        }
    }
}
