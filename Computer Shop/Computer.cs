using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Computer
{
	// Token: 0x02000004 RID: 4
	public class Computer
	{
        // Token: 0x0600000B RID: 11 RVA: 0x000020C8 File Offset: 0x000002C8
        private static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=KHEMARINT\\SQLEXPRESS;Initial Catalog=CSMS;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Successfully connected to the database.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while connecting to the database: " + ex.Message);
            }
            return connection;
        }


        // Token: 0x0600000C RID: 12 RVA: 0x0000211C File Offset: 0x0000031C
        public static bool IsValidNamePass(string name, string password)
		{
			try
			{
				string cmdText = string.Concat(new string[]
				{
					"SELECT Users_Name, Users_Password FROM Users WHERE Users_Name = '",
					name,
					"' AND Users_Password = '",
					password,
					"';"
				});
				SqlConnection connection = Computer.GetConnection();
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				connection.Close();
				bool flag = dataTable.Rows.Count > 0;
				if (flag)
				{
					return true;
				}
			}
			catch (SqlException)
			{
				MessageBox.Show("Username and password error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			return false;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021D0 File Offset: 0x000003D0
		public static string ForgotPassword(string name, string email)
		{
			string result = "";
			string cmdText = "SELECT Users_Password FROM Users WHERE Users_Name = @Name AND Users_Email = @Email;";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
			sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			bool flag = sqlDataReader.Read();
			if (flag)
			{
				result = sqlDataReader["Users_Password"].ToString();
			}
			connection.Close();
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000226C File Offset: 0x0000046C
		public static string Rate(string name)
		{
			string result = "";
			string cmdText = "SELECT Product_Rate FROM Product WHERE Product_Name = @Name;";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			bool flag = sqlDataReader.Read();
			if (flag)
			{
				result = sqlDataReader["Product_Rate"].ToString();
			}
			connection.Close();
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022EC File Offset: 0x000004EC
		public static void AddBrand(Brand brand)
		{
			string cmdText = "INSERT INTO Brand VALUES (@Name, @Status);";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = brand.Name;
			sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = brand.Status;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException ex)
			{
				bool flag = ex.Number == 2627;
				if (flag)
				{
					MessageBox.Show("Brand already add.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Brand not added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			connection.Close();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000023C8 File Offset: 0x000005C8
		public static void DisplayAndSearch(string query, DataGridView dgv)
		{
			SqlConnection connection = Computer.GetConnection();
			SqlCommand selectCommand = new SqlCommand(query, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			dgv.DataSource = dataTable;
			connection.Close();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002410 File Offset: 0x00000610
		public static void ChangeBrand(Brand brand, string id)
		{
			string cmdText = "UPDATE Brand SET Brand_Name = @Name, Brand_Status = @Status WHERE Brand_Id = @Id;";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = brand.Name;
			sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = brand.Status;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Changed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException)
			{
				MessageBox.Show("Brand not change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			connection.Close();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000024DC File Offset: 0x000006DC
		public static void RemoveBrand(string Id)
		{
			string cmdText = "DELETE FROM Brand WHERE Brand_Id = @Id";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Removed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException)
			{
				MessageBox.Show("Brand not delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			connection.Close();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000256C File Offset: 0x0000076C
		public static void AddCategory(Category category)
		{
			string cmdText = "INSERT INTO Category VALUES (@Name, @Status);";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = category.Name;
			sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = category.Status;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Category already add.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Category not added. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            connection.Close();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002648 File Offset: 0x00000848
		public static void ChangeCategory(Category category, string id)
		{
			string cmdText = "UPDATE Category SET Category_Name = @Name, Category_Status = @Status WHERE Category_Id = @Id;";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = category.Name;
			sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = category.Status;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Changed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException)
			{
				MessageBox.Show("Category not change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			connection.Close();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002714 File Offset: 0x00000914
		public static void RemoveCategory(string Id)
		{
			string cmdText = "DELETE FROM Category WHERE Category_Id = @Id";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Removed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException)
			{
				MessageBox.Show("Category not delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			connection.Close();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000027A4 File Offset: 0x000009A4
		public static void AddProduct(Product product)
		{
			string cmdText = "INSERT INTO Product VALUES (@Name, @Image, @Rate, @Quantity, @Brand, @Category, @Status);";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
			sqlCommand.Parameters.Add("@Image", SqlDbType.Image).Value = product.Image;
			sqlCommand.Parameters.Add("@Rate", SqlDbType.Int).Value = product.Rate;
			sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.Quantity;
			sqlCommand.Parameters.Add("@Brand", SqlDbType.VarChar).Value = product.Brand;
			sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = product.Category;
			sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = product.Status;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException ex)
			{
				bool flag = ex.Number == 2627;
				if (flag)
				{
					MessageBox.Show("Product already add.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Product not added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			connection.Close();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000291C File Offset: 0x00000B1C
		public static void ChangeProduct(Product product, string id)
		{
			string cmdText = "UPDATE Product SET Product_Name = @Name, Product_Image = @Image, Product_Rate = @Rate, Product_Quantity = @Quantity, Product_Brand = @Brand, Product_Category = @Category, Product_Status = @Status WHERE Product_Id = @Id;";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
			sqlCommand.Parameters.Add("@Image", SqlDbType.Image).Value = product.Image;
			sqlCommand.Parameters.Add("@Rate", SqlDbType.Int).Value = product.Rate;
			sqlCommand.Parameters.Add("@Quantity", SqlDbType.Int).Value = product.Quantity;
			sqlCommand.Parameters.Add("@Brand", SqlDbType.VarChar).Value = product.Brand;
			sqlCommand.Parameters.Add("@Category", SqlDbType.VarChar).Value = product.Category;
			sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = product.Status;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Changed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException arg)
			{
				MessageBox.Show(string.Format("Product not change.\n{0}", arg), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			connection.Close();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002A8C File Offset: 0x00000C8C
		public static void RemoveProduct(string Id)
		{
			string cmdText = "DELETE FROM Product WHERE Product_Id = @Id";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Removed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException)
			{
				MessageBox.Show("Product not delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			connection.Close();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002B1C File Offset: 0x00000D1C
		public static void BrandCategoryProduct(string query, ComboBox cb)
		{
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(query, connection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				cb.Items.Add(sqlDataReader[0]);
			}
			connection.Close();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002B68 File Offset: 0x00000D68
		public static void AddUser(User user)
		{
			string cmdText = "INSERT INTO Users VALUES (@Name, @Email, @Password);";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = user.Name;
			sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
			sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException ex)
			{
				bool flag = ex.Number == 2627;
				if (flag)
				{
					MessageBox.Show("User already add.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("User not added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			connection.Close();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002C64 File Offset: 0x00000E64
		public static void ChangeUser(User user, string id)
		{
			string cmdText = "UPDATE Users SET Users_Name = @Name, Users_Email = @Email, Users_Password = @Password WHERE Users_Id = @Id;";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = user.Name;
			sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
			sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Changed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException)
			{
				MessageBox.Show("User not change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			connection.Close();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002D50 File Offset: 0x00000F50
		public static void RemoveUser(string Id)
		{
			string cmdText = "DELETE FROM Users WHERE Users_Id = @Id";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Removed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException)
			{
				MessageBox.Show("User not delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			connection.Close();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002DE0 File Offset: 0x00000FE0
		public static void SaveOrder(Order order)
		{
			string cmdText = "INSERT INTO Orders VALUES (@Date, @Name, @Number, @TotalAmount, @PaidAmount, @DueAmount, @Discount, @GrandTotal, @Status);";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Date", SqlDbType.VarChar).Value = order.Date;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = order.Name;
			sqlCommand.Parameters.Add("@Number", SqlDbType.VarChar).Value = order.Number;
			sqlCommand.Parameters.Add("@TotalAmount", SqlDbType.Int).Value = order.TotalAmount;
			sqlCommand.Parameters.Add("@PaidAmount", SqlDbType.Int).Value = order.PaidAmount;
			sqlCommand.Parameters.Add("@DueAmount", SqlDbType.Int).Value = order.DueAmount;
			sqlCommand.Parameters.Add("@Discount", SqlDbType.Int).Value = order.Discount;
			sqlCommand.Parameters.Add("@GrandTotal", SqlDbType.Int).Value = order.GrandTotal;
			sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = order.Status;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException ex)
			{
				bool flag = ex.Number == 2627;
				if (flag)
				{
					MessageBox.Show("Order already add.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Order not added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			connection.Close();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002FA8 File Offset: 0x000011A8
		public static void ChangeOrder(Order order, string id)
		{
			string cmdText = "UPDATE Orders SET Orders_Date = @Date, Customer_Name = @Name, Customer_Number = @Number, Total_Amount = @TotalAmount, Paid_Amount = @PaidAmount, Due_Amount = @DueAmount, Discount = @Discount, Payment_Status = @Status WHERE Orders_Id = @Id;";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@Date", SqlDbType.VarChar).Value = order.Date;
			sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = order.Name;
			sqlCommand.Parameters.Add("@Number", SqlDbType.VarChar).Value = order.Number;
			sqlCommand.Parameters.Add("@TotalAmount", SqlDbType.Int).Value = order.TotalAmount;
			sqlCommand.Parameters.Add("@PaidAmount", SqlDbType.Int).Value = order.PaidAmount;
			sqlCommand.Parameters.Add("@DueAmount", SqlDbType.Int).Value = order.DueAmount;
			sqlCommand.Parameters.Add("@Discount", SqlDbType.Int).Value = order.Discount;
			sqlCommand.Parameters.Add("@GrandTotal", SqlDbType.Int).Value = order.GrandTotal;
			sqlCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = order.Status;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Change successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException ex)
			{
				bool flag = ex.Number == 2627;
				if (flag)
				{
					MessageBox.Show("Order already add.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Order not changed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			connection.Close();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003188 File Offset: 0x00001388
		public static void RemoveOrder(string Id)
		{
			string cmdText = "DELETE FROM Orders WHERE Orders_Id = @Id";
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
			sqlCommand.CommandType = CommandType.Text;
			sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
			try
			{
				sqlCommand.ExecuteNonQuery();
				MessageBox.Show("Removed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (SqlException)
			{
				MessageBox.Show("Order not delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			connection.Close();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003218 File Offset: 0x00001418
		public static int Count(string query)
		{
			int result = 0;
			SqlConnection connection = Computer.GetConnection();
			SqlCommand sqlCommand = new SqlCommand(query, connection);
			try
			{
				result = (int)sqlCommand.ExecuteScalar();
				return result;
			}
			catch (Exception)
			{
			}
			connection.Close();
			return result;
		}
	}
}
