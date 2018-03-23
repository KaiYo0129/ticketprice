using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticketprice3
{
    public partial class Form1 : Form
    {
        private List<MyPrice> ticket;
        string click = "ticket";
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                ticket = TicketDate();
                CreateNSList(ticket);
            }
        }

        private void CreateNSList(List<MyPrice> ticket)
        {
           
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            if (radioButton1.Checked)
            {
                var disS = ticket.Distinct(new DistinstEqualityComparer());
                foreach (var item in disS)
                {
                    comboBox1.Items.Add(item.startstation);
                    comboBox1.DisplayMember = item.startstation;
                }
            }
            else
            {
                var disS = ticket.Distinct(new DistinstEqualityComparer2());
                foreach (var item in disS)
                {
                    comboBox1.Items.Add(item.endstation);
                    comboBox1.DisplayMember = item.endstation;
                }
            }
        }

        private List<MyPrice> TicketDate()
        {
            List<MyPrice> ticketPrice = new List<MyPrice>();
            ticketPrice.Add(new MyPrice { startstation = "台北", endstation = "新竹", ticketprice = 177 });
            ticketPrice.Add(new MyPrice { startstation = "台北", endstation = "台中", ticketprice = 375 });
            ticketPrice.Add(new MyPrice { startstation = "台北", endstation = "嘉義", ticketprice = 598 });
            ticketPrice.Add(new MyPrice { startstation = "台北", endstation = "台南", ticketprice = 738 });
            ticketPrice.Add(new MyPrice { startstation = "台北", endstation = "高雄", ticketprice = 842 });
            ticketPrice.Add(new MyPrice { startstation = "新竹", endstation = "台中", ticketprice = 197 });
            ticketPrice.Add(new MyPrice { startstation = "新竹", endstation = "嘉義", ticketprice = 421 });
            ticketPrice.Add(new MyPrice { startstation = "新竹", endstation = "台南", ticketprice = 560 });
            ticketPrice.Add(new MyPrice { startstation = "新竹", endstation = "高雄", ticketprice = 755 });
            ticketPrice.Add(new MyPrice { startstation = "台中", endstation = "嘉義", ticketprice = 224 });
            ticketPrice.Add(new MyPrice { startstation = "台中", endstation = "台南", ticketprice = 363 });
            ticketPrice.Add(new MyPrice { startstation = "台中", endstation = "高雄", ticketprice = 469 });
            ticketPrice.Add(new MyPrice { startstation = "嘉義", endstation = "台南", ticketprice = 139 });
            ticketPrice.Add(new MyPrice { startstation = "嘉義", endstation = "高雄", ticketprice = 245 });
            ticketPrice.Add(new MyPrice { startstation = "台南", endstation = "高雄", ticketprice = 106 });
            
            return ticketPrice;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                ticket = TicketDate();
                CreateNSList(ticket);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "台北":

                    if (radioButton1.Checked == true)
                    {
                        CreateSelectedPlace("north");
                    }
                    else if (radioButton2.Checked == true)
                    {
                        CreateSelectedPlace("south");
                    }
                    break;
                case "新竹":
                    if (radioButton1.Checked == true)
                    {
                        CreateSelectedPlace("north");
                    }
                    else if (radioButton2.Checked == true)
                    {
                        CreateSelectedPlace("south");
                    }
                    break;
                case "台中":
                    if (radioButton1.Checked == true)
                    {
                        CreateSelectedPlace("north");
                    }
                    else if (radioButton2.Checked == true)
                    {
                        CreateSelectedPlace("south");
                    }
                    break;
                case "嘉義":
                    if (radioButton1.Checked == true)
                    {
                        CreateSelectedPlace("north");
                    }
                    else if (radioButton2.Checked == true)
                    {
                        CreateSelectedPlace("south");
                    }
                    break;
                case "台南":
                    if (radioButton1.Checked == true)
                    {
                        CreateSelectedPlace("north");
                    }
                    else if (radioButton2.Checked == true)
                    {
                        CreateSelectedPlace("south");
                    }
                    break;
                case "高雄":
                    if (radioButton1.Checked == true)
                    {
                        CreateSelectedPlace("north");
                    }
                    else if (radioButton2.Checked == true)
                    {
                        CreateSelectedPlace("south");
                    }
                    break;
            }
        }

        private void CreateSelectedPlace(string click)
        {
            switch (click)
            {
                case "north":
                    comboBox2.Items.Clear();
                    var n = ticket.FindAll((x) => x.startstation == comboBox1.SelectedItem.ToString());
                    foreach (var item in n)
                    {
                        comboBox2.Items.Add(item.endstation);
                        comboBox2.DisplayMember = item.endstation;
                    }
                    break;
                case "south":
                    comboBox2.Items.Clear();
                    var s = ticket.FindAll((x) => x.endstation == comboBox1.SelectedItem.ToString());
                    foreach (var item in s)
                    {
                        comboBox2.Items.Add(item.startstation);
                        comboBox2.DisplayMember = item.startstation;
                    }
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                if (radioButton1.Checked == true)
                {
                    findTickPrice("north");
                }
                else if (radioButton2.Checked == true)
                {
                    findTickPrice("south");
                }
            }
            else
            {
                MessageBox.Show("Please select your information!");
                label4.Text = "0";
            }
        }

        private void findTickPrice(string click)
        {
            decimal total;
            switch (click)
            {
                case "north":
                    var n = ticket.Where((x) => x.startstation == comboBox1.SelectedItem.ToString()).Where((y) => y.endstation == comboBox2.SelectedItem.ToString());
                    total = checkPriceOnSale(n);
                    label4.Text = total.ToString();
                    break;
                case "south":
                    var s = ticket.Where((x) => x.endstation == comboBox1.SelectedItem.ToString()).Where((y) => y.startstation == comboBox2.SelectedItem.ToString());
                    total = checkPriceOnSale(s);
                    label4.Text = total.ToString();
                    break;
                default:
                    label4.Text = "error ticket";
                    break;
            }
        }

        private decimal checkPriceOnSale(IEnumerable<MyPrice> searchTicket)
        {
            decimal total = 0;
            if (checkBox1.Checked == true)
            {
                if (checkBox2.Checked == true)
                {
                    foreach (var item in searchTicket)
                    {
                        var final = item.ticketprice;
                        final = Decimal.Ceiling(Decimal.Multiply(Decimal.Multiply(final, 2), Convert.ToDecimal(0.81)));
                        foreach (var i in searchTicket)
                        {
                            label5.Text = "此為來回優惠票" + '\n' + "上車地點-下車地點:   " + '\n' + i.startstation + "-" + i.endstation + '\n' + i.endstation + "-" + i.startstation;
                        }
                        return final;
                    }
                }
                else
                {
                    foreach (var item in searchTicket)
                    {
                        var final = item.ticketprice;
                        final = Decimal.Ceiling(Decimal.Multiply(Decimal.Multiply(final, 2), Convert.ToDecimal(0.9)));
                        foreach (var i in searchTicket)
                        {
                            label5.Text = "此為來回票" + '\n' + "上車地點-下車地點:   " + '\n' + i.startstation + "-" + i.endstation + '\n' + i.endstation + "-" + i.startstation;
                        }
                        return final;
                    }
                }
            }
            else if (checkBox2.Checked == true)
            {
                foreach (var item in searchTicket)
                {
                    var final = item.ticketprice;
                    final = Decimal.Ceiling(Decimal.Multiply(final, Convert.ToDecimal(0.9)));
                    foreach (var i in searchTicket)
                    {
                        label5.Text = "優惠票" + '\n' + "上車地點-下車地點:" + '\n' + i.startstation + "-" + i.endstation;
                    }
                    return final;
                }
            }
            else
            {
                foreach (var item in searchTicket)
                {
                    foreach (var i in searchTicket)
                    {
                        label5.Text = "上車地點-下車地點:" + '\n' + i.startstation + "-" + i.endstation;
                    }
                    return item.ticketprice;
                }
            }
            return total;
        }
    }
}
