using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhanKhau_Nhom6
{
    /// <summary>
    /// Lớp kết nối và thao tác cơ sở dữ liệu duy nhất cho toàn bộ project.
    /// </summary>
    class KETNOI_CSDL
    {
        // Chuỗi kết nối – kiểm tra tên máy (Data Source) cho đúng
        public string strKetNoi = @"Data Source=DESKTOP-4F46I47\SQLEXPRESS;Initial Catalog=QuanLyNhanKhauTinh;Integrated Security=True";
        public SqlConnection cnn;

        // ─────────────────────────────────────────
        // 1. Mở kết nối + thiết lập CONTEXT_INFO
        // ─────────────────────────────────────────
        public void KetNoi_DuLieu()
        {
            try
            {
                cnn = new SqlConnection(strKetNoi);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();

                    if (UserSession.CurrentUserId != -1)
                    {
                        string sqlSetContext =
                            "DECLARE @ctx varbinary(128) = CAST(@uid AS varbinary(128)); SET CONTEXT_INFO @ctx;";
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
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi hệ thống");
            }
        }

        // ─────────────────────────────────────────
        // 2. Đóng kết nối
        // ─────────────────────────────────────────
        public void DongKetNoi()
        {
            if (cnn != null && cnn.State == ConnectionState.Open)
                cnn.Close();
        }

        // ─────────────────────────────────────────
        // 3. LayBang – truy vấn không tham số (tương thích các form cũ)
        // ─────────────────────────────────────────
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
                MessageBox.Show("Lỗi lấy bảng: " + ex.Message, "Lỗi");
            }
            return dt;
        }

        // ─────────────────────────────────────────
        // 4. ExecuteQuery – truy vấn có tham số (thay thế Database.ExecuteQuery)
        // ─────────────────────────────────────────
        public DataTable ExecuteQuery(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi_DuLieu();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                DongKetNoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi");
            }
            return dt;
        }

        // ─────────────────────────────────────────
        // 5. ThucThi – thực thi không tham số (tương thích các form cũ)
        // ─────────────────────────────────────────
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
                MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi");
            }
        }

        // ─────────────────────────────────────────
        // 6. ExecuteNonQuery – thực thi có tham số, trả về số dòng bị ảnh hưởng
        //    (thay thế Database.ExecuteNonQuery)
        // ─────────────────────────────────────────
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            int rows = 0;
            try
            {
                KetNoi_DuLieu();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                rows = cmd.ExecuteNonQuery();
                DongKetNoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi");
            }
            return rows;
        }

        // ─────────────────────────────────────────
        // 7. LayDuLieuTuProc – gọi Stored Procedure
        // ─────────────────────────────────────────
        public DataTable LayDuLieuTuProc(string procName, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                KetNoi_DuLieu();
                SqlCommand cmd = new SqlCommand(procName, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                DongKetNoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gọi Procedure: " + ex.Message, "Lỗi");
            }
            return dt;
        }
    }
}