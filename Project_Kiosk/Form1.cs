using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;//DB를 사용하기 위해 추가 
using System.Data.SqlClient;//DB를 사용하기 위해 추가 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Kiosk
{
    public partial class Form1 : Form
    {

        string Menu;//선택 메뉴
        string Option;//옵션 선택
        int surang;//수량 체크
        string str;
        string IceHot;

        public Form1()
        {
            InitializeComponent();

            //DB연결
            try
            {
                lock (DBHelper.DBConn)
                {
                    if (!DBHelper.IsDBConnected)
                    {
                        MessageBox.Show("DB 연결불가 , DB를 확인하세요.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("DB 연결이 되었습니다.");
                        //DB 연결이 되고 난 후
                       /* SqlDataAdapter adapter = new SqlDataAdapter(
                    "Select * From Student", DBHelper.DBConn);
                        date_table = new DataTable();*/

                        DBHelper.Close();
                    }

                }
            }
            catch (ArgumentNullException ane)
            {
                MessageBox.Show(ane.Message, "DataGridView_Load Error");

            }
        }

        private void Btn_coffee_Click(object sender, EventArgs e)
        {
            Panel_coffee.Visible = true;
            Panel_Juice.Visible = false;
            Panel_etc.Visible = false;
            Panel_bakery.Visible = false;


        }

        private void Btn_juice_Click(object sender, EventArgs e)
        {

            Panel_coffee.Visible = false;
            Panel_Juice.Visible = true;
            Panel_etc.Visible = false;
            Panel_bakery.Visible = false;


        }

        private void Btn_etc_Click(object sender, EventArgs e)
        {
            Panel_coffee.Visible = false;
            Panel_Juice.Visible = false;
            Panel_etc.Visible = true;
            Panel_bakery.Visible = false;

        }

        private void Btn_bakery_Click(object sender, EventArgs e)
        {
            Panel_coffee.Visible = false;
            Panel_Juice.Visible = false;
            Panel_etc.Visible = false;
            Panel_bakery.Visible = true;
        }

      //커피 메뉴 -> 선택옵션 panel뜸
        private void Btn_CoffeeDetail_Click(object sender, EventArgs e)
        {
            Button Mbtn = sender as Button;
            this.Menu = Mbtn.Text; //선택 메뉴 이름
           
            Panel_add_c.Visible = true;

            label1.Text = Menu;
        }

        //------------------------------------------------------------
        #region 상품담기

        //커피메뉴 ->선택옵션 -> 취소하기 하기 선택옵션 panel 사라짐
        private void Btn_back_Click(object sender, EventArgs e)
        {            
            Panel_add_c.Visible = false;
        }

        //커피 ->옵션 선택 
        private void Btn_coffeeOption_Click(object sender, EventArgs e)
        {
            
            Button Abtn = sender as Button;

            if (Option==null) 
            {                
                str = Abtn.Text;            
            }
            else
            {
                this.str = str + "+" + Abtn.Text;
                MessageBox.Show(str);
            }            
            this.Option = str;            
        }
        //Ice or Hot
        private void Btn_IceHot_Click(object sender, EventArgs e)
        {
            Button ihbtn = sender as Button;
            IceHot = ihbtn.Text;
        }
        

        //수량 체크 
        private void count_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown count = sender as NumericUpDown;
            decimal c = count.Value;
            this.surang = Convert.ToInt32(c);
          
        }

        //주문담기
        private void Btn_cart_Click(object sender, EventArgs e)
        {
            String connectingString = "server=127.0.0.1,1433; uid=dzicube; pwd=ejwhs123$; database=kioskData;";

            SqlConnection sqlConn = new SqlConnection(connectingString);
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;
            sqlComm.CommandText = "insert into Cart(menu_ID,count,menu_option,IceHot) values (@param1,@param2,@param3,@param4)";


            MessageBox.Show(Menu + "," + Option + "/" + surang);
            if (Option == null)
            {
                Option = "선택사항 없음";
            }

            sqlComm.Parameters.AddWithValue("@param1", Menu);
            sqlComm.Parameters.AddWithValue("@param2", surang);
            sqlComm.Parameters.AddWithValue("@param3", Option);
            sqlComm.Parameters.AddWithValue("@param4", IceHot);
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();


            //주문담기 후 수량 초기화
            count.Value = 1;
            Option = null;            

        }

        #endregion

        //주문 전체 쥐소하기(메인 화면)
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            String connectingString = "server=127.0.0.1,1433; uid=dzicube; pwd=ejwhs123$; database=kioskData;";

            SqlConnection sqlConn = new SqlConnection(connectingString);
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;
            sqlComm.CommandText = "delete from Cart";

            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();
        }


    }
}
