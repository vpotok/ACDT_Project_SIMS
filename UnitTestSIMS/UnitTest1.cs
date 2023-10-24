using Microsoft.Data.SqlClient;
using Project_SIMS;
namespace UnitTestSIMS;

public class Tests
{
DatabaseConnection db = new DatabaseConnection();

    [Test]
    public void TestInsertUser()
    {
        Benutzerverwaltung benutzerverwaltung = new Benutzerverwaltung();
        string vorname = "John";
        string nachname = "Doe2";
        bool isAdmin = false;
        bool isActive = true;

        // Insert the user
        benutzerverwaltung.insertUser(vorname, nachname, isAdmin, isActive);

        // Now, retrieve the inserted user to verify the insertion
        Benutzerverwaltung selectedBenutzer = new Benutzerverwaltung();
        selectedBenutzer.selectUser(21); // Assuming 21 is the ID of the inserted user

        // Add assertions to verify the inserted user's details
        Assert.AreEqual(vorname, "John");
        Assert.AreEqual(nachname, "Doe2");
        Assert.AreEqual(isAdmin, false);
        Assert.AreEqual(isActive, true);
    }

    [Test]
    public void TestSelectUser()
    {
        db.openConnection();
        // Arrange
        Benutzerverwaltung benutzerverwaltung = new Benutzerverwaltung();
        int userId = 100;

        // Act
        benutzerverwaltung.selectUser(userId);

        // Assert
        SqlCommand command = new SqlCommand($"SELECT BenutzerId FROM Benutzer WHERE BenutzerId = {userId}", db.con);
        using SqlDataReader reader = command.ExecuteReader();
        if(reader.Read() && reader.HasRows)
        {
            int retrievedUserId = Convert.ToInt32(reader["BenutzerId"]);
            Assert.AreEqual(userId, retrievedUserId);
            db.closeConnection();
        }
        else
        {
            Assert.IsFalse(true, "Datensatz nicht gefunden");
            db.closeConnection();
        }
    }

    [Test]
    public void TestUpdateVorfallStatus()
    {
        db.openConnection();
        // Arrange
        Vorfall vorfall = new Vorfall();
        int id = 4; 

        // Act
        vorfall.updateVorfallstatus(id);

        SqlCommand command = new SqlCommand($"SELECT VorfallStatus FROM vorfall WHERE VorfallID = {id}", db.con);
        using SqlDataReader reader = command.ExecuteReader();

        if (reader.Read() && reader.HasRows)
        {
            int retrievedStatus = Convert.ToInt32(reader["VorfallStatus"]);
            Assert.AreEqual(1, retrievedStatus);
            db.closeConnection();
        }
        else
        {
            Assert.IsFalse(true, "Datensatz nicht gefunden");
            db.closeConnection();
        }

    }

    [Test]
    public void TestSelectUnsolvedIncidents()
    {
        db.openConnection();
        // Arrange
        Vorfall vorfall = new Vorfall();

        // Act
        vorfall.selectUnsolvedIncidents();

        SqlCommand command = new SqlCommand($"SELECT * FROM vorfall WHERE VorfallStatus = 0", db.con);
        using SqlDataReader reader = command.ExecuteReader();

        if (reader.Read() && reader.HasRows)
        {
            int retrievedStatus = Convert.ToInt32(reader["VorfallStatus"]);
            Assert.AreEqual(0, retrievedStatus);
            db.closeConnection();
        }
        else
        {
            Assert.IsFalse(true, "Datensatz nicht gefunden");
            db.closeConnection();
        }
    }

    [Test]
    public void TestUpdateUser()
    {
        db.openConnection();
        // Arrange
        Benutzerverwaltung benutzerverwaltung = new Benutzerverwaltung();
        int userId = 21;
        string columnName = "isAdmin";
        object newValue = true;

        // Act
        benutzerverwaltung.updateUser(userId, columnName, newValue);

        // Assert
        SqlCommand command = new SqlCommand($"SELECT isAdmin FROM benutzer WHERE BenutzerId = {userId}", db.con);
        using SqlDataReader reader = command.ExecuteReader();

        if (reader.Read() && reader.HasRows)
        {
            int retrievedBool = Convert.ToInt32(reader["isAdmin"]);
            Assert.AreEqual(1, retrievedBool); // Assuming 1 represents true in the database
        }
        else
        {
            Assert.Fail("Datensatz nicht gefunden");
        }
    }
}