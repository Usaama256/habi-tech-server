using HabiTech.Models;
using MySql.Data.MySqlClient;

namespace HabiTech.Database;

public class DBConnection{

	 private MySqlConnection Connection; 
	 private string  Server { get; }
	 
	 private int Port { get; }
	private string DatabaseName { get; }
	private string User { get; }
	private string Password { get; }
	
	public DBConnection() {
		Server = "habi-tech-do-user-15423564-0.c.db.ondigitalocean.com";
		Port = 25060;
		User = "doadmin";
		DatabaseName = "habi-tech_db";
		Password = "AVNS_AvDi5SOe7sSt5YW4tfi";

		string ConnStr = string.Format("SERVER={0}; Port={1}; DATABASE={2}; UID={3}; PASSWORD={4}", Server, Port, DatabaseName, User, Password);
		
		Connection = new MySqlConnection(ConnStr);
	}

	private bool OpenConnection(){
		try
		{
				Connection.Open();
				// Console.WriteLine("Database Connection Successful");
				return true;
		}
		catch (MySqlException ex)
		{
				switch (ex.Number)
				{
						case 0:
								Console.WriteLine("Error: Cannot connect to server");
								break;

						case 1045:
								Console.WriteLine("Error: Invalid username/password");
								break;
						 default:
						 		break;
				}
				return false;
		}
	}
	
	private bool CloseConnection()
{
		try
		{
				Connection.Close();
				return true;
		}
		catch (MySqlException ex)
		{
				Console.WriteLine(ex.Message);
				return false;
		}
}
	
	public User DbDetUser(string email)
	{
			string query = string.Format("SELECT user_id, username, profile_picture, email, pass, salt FROM user WHERE email='{0}'", email);
			
			if(this.OpenConnection() != true)
			{
				return new User(-1, "", "", "", "", "");

			}	
			
			MySqlCommand cmd = new MySqlCommand(query, Connection);
			
			MySqlDataReader reader = cmd.ExecuteReader();
			
			if(!reader.Read())
			{
				return new User(-1, "", "", "", "", "");
			}
			
			int _id = (int)reader["user_id"];
			string? _name = reader["username"] as string;
			string? _email = reader["email"] as string;
			string? _pass = reader["pass"] as string;
			string? _profilePic = reader["profile_picture"] as string;
			string? _salt = reader["salt"] as string;
			
			User user = new User(_id, _name ?? "", _email ?? "", _profilePic ?? "", _pass ?? "", _salt ?? "");
			
			reader.Close();
			
			this.CloseConnection();
			
			return user;			
	}
	
	public List<Light> DbGetAllUserLights(int user_id)
	{
		List<Light> lights = new List<Light>();
		
		string query = string.Format("SELECT device_id, device_name, device_description, type_name, user_id, status FROM device JOIN device_type USING(type_id) WHERE user_id={0} and type_id=2", user_id);
		if(this.OpenConnection() != true)
			{
				return lights;

			}	
			
		MySqlCommand cmd = new MySqlCommand(query, Connection);
		
		MySqlDataReader reader = cmd.ExecuteReader();
		
		while(reader.Read())
		{
			Light light = new Light();
			light.Device_id = (int)reader["device_id"];
			light.Device_name = reader["device_name"] as string;
			light.Device_description = reader["device_description"] as string;
			light.Type_name = reader["type_name"] as string;
			light.User_id = (int)reader["user_id"];
			light.Status = reader["status"] as string;
			
			lights.Add(light);
			
		}
		
		reader.Close();
			
		this.CloseConnection();
					
		
		return lights;
	} 
	
	
	public List<Light> DbSwitchAllUserLights(int user_id, int action)
	{
		string actionStr = action == 1? "ON" : "OFF";
		string query = string.Format("UPDATE device SET status='{0}' WHERE type_id=2 and user_id={1}", actionStr, user_id);
		
		List<Light> lights = new List<Light>();
		
		if(this.OpenConnection() != true)
			{
				return lights;

			}	
			
		MySqlCommand cmd = new MySqlCommand(query, Connection);
		
		cmd.ExecuteNonQuery();
		
		this.CloseConnection();	
		
		return DbGetAllUserLights(user_id);
	} 
	
	public List<Light> DbSwitchSingleUserLight(int user_id, int action, int device_id)
	{
		string actionStr = action == 1? "ON" : "OFF";
		string query = string.Format("UPDATE device SET status='{0}' WHERE device_id={1} and type_id=2 and user_id={2}", actionStr, device_id, user_id);
		
		List<Light> lights = new List<Light>();
		
		if(this.OpenConnection() != true)
			{
				return lights;

			}	
			
		MySqlCommand cmd = new MySqlCommand(query, Connection);
		
		cmd.ExecuteNonQuery();
		
		this.CloseConnection();	
		
		return DbGetAllUserLights(user_id);
	} 
}