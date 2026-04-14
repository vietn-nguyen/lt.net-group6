using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanKhau_Nhom6
{
    class KETNOI_CSDL
    {
        // Chuỗi kết nối - Thành nhớ kiểm tra tên máy (Source) cho đúng nhé
        public string strKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyNhanKhauTinh;Integrated Security=True";
        public SqlConnection cnn;

        // 1. Hàm mở kết nối
        public void KetNoi_DuLieu()
        {
            try
            {
                cnn = new SqlConnection(strKetNoi);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();

                    // THÊM ĐOẠN NÀY: Thiết lập định danh người dùng cho phiên làm việc hiện tại
                    if (UserSession.CurrentUserId != -1)
                    {
                        // CONTEXT_INFO yêu cầu kiểu varbinary(128). 
                        // Chúng ta cast ID sang varbinary để SQL nhận diện đúng.
                        string sqlSetContext = "DECLARE @ctx varbinary(128) = CAST(@uid AS varbinary(128)); SET CONTEXT_INFO @ctx;";
                        using (SqlCommand cmd = new SqlCommand(sqlSetContext, cnn))
                        {
                            cmd.Parameters.AddWithValue("@uid", UserSession.CurrentUserId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
            }
        }

        // 2. Hàm đóng kết nối
        public void DongKetNoi()
        {
            if (cnn != null && cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }

        // 3. Hàm lấy dữ liệu (Dùng cho DataGridView hoặc ComboBox)
        public DataTable LayBang(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi_DuLieu();
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                da.Fill(dt);
                DongKetNoi();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi lấy bảng: " + ex.Message);
            }
            return dt;
        }

        // 4. Hàm thực thi lệnh (Thêm, Sửa, Xóa thông thường)
        public void ThucThi(string sql)
        {
            try
            {
                KetNoi_DuLieu();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                DongKetNoi();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi thực thi lệnh: " + ex.Message);
            }
        }

        // 5. HÀM MỚI: Chạy Stored Procedure (Dùng cho cái sp_Login bảo mật của bạn)
        public DataTable LayDuLieuTuProc(string procName, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi_DuLieu();
                SqlCommand cmd = new SqlCommand(procName, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                DongKetNoi();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi gọi Procedure: " + ex.Message);
            }
            return dt;
        }
    }
}