using Microsoft.Data.SqlClient;

// needs a live SQL Server instance, not available here
static class Task30_CrudViaAdoNet
{
    const string ConnectionString = "Server=localhost;Database=EmployeeDb;Trusted_Connection=True;TrustServerCertificate=True;";

    static void CreateEmployee(string firstName, string lastName)
    {
        using SqlConnection conn = new(ConnectionString);
        conn.Open();
        using SqlCommand cmd = new("INSERT INTO Employees (FirstName, LastName) VALUES (@FirstName, @LastName)", conn);
        cmd.Parameters.AddWithValue("@FirstName", firstName);
        cmd.Parameters.AddWithValue("@LastName", lastName);
        cmd.ExecuteNonQuery();
    }

    static void ReadEmployees()
    {
        using SqlConnection conn = new(ConnectionString);
        conn.Open();
        using SqlCommand cmd = new("SELECT EmployeeID, FirstName, LastName FROM Employees", conn);
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
            Console.WriteLine($"{reader["EmployeeID"]}: {reader["FirstName"]} {reader["LastName"]}");
    }

    static void UpdateEmployee(int employeeId, string newLastName)
    {
        using SqlConnection conn = new(ConnectionString);
        conn.Open();
        using SqlCommand cmd = new("UPDATE Employees SET LastName = @LastName WHERE EmployeeID = @Id", conn);
        cmd.Parameters.AddWithValue("@LastName", newLastName);
        cmd.Parameters.AddWithValue("@Id", employeeId);
        cmd.ExecuteNonQuery();
    }

    static void DeleteEmployee(int employeeId)
    {
        using SqlConnection conn = new(ConnectionString);
        conn.Open();
        using SqlCommand cmd = new("DELETE FROM Employees WHERE EmployeeID = @Id", conn);
        cmd.Parameters.AddWithValue("@Id", employeeId);
        cmd.ExecuteNonQuery();
    }

    public static void Run()
    {
        Console.WriteLine("ADO.NET CRUD demo - requires a live SQL Server instance to actually run.");
        Console.WriteLine("CreateEmployee, ReadEmployees, UpdateEmployee, DeleteEmployee are defined above.");
        // CreateEmployee("Jack", "Ryan");
        // ReadEmployees();
        // UpdateEmployee(1, "Smith");
        // DeleteEmployee(1);
    }
}
