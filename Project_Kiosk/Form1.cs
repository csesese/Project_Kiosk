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
        static String connectingString = "server=127.0.0.1,1433; uid=dzicube; pwd=ejwhs123$; database=kioskData;";

        string Menu;//선택 메뉴
        string Option;//옵션 선택
        int surang;//수량 체크
        string str;
        string IceHot;
        string menu_price_Name;
        int each_price=0; //메뉴 하나하나 가격     
        int main_price = 0;
        int option_price = 0;
        int total_price=0; //총 가격 


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

                        DBHelper.Close();

                        MessageBox.Show("DB 연결을 끊었습니다.");
                    }
                }
            }
            catch (ArgumentNullException ane)
            {
                MessageBox.Show(ane.Message, "DataGridView_Load Error");

            }
        }


        //카테고리별 관련 panel 뜸
        private void Btn_category_Click(object sender, EventArgs e)
        {

            Panel_coffee.Visible = false;
            Panel_Juice.Visible = false;
            Panel_etc.Visible = false;
            Panel_bakery.Visible = false;

            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "Btn_coffee":
                    Panel_coffee.Visible = true;
                    break;
                case "Btn_juice":
                    Panel_Juice.Visible = true;
                    break;
                case "Btn_etc":
                    Panel_etc.Visible = true;
                    break;
                case "Btn_bakery":
                    Panel_bakery.Visible = true;
                    break;
            }


        }

        //공통메서드 : Button 클릭시 해당 메뉴/옵션 가격 가져옴
        public int Click_Price()
        {
           
            string sql = "select  cast(price as int) as price from Menu where menu = @param1 ";

            SqlConnection sqlConn = new SqlConnection(connectingString);
            SqlCommand sqlComm = new SqlCommand(sql,sqlConn);     
            
            sqlComm.Parameters.AddWithValue("@param1", menu_price_Name);

            sqlConn.Open();
            SqlDataReader reader = sqlComm.ExecuteReader();

            while (reader.Read())
            {
                
                string p = reader["price"].ToString();                
                
                this.each_price = Convert.ToInt32(p);
                
                //MessageBox.Show("선택 가격:" + each_price +"/메인가격  :" +main_price+" /옵션가격: "+option_price);

            }
            
            reader.Close();
            sqlConn.Close();
            return each_price; //click 한 메뉴 가격 

        }

        //-----------------------------------------------------------------
        #region 메인메뉴 선택 btn_click
        //1.메인메뉴 선택-> 선택옵션 panel뜸
        private void mainMenu_Click(object sender, EventArgs e)
        {
            Button Mbtn = sender as Button;
            this.Menu = Mbtn.Text; //선택 메뉴 이름

            menu_name.Text = Menu;
            this.menu_price_Name = Menu;

            Panel_add.Visible = true;
            Panel_add_c.Visible = false;
            Panel_add_j.Visible = false;
            Panel_add_t.Visible = false;



            switch(Mbtn.Text)
            {
                //1 coffee
                case "바닐라 라떼":
                case "에스프레소":
                case "카푸치노" :
                case "카페모카":
                case "카페라떼" :
                case "아메리카노":
                    Panel_add_c.Visible = true;                    
                    Panel_add_j.Visible = false;
                    Panel_add_t.Visible = false;
                    break;

                //2 티
                case "얼그레이":
                case "밀크티":
                case "로즈마리":
                case "녹차":
                case "캐모마일":
                    Panel_add_c.Visible = false;
                    Panel_add_j.Visible = false;
                    Panel_add_t.Visible = true;
                    break;
                //juice & etc
                case "딸기주스":
                case "키위주스":
                case "바나나주스":
                case "유자 스파클링":
                case "망고스무디":
                case "청포도 스파클링":
                case "블루베리 스무디":
                case "요거트스무디":
                case "복숭아 아이스티":
                case "아포가토":
                    IceHot = "ICE";
                    Panel_add_c.Visible = false;
                    Panel_add_j.Visible = true;
                    Panel_add_t.Visible = false;
                    break;
                //bakery
                case "베이글":
                case "마카롱":
                case "허니브레드":
                    IceHot = "-";
                    break;

            }
            this.main_price=Click_Price();

        }

        #endregion
        //-----------------------------------------------------------

        //------------------------------------------------------------
        #region 상품담기(옵션)

        //돌아가기         
        private void Btn_back_Click(object sender, EventArgs e)
        {
            Panel_add.Visible = false;

            option_name.Text = "+";
            Option = null;

            option_price = 0;
            each_price = 0;

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
            
            string sql = "insert into Cart(menu_ID,count,menu_option,IceHot,each_price) values (@param1,@param2,@param3,@param4,@param5)";
            SqlConnection sqlConn = new SqlConnection(connectingString);
            SqlCommand sqlComm = new SqlCommand(sql,sqlConn);
            

            MessageBox.Show(Menu + "," + Option + "/" + surang);
            if (Option == null)
            {
                Option = "-";
            }
            if (surang == 0)
            {
                surang = 1;

            }

            int sum = ((main_price + option_price) * surang);

            sqlComm.Parameters.AddWithValue("@param1", Menu);
            sqlComm.Parameters.AddWithValue("@param2", surang);
            sqlComm.Parameters.AddWithValue("@param3", Option);
            sqlComm.Parameters.AddWithValue("@param4", IceHot);
            sqlComm.Parameters.AddWithValue("@param5", sum);
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();

            this.total_price += sum;
            Label_Price.Text = "가격:" + total_price.ToString();

            //주문담기 후 수량 초기화
            count.Value = 1;
            Option = null;

            each_price = 0;
            main_price = 0;
            option_price = 0;

        }


        //선택 옵션 사항 "선택취소" 하기
        private void Btn_optionCancel_Click(object sender, EventArgs e)
        {
            Option = null;
            option_name.Text = "+";

            option_price = 0;


        }

        #endregion
        //------------------------------------------------------

        #region OPTION 선택
        //2.옵션 선택 
        private void Btn_coffeeOption_Click(object sender, EventArgs e)
        {

            Button Abtn = sender as Button;
            this.menu_price_Name = Abtn.Text;

            this.option_price += Click_Price();//옵션 price 

            if (Option == null)
            {
                str = Abtn.Text;
                option_name.Text = Abtn.Text;
            }
            else
            {
                this.str = str + "+" + Abtn.Text;
                option_name.Text += "+" + Abtn.Text;
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
        #endregion
        //----------------------------------------------------------

        
        #region 메인 화면 : 전체 주문 최소 & 최종 주문하기 
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            string sql = "delete from Cart";
            
            SqlConnection sqlConn = new SqlConnection(connectingString);
            SqlCommand sqlComm = new SqlCommand(sql, sqlConn);
            sqlConn.Open();
            sqlComm.ExecuteNonQuery();
            sqlConn.Close();

            MessageBox.Show("주문이 전체 취소 되었습니다.");

            total_price = 0;
            each_price = 0;
            main_price = 0;
            option_price = 0;


        }

        private void Btn_Order_Click(object sender, EventArgs e)
        {
            DataTable table = null;

            SqlDataAdapter adapter = new SqlDataAdapter(
                "select c.IceHot as Type, c.menu_ID, c.menu_option , c.count , c.each_price from Cart c left outer join Menu m on c.menu_ID = m.menu ", DBHelper.DBConn);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Total_price_label.Text= total_price.ToString()+" 원";
            Label_Price.Text = "가격:";

            total_price = 0;
            each_price = 0;
            main_price = 0;
            option_price = 0;

            


        }

        #endregion
        //----------------------------------------------------------


    }
}

