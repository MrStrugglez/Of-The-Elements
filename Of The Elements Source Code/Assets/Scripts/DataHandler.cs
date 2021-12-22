using System;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

static class DataHandler
{
    static string conString = "Data Source=.;Initial Catalog=ElementStoriesDB;Integrated Security=True";
    //"Provider=SQLNCLI10;Data Source=NICKYPC\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=ElementStoriesDB";
    static SqlConnection con = new SqlConnection(conString);

    static public bool CheckStudentLogin(string username, string password)
    {
        int value = 0;
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("CheckStudentLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                value = reader.GetInt32(0);
            }
            else
            {
                return false;
            }
        }
        catch (SqlException)
        {
            return false;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
        finally
        {
            con.Close();
        }

        if (value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static public DataTable GetUserInfo(string username)
    {
        DataTable tbl = new DataTable();
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("GetUserInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@username", username);

                tbl.Load(cmd.ExecuteReader());
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }

        return tbl;
    }

    static public int GetCoinBalance(int userId)
    {
        int coins = 0;
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("GetCoinBalance", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                coins = reader.GetInt32(0);
            }
            else
            {
                Debug.Log("NOT Connected");
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }

        return coins;
    }

    static public void AddCoins(int userId, int coins)
    {
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("AddCoins", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@coins", coins);

                cmd.ExecuteNonQuery();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }
    }

    static public void UpdateLevelProgress(int level, int section, int userId)
    {
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("UpdateLevelProgress", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@level", level);
                cmd.Parameters.AddWithValue("@section", section);

                cmd.ExecuteNonQuery();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }
    }

    static public DataTable GetAllItems()
    {
        DataTable tbl = new DataTable();
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("GetItems", con);
                cmd.CommandType = CommandType.StoredProcedure;

                tbl.Load(cmd.ExecuteReader());
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }

        return tbl;
    }

    static public DataTable GetStudentItems(int userId)
    {
        DataTable tbl = new DataTable();
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("GetStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);

                tbl.Load(cmd.ExecuteReader());
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }

        return tbl;
    }

    static public bool EncouterSucceeded(int userId, int encounterId)
    {
        int value = 0;
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("EncounterSucceeded", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@encounterId", encounterId);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                value = reader.GetInt32(0);
            }
            else
            {
                return false;
            }
        }
        catch (SqlException)
        {
            return false;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
        finally
        {
            con.Close();
        }

        if (value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void BuyItem(int userId, int itemId)
    {
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("BuyItem", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@itemId", itemId);

                cmd.ExecuteNonQuery();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }
    }

    public static void CreateEncounterProgress(int userId, int encounterId)
    {
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("AddEncounterProgress", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@encounterId", encounterId);

                cmd.ExecuteNonQuery();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }
    }

    public static void AttemptEncounter(int userId, int encounterId)
    {
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("AttemptEncounter", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@encounterId", encounterId);

                cmd.ExecuteNonQuery();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }
    }

    public static void SucceedEncounter(int userId, int encounterId)
    {
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SucceedEncounter", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@encounterId", encounterId);

                cmd.ExecuteNonQuery();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }
    }

    public static void AttemptMagic(int userId, string magicName)
    {
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("AttemptEncounter", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@magicName", magicName);

                cmd.ExecuteNonQuery();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }
    }

    public static void SucceedMagic(int userId, string magicName)
    {
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("SucceedEncounter", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@magicName", magicName);

                cmd.ExecuteNonQuery();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }
    }

    static public DataTable GetEncounterQuestions(int encounterId)
    {
        DataTable tbl = new DataTable();
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("GetEncounterQuestions", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@encounterId", encounterId);

                tbl.Load(cmd.ExecuteReader());
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }

        return tbl;
    }

    static public DataTable GetRandomMagicQuestion(string magicName)
    {
        DataTable tbl = new DataTable();
        try
        {
            con.Open();

            if (con.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand("GetRandomMagicQuestion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@magicName", magicName);

                tbl.Load(cmd.ExecuteReader());
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        catch (SqlException)
        {

        }
        catch (InvalidOperationException)
        {

        }
        finally
        {
            con.Close();
        }

        return tbl;
    }
}
