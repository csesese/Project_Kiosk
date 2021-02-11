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
    public partial class Kiosk : Form
    {
        string Menu;//선택 메뉴
        string Option;//옵션 선택
        int surang;//수량 체크
        string str;
        string IceHot;
        string menu_price_Name;
        int each_price = 0; //메뉴 하나하나 가격     
        int main_price = 0;
        int option_price = 0;
        int total_price = 0; //총 가격 
        string orderNum; //주문 번호
        int data_num;// 행 개수(cart list table)
        string order_Time;// 주문시간 
        int 샷추가; // 샷이 추가된 개수


        public Kiosk()
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
                        //MessageBox.Show("DB 연결이 되었습니다.");
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
            if (Panel_add.Visible == true)
            {
                Panel_add.Visible = false;
                초기화();
            }

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

            string sql = "select  cast(price as int) as price from Menu where menu = '" + menu_price_Name + "' ";

            DataTable logDt = new DataTable();
            int nRet = DBHelper.ExecuteReader(sql, out logDt);

            if(nRet == 0)
            {
                string p = logDt.Rows[0]["price"].ToString();
                this.each_price = Convert.ToInt32(p);
            }

            return each_price; //click 한 메뉴 가격 

        }

        //공통메서드 : 최종 가격 
        public int total_sum()
        {
            string sql = "select sum(each_price) as total_price from Cart";

            DataTable logDt = new DataTable();
            int nRet = DBHelper.ExecuteReader(sql, out logDt);

            if (nRet == 0)
            {

                string p = logDt.Rows[0]["total_price"].ToString();
                this.total_price = Convert.ToInt32(p);
            }
            
            return total_price; //click 한 메뉴 가격 
        }

        //공통메서드 : Cart -> order_Detail  & Cart-> order_hisotry
        public void CartToOrderdetail()
        {
            //Cart -> order_Detail  
            string sql = "sp_order_insert '" + orderNum + "','" + total_price + "','" + data_num + "' ";
            DBHelper.ExecuteNonQuery(sql);
        }

        //공통메서드 : Cart에 있는 데이터들 삭제 
        public void DeleteCart()
        {
            string delete_sql = "delete from Cart ";
            DBHelper.ExecuteNonQuery(delete_sql);

            this.total_price = 0;
            this.IceHot = null; 
            each_price = 0;
            main_price = 0;
            option_price = 0;
            Total_price_label.Text = string.Format("{0:n0}", total_price) + " 원";

        }

        //공통메서드 : 초기화 
        public void 초기화()
        {
            option_name.Text = "+";
            Option = null;

            option_price = 0;
            each_price = 0;
            count.Value = 1;
            샷추가=0;
        }

        //주문 전체 취소 
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DeleteCart();

                MessageBox.Show("주문이 전체 취소 되었습니다.");

                total_price = 0;
                each_price = 0;
                main_price = 0;
                option_price = 0;

                ((DataTable)dataGridView1.DataSource).Rows.Clear(); // 화면상의 datagird 행들 삭제
            }
            else
            {
                MessageBox.Show("장바구니에 담긴 주문이 없습니다.");
                return;
            }
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

            
            switch (Mbtn.Text)
            {
                //1 coffee
                case "바닐라 라떼":               
                case "카푸치노":
                case "카페모카":
                case "카페라떼":
                case "아메리카노":
                    Panel_add_c.Visible = true;
                    Panel_add_j.Visible = false;
                    Panel_add_t.Visible = false;
                    break;
               case "에스프레소":
                    IceHot = "-";
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
            this.main_price = Click_Price();

        }

        #endregion
        //END-------------------------------------------------

        //++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region 주문담기(옵션)

        //돌아가기         
        private void Btn_back_Click(object sender, EventArgs e)
        {
            Panel_add.Visible = false;
            초기화();
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

            if (Option == null)
            {
                Option = "-";
            }
            if (surang == 0)
            {
                surang = 1;
            }

            if (IceHot == null)
            {    MessageBox.Show("ICE 또는 HOT 을 선택해주세요."); 
                return;   }
 
            int sum = ((main_price + option_price) * surang);


            string sql = "sp_add_toCart '" + Menu + "','" + surang + "','" + Option + "','" + IceHot + "','" + sum + "' ";
            DBHelper.ExecuteNonQuery(sql);
            this.total_price += sum;

            //주문담기 후 수량 초기화

            초기화();
            this.IceHot = null;           
            main_price = 0;
           


            //---------장부구니 list 보여주기-------------
            DataTable dtOut = null;
          
            string cart_sql = "show_CartList";
            int Out = DBHelper.ExecuteReader(cart_sql,out dtOut);
            dataGridView1.DataSource = dtOut;

            //dataGridView 스타일

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //크키조정
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 186;
            dataGridView1.Columns[4].Width = 40;
            dataGridView1.Columns[5].Width = 59;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.EnableHeadersVisualStyles = false;           


            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


            Total_price_label.Text = string.Format("{0:n0}", total_price) + " 원";

            dataGridView1.RowHeadersVisible = false; //첫 열 지우기     

            Panel_add.Visible = false;


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
                        

            if (menu_price_Name.Equals("샷추가"))
            {
                this.샷추가++;               
            }

            this.option_price += Click_Price();//옵션 price 

            if (Option == null)
            {
                str = Abtn.Text;
                option_name.Text = Abtn.Text;
            }
            else
            {
                if (Option.Equals("사이즈업"))
                {
                    MessageBox.Show("사이즈업은 한 번만 가능합니다!");
                    return;
                }
                else
                {
                    if (샷추가 > 3)
                    {
                        MessageBox.Show("샷추가는 최대 3번 가능합니다.");                       
                        return;
                    }
                    else
                    {
                        this.str = str + "+" + Abtn.Text;
                        option_name.Text += "+" + Abtn.Text;
                    }                    
                }                         
            }
            this.Option = str.Trim();
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
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            string selected = dataGridView1.CurrentRow.Cells["No"].Value.ToString();

            string sql = "delete from Cart where card_Serial= '" + selected +  "'";

            DBHelper.ExecuteNonQuery(sql);

            foreach (DataGridViewRow dgr in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(dgr);
            }
            //최종 가격 변경 
            this.total_price = total_sum();
            Total_price_label.Text = string.Format("{0:n0}", total_price) + " 원";

        }


        //장바구니에서 개수 변경 하기
        private void Btn_cart_modify_Click(object sender, EventArgs e)
        {
            //장바구니에 상품이 없을 때 개수변경 불가
            if (dataGridView1.Rows.Count == 0)
            {
                
                MessageBox.Show("개수변경 할 상품이 없습니다.");
            }
            else
            {
                
                //1 선택한 행의 card_serial no 에 원래 개수 저장
                string selected = dataGridView1.CurrentRow.Cells["No"].Value.ToString();
                int gaesu = 0;
                int gagaek = 0;

                string sql = "select count ,each_price from Cart where card_Serial ='" + selected + "'";

                DataTable logDt = new DataTable();
                int nRet = DBHelper.ExecuteReader(sql, out logDt);

                if (nRet == 0)
                {
                    string c = logDt.Rows[0]["count"].ToString();
                    string ep = logDt.Rows[0]["each_price"].ToString();

                    gaesu = Convert.ToInt32(c);// 변경 전 개수
                    gagaek = Convert.ToInt32(ep); // 변경 전 가격 

                }


                //2 변경된 개수 확인
                string selected_gaesu = dataGridView1.CurrentRow.Cells["개수"].Value.ToString();
                int changed_gaesu = Convert.ToInt32(selected_gaesu);

                //3 계산 : 변경된 개수에 맞는 가격
                int sum = (gagaek / gaesu) * changed_gaesu;

                //4 db변경 
                dataGridView1.CurrentRow.Cells[5].Value = sum;

                string sql2 = "update Cart set count = '" + changed_gaesu + "', each_price = '" + sum + "' where card_Serial ='" + selected + "'";
                DBHelper.ExecuteNonQuery(sql2);

                //5 최종 가격 변경 
                this.total_price = total_sum();
                Total_price_label.Text = string.Format("{0:n0}", total_price) + " 원";
            }
        }

        #endregion
        //END-------------------------------------------------

        //++++++++++++++++++++++++++++++++++++++++++++++++++++
        #region 결재 진행
        //Pay 
        private void Btn_pay_Card_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("결재할 상품이 없습니다.");
            }
            else { 
                this.data_num = ((DataTable)dataGridView1.DataSource).Rows.Count; //행 개수            

                this. order_Time = DateTime.Now.ToString("yyyyMMddHHmmss");
                this.orderNum = "Ord" + dataGridView1.Rows[0].Cells[0].Value.ToString() + "#" + order_Time; //주문 번호

                DialogResult dr = MessageBox.Show("카드를 넣어주세요.", "결재 진행 중", MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    //Cart -> order_Detail  
                    CartToOrderdetail();
                    //-------------주문시작하면 cart에 있는 정보 삭제 
                    DeleteCart();
                    MessageBox.Show("결재가 완료 되었습니다.");
                    Panel_add.Visible = false;
                    ((DataTable)dataGridView1.DataSource).Rows.Clear(); // 화면상의 datagird 행들 삭제

                    초기화();
                }
                else
                {
                    DialogResult Repay = MessageBox.Show("결재가 취소 되었습니다. 다시 결재 진행할까요? ", "결재 취소", MessageBoxButtons.OKCancel);
                    if (Repay == DialogResult.OK)

                    {
                        //Cart -> order_Detail  
                        CartToOrderdetail();
                        //-------------주문시작하면 cart에 있는 정보 삭제   
                        DeleteCart();
                        MessageBox.Show("결재가 완료 되었습니다.");
                        Panel_add.Visible = false;
                        ((DataTable)dataGridView1.DataSource).Rows.Clear(); // 화면상의 datagird 행들 삭제
                    }
                    else
                    {
                        MessageBox.Show("주문이 취소되었습니다.");
                        DeleteCart();

                        Panel_add.Visible = false;
                        ((DataTable)dataGridView1.DataSource).Rows.Clear(); // 화면상의 datagird 행들 삭제

                    }
                }
            }
        }

        private void close_Confirm(object sender, FormClosingEventArgs e)
        {
            //종료버튼 클릭시, 장바구니 다 삭제 
            DeleteCart();
        }
        #endregion
        //END-------------------------------------------------


    }
    
}


