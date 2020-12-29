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

            SqlCommand sqlComm = new SqlCommand(sql,DBHelper.conn);     
            
            sqlComm.Parameters.AddWithValue("@param1", menu_price_Name);
            
            SqlDataReader reader = sqlComm.ExecuteReader();

            while (reader.Read())
            {
                
                string p = reader["price"].ToString();                
                
                this.each_price = Convert.ToInt32(p);
                
                //MessageBox.Show("선택 가격:" + each_price +"/메인가격  :" +main_price+" /옵션가격: "+option_price);

            }            
            reader.Close();            
            return each_price; //click 한 메뉴 가격 

        }

        //공통메서드 : 최종 가격 
        public int total_sum()
        {
            string sql = "select sum(each_price) as total_price from Cart";

            SqlCommand sqlComm = new SqlCommand(sql, DBHelper.conn);            

            SqlDataReader reader = sqlComm.ExecuteReader();

            while (reader.Read())
            {

                string p = reader["total_price"].ToString();

                this.total_price = Convert.ToInt32(p);              

            }
            reader.Close();
            return total_price; //click 한 메뉴 가격 
        }

        //주문 전체 취소 
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            string sql = "delete from Cart";

            SqlCommand sqlComm = new SqlCommand(sql, DBHelper.conn);

            sqlComm.ExecuteNonQuery();
            MessageBox.Show("주문이 전체 취소 되었습니다.");

            total_price = 0;
            each_price = 0;
            main_price = 0;
            option_price = 0;

        }
        

        //++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region 메인메뉴 선택 btn_click
        //1.메인메뉴 선택-> 선택옵션 panel뜸
        private void mainMenu_Click(object sender, EventArgs e)
        {
            Button Mbtn = sender as Button;
            this.Menu = Mbtn.Text; //선택 메뉴 이름

            menu_name.Text = Menu;
            this.menu_price_Name = Menu;

            Panel_add.Visible = true;
            Panel_add.BringToFront();
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
        //END-------------------------------------------------

        //++++++++++++++++++++++++++++++++++++++++++++++++++++
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
          
            SqlCommand sqlComm = new SqlCommand(sql,DBHelper.conn);
            

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
           
            sqlComm.ExecuteNonQuery();           

            this.total_price += sum;            

            //주문담기 후 수량 초기화
            count.Value = 1;
            Option = null;

            each_price = 0;
            main_price = 0;
            option_price = 0;


            //---------장부구니 list 보여주기-------------
            DataTable table = null;

            SqlDataAdapter adapter = new SqlDataAdapter(
                "select c.card_Serial as No , c.IceHot as Type, c.menu_ID as 메뉴, c.menu_option as 선택사항 , c.count as 개수, c.each_price as 가격 from Cart c left outer join Menu m on c.menu_ID = m.menu ", DBHelper.DBConn);
            table = new DataTable();

            adapter.Fill(table);
            dataGridView1.DataSource = table;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            Total_price_label.Text = total_price.ToString() + " 원";

            dataGridView1.RowHeadersVisible = false; //첫 열 지우기     

           
        }


        #endregion
        //END-------------------------------------------------

        //++++++++++++++++++++++++++++++++++++++++++++++++++++
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

        //선택 옵션 사항 "선택취소" 하기
        private void Btn_optionCancel_Click(object sender, EventArgs e)
        {
            Option = null;
            option_name.Text = "+";

            option_price = 0;

        }
        #endregion
        //END-------------------------------------------------

        //++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region 장바구니 : 취소 & 수정 
        //장바구니 에서 취소하기 
        private void Btn_cart_cancel_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count==0)
            {
                return;
            }

            string selected = dataGridView1.CurrentRow.Cells["No"].Value.ToString();           

            string sql = "delete from Cart where card_Serial= @param2";

            SqlCommand sqlComm = new SqlCommand(sql, DBHelper.conn);
            sqlComm.Parameters.AddWithValue("@param2", selected);

            sqlComm.ExecuteNonQuery();

            foreach (DataGridViewRow dgr in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(dgr);
            }
            //최종 가격 변경 
            this.total_price = total_sum();
            Total_price_label.Text = total_price.ToString() + " 원";

        }
        //장바구니에서 개수 변경 하기
        private void Btn_cart_modify_Click(object sender, EventArgs e)
        {
            //1 선택한 행의 card_serial no 에 원래 개수 저장
            string selected = dataGridView1.CurrentRow.Cells["No"].Value.ToString();
            int ss = Convert.ToInt32(selected);
            int gaesu = 0;
            int gagaek = 0;

            string sql = "select count ,each_price from Cart where card_Serial = @param1";

            SqlCommand sqlComm = new SqlCommand(sql, DBHelper.conn);

            sqlComm.Parameters.AddWithValue("@param1", selected);

            SqlDataReader reader = sqlComm.ExecuteReader();

            while (reader.Read())
            {

                string c = reader["count"].ToString();
                string ep = reader["each_price"].ToString();

                gaesu = Convert.ToInt32(c);// 변경 전 개수
                gagaek = Convert.ToInt32(ep); // 변경 전 가격 


            }
            reader.Close();
            

            //2 변경된 숫자 확인
            string selected_gaesu = dataGridView1.CurrentRow.Cells["개수"].Value.ToString();
            int changed_gaesu = Convert.ToInt32(selected_gaesu);

            //3 선택한 행의 가격 확인
            string selected_price = dataGridView1.CurrentRow.Cells["가격"].Value.ToString();
            int changed_price = Convert.ToInt32(selected_price);

            MessageBox.Show("원래" + gaesu + " / 변경" +changed_gaesu+"/가격 "+ gagaek);

            //4 계산 : 변경된 개수에 맞는 가격
            int sum = (gagaek / gaesu) * changed_gaesu;
            int minus_price = gagaek - sum; // 가격 차액

            int tp = total_price - minus_price;            


            //5 db변경 
            dataGridView1.CurrentRow.Cells[5].Value = sum;

            string sql2 = "update Cart set count = @param1, each_price = @param2 where card_Serial = @param3";

            SqlCommand sqlComm2 = new SqlCommand(sql2, DBHelper.conn);
            sqlComm2.Parameters.AddWithValue("@param1", changed_gaesu);
            sqlComm2.Parameters.AddWithValue("@param2", sum);
            sqlComm2.Parameters.AddWithValue("@param3", selected);

            sqlComm2.ExecuteNonQuery();

            //최종 가격 변경 
            this.total_price = total_sum();
            Total_price_label.Text = total_price.ToString() + " 원";
        }


        #endregion
        //END-------------------------------------------------


    }
}

