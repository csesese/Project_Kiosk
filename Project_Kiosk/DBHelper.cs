using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Kiosk
{
    class DBHelper
    {
        //커넥션 객체 
        public static SqlConnection conn = null;
       
        public static string DBConnString { get; private set; }
        public static bool bDBConnCheck = false;
        public static int errorBoxCount = 0;

        //생성자 
        public DBHelper() { }
        public static SqlConnection DBConn
        {
            get
            {
                if (!ConnectToDB())
                {
                    return null;
                }
                return conn;
            }
        }

        //DB 서버 접속 시도 
        public static bool ConnectToDB()
        {
            if (conn == null)
            {   //서버명, 초기 DB명, 인증방법
                DBConnString = string.Format("Data Source=({0});Initial Catalog={1};Integrated Security={2}; " +
                    "Timeout = 3", "local", "kioskData", "SSPI");

                conn = new SqlConnection(DBConnString);
            }

            try
            {
                if (!IsDBConnected)
                {
                    conn.Open();


                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        bDBConnCheck = true;
                    }
                    else
                    {
                        bDBConnCheck = false;
                    }
                }
            }
            catch (SqlException e)
            {
                errorBoxCount++;
                if (errorBoxCount == 1)
                {
                    MessageBox.Show(e.Message, "DBHelper-ConnectToDB()");
                }
                return false;
            }
            return true;
        }

        //DB OPEN 여부 확인 
        public static bool IsDBConnected
        {
            get
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    return false;
                }
                return true;
            }
        }

        //결과 집합을 반환 o
        public static int ExecuteReader(string sql, out DataTable dtOut)
        {
            //SqlCommand sqlComm = null;           
            SqlDataAdapter adapter = null;
            
            //출력 초기화
            dtOut = null;
            adapter = new SqlDataAdapter(sql,conn);

            dtOut = new DataTable();
            adapter.Fill(dtOut);
            return 0;

        }

        //처리용 쿼리 (결과 집합을 반환 x)
        public static int ExecuteNonQuery(string sql)
        {
            SqlCommand sqlComm = null;

            sqlComm = new SqlCommand(sql, conn);

            sqlComm.ExecuteNonQuery();
            MessageBox.Show("ExecuteNonQuery 작업 종료");
            return 0;
        }

        //DB 해제 
        public static void Close()
        {
            if (IsDBConnected)
                DBConn.Close();
        }

    }
}
