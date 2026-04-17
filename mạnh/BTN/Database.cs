using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BTN
{
    internal class Database
    {
        private readonly string _connectionString;

        public Database()
        {
            _connectionString =
                "Server=(localdb)\\MSSQLLocalDB;Database=QuanLyNhanKhauTinh;Trusted_Connection=True;";
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // =========================
        // SELECT
        // =========================
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        conn.Open();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
                return new DataTable();
            }
        }

        // =========================
        // INSERT / UPDATE / DELETE
        // =========================
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
                return -1;
            }
        }

        // =========================
        // SCALAR
        // =========================
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex);
                return null;
            }
        }

        // =========================
        // HANDLE SQL ERRORS
        // =========================
        private void HandleSqlException(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2627:
                case 2601:
                    System.Windows.Forms.MessageBox.Show(
                        "Dữ liệu đã tồn tại (trùng khóa UNIQUE)!");
                    break;

                case 547:
                    System.Windows.Forms.MessageBox.Show(
                        "Dữ liệu không hợp lệ (vi phạm khóa ngoại)!");
                    break;

                case 515:
                    System.Windows.Forms.MessageBox.Show(
                        "Thiếu dữ liệu bắt buộc!");
                    break;

                default:
                    System.Windows.Forms.MessageBox.Show(
                        "Lỗi database: " + ex.Message);
                    break;
            }
        }
    }
}