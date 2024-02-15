using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Computer
{
	
	public class Computer
	{
        
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



        public static DataRow IsValidNamePass(string name, string password)
        {
            try
            {
                string cmdText = "SELECT Users_Name, Users_Password, Users_Email, Users_Gender, IsAdmin, User_Image FROM Users WHERE Users_Name = @name AND Users_Password = @password;"; // Add ', User_Image' here
                using (SqlConnection connection = Computer.GetConnection())
                {
                    using (SqlCommand selectCommand = new SqlCommand(cmdText, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@name", name);
                        selectCommand.Parameters.AddWithValue("@password", password);

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            return dataTable.Rows[0];
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Username and password error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }




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



      
        public static void AddUser(User user)
        {
            string cmdText = "INSERT INTO Users (Users_Name, Users_Email, Users_Password, Users_Address, Users_DateOfBirth, Users_Gender, Users_PhoneNumber, IsAdmin, User_Image) VALUES (@Name, @Email, @Password, @Address, @DateOfBirth, @Gender, @PhoneNumber, @IsAdmin, @Image);";
            SqlConnection connection = Computer.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = user.Name;
            sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
            sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
            sqlCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = user.Address;
            sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = user.DateOfBirth;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = user.Gender;
            sqlCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = user.PhoneNumber;
            sqlCommand.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = (object)user.IsAdmin ?? DBNull.Value;
            sqlCommand.Parameters.Add("@Image", SqlDbType.Image).Value = user.Image; // Add this line
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
                    MessageBox.Show("User already added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("User not added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            connection.Close();
        }




    
        public static void ChangeUser(User user, string id)
        {
            string cmdText = "UPDATE Users SET Users_Name = @Name, Users_Email = @Email, Users_Password = @Password, Users_Address = @Address, Users_DateOfBirth = @DateOfBirth, Users_Gender = @Gender, Users_PhoneNumber = @PhoneNumber, IsAdmin = @IsAdmin, User_Image = @Image WHERE Users_Id = @Id;";
            SqlConnection connection = Computer.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = user.Name;
            sqlCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
            sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
            sqlCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = user.Address;
            sqlCommand.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = user.DateOfBirth;
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = user.Gender;
            sqlCommand.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = user.PhoneNumber;
            sqlCommand.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = (object)user.IsAdmin ?? DBNull.Value;
            sqlCommand.Parameters.Add("@Image", SqlDbType.Image).Value = user.Image; // Add this line
            try
            {
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Changed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (SqlException)
            {
                MessageBox.Show("User not changed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            connection.Close();
        }




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
