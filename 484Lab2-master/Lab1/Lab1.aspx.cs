using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;


//John Morrissey Lab 1

public partial class ApplicationDriver : System.Web.UI.Page
{
    public static Employee[] employeeArray = new Employee[3];
    public static int count = 0;
    public static string[,] returnArray = new string[100, 2];
    
    


    protected void Page_Load(object sender, EventArgs e)
    {
        //On page load gets the information from the DB
        selectFromDB();
        
        


    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        alertMessage.Text = "";
        Boolean passBoolean = true;

        try
        {
            //Validates that the users entries can be converted
            if (checkEntries() == false)
            {
                passBoolean = false;
                alertMessage.Text += " Please ensure all entries are valid.";
            }
            //Validates the hire date and termination date
            if (txtTerminationDate.Value != "")
            { 
                if (checkDate(DateTime.Parse(txtHireDate.Value), DateTime.Parse(txtTerminationDate.Value)) == false)
                {
                    alertMessage.Text += " Ensure the hire date if before the termination date";
                    passBoolean = false;
                    txtHireDate.Focus();
                }
            }   
            else if(txtTerminationDate.Value == "")
            {
                passBoolean = true;
            }
            //Validates if the user already exists
            if (checkName(txtFirstName.Value, txtLastName.Value) == true)
            {
                alertMessage.Text += " This user already exists";
                passBoolean = false;
                txtFirstName.Focus();
            }
            
            //Validates that the users are 18 years of age when hired
            if (checkAge(DateTime.Parse(txtDOB.Value)) == false)
            {
                alertMessage.Text += " All employees must be atleast 18 years old when they are hired.";
                passBoolean = false;
                txtDOB.Focus();
            }
            
            
            //Validates that the user entered a valid state
            if (checkState(txtState.Value) == false)
            {
                passBoolean = false;
                alertMessage.Text += " Please enter a valid state abbreviation. ";
            }
            //Validates if the ID already exists
            if (checkID(int.Parse(txtEmployeeID.Value)) == true)
            {
                alertMessage.Text += " This ID already exists";
                passBoolean = false;
                txtEmployeeID.Focus();
            }
            //Validates that the Manager ID's exist when the user inputs them
            if (txtManagerID.Value != "")
            {
                if (checkManagerID(int.Parse(txtManagerID.Value)) == true)
                {
                    alertMessage.Text += " Please enter a valid Manager ID.";
                    passBoolean = false;
                    txtManagerID.Focus();
                }
            }
            //Validates number entries to positive numbers
            if (int.Parse(txtEmployeeID.Value) < 0 || double.Parse(txtSalary.Value) < 0)
            {
                alertMessage.Text += " Please enter positive numbers only";
                passBoolean = false;
                
            }

            if (passBoolean == true)
            {
                //Check that the name doesnt exist in the DB already
                string middleInitial = "";
                string state = "";
                DateTime terminationDate = DateTime.MinValue;
                int managerID = 0;

                //if the text fields are empty then set the values to NULL
                if (txtMI.Value == "")
                {
                    middleInitial = "NULL";
                }
                else
                {
                    middleInitial = txtMI.Value;
                }
                if (txtState.Value == "")
                {
                    state = "NULL";
                }
                else
                {
                    state = txtState.Value;
                }
                if (txtTerminationDate.Value == "")
                {
                    terminationDate = DateTime.MinValue;
                }
                else
                {
                    terminationDate = DateTime.Parse(txtTerminationDate.Value);
                }
                if (txtManagerID.Value == "")
                {
                    managerID = -1;
                }
                else
                {
                    managerID = int.Parse(txtManagerID.Value);
                }
                
                
                
                //Create the new entry in the array
                employeeArray[count++] = new Employee(int.Parse(txtEmployeeID.Value), txtFirstName.Value, txtLastName.Value, middleInitial, txtHouseNum.Value, txtStreet.Value, txtCounty.Value, state, txtCountry.Value, txtZip.Value,
                    DateTime.Parse(txtDOB.Value), DateTime.Parse(txtHireDate.Value), terminationDate, Double.Parse(txtSalary.Value), managerID,
                    "John Morrissey", DateTime.Now);
                alertMessage.Text += "User Created: " + employeeArray[count - 1].FirstName + " " + employeeArray[count - 1].LastName;
                if (count >= 3)
                {
                    btnInsert.Enabled = false;
                    alertMessage.Text += " You cannot enter more employees";
                }
                
                
            }
            
        }
        catch (Exception c)
        {
            resultMessage.Text += c;
        }
        
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        //Calls the clear fields method
        clearFields();

    }

    protected void btnCommit_Click(object sender, EventArgs e)
    {

        //First delete the previous data from the database
        //Then commit the employee array to the database
        try
        {
            deleteFromDB();

            for (int i = 0; i < count; i++)
            {
                insertIntoDB(employeeArray[i]);
                alertMessage.Text = "";
                resultMessage.Text += "Committed";
            }
            for (int a = 0; a < count; a++)
            {
                Array.Clear(employeeArray, 0, employeeArray.Length);
            }
            btnInsert.Enabled = true;
            count = 0;
            alertMessage.Text = "The employee information has been entered into the Database";
            
        }
        catch (Exception c)
        {
            alertMessage.Text = "Please ensure that all information input was correct.";
            for (int a = 0; a < count; a++)
            {
                Array.Clear(employeeArray, 0, employeeArray.Length);
            }
        }
        
        
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        //Exits the program
        Environment.Exit(0);
    }

    private void deleteFromDB()
    {
        //When the program runs initially it should delete all the info in the tables
        try
        {

            //Creates a new sql connection and links the application to the lab 1 database
            System.Data.SqlClient.SqlConnection sqlc = connectToDB();

            //Deletes all of the information in the Database table Employee
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sqlc;
            insert.CommandText = "delete from [dbo].[EMPLOYEE]";
            insert.ExecuteNonQuery();

            sqlc.Close();

        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 0";
            resultMessage.Text += c.Message;
            
        }
    }


    private System.Data.SqlClient.SqlConnection connectToDB()
    {
        try
        {
            //Connects to the database and returns the connection
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost; Database=Lab2;Trusted_Connection=Yes";
            sc.Open();
            return sc;
        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 1";
            resultMessage.Text += c.Message;
            return null;
        }
        
    }

    private void insertIntoDB(Employee a)
    {

        //When the program runs initially it should delete all the info in the tables
        try
        {

            System.Data.SqlClient.SqlConnection sqlc = connectToDB();

            //Creates a new sql insert command to insert the data from the arrays into the Employee table
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sqlc;
            /* Create the insert statement 
             * if the user doesn't input data for the non-required fields
             * then NULL values are input into the database */
            insert.CommandText += "insert into [dbo].[EMPLOYEE] values (" + a.EmployeeID + ", '" + a.FirstName + "','" + a.LastName;
            if (a.MiddleName == "NULL")
            {
                insert.CommandText += "',NULL,'";
            }
            else
            {
                insert.CommandText += "','" + a.MiddleName + "','";
            }
            
            insert.CommandText += a.HouseNum + "','" + a.Street + "','" + a.County;
            if (a.State == "NULL")
            {
                insert.CommandText += "',NULL,'";
            }
            else
            {
                insert.CommandText += "','" + a.State + "','";
            }
            
            insert.CommandText += a.Country + "','" + a.Zip + "','" + a.DateOfBirth + "','" + a.HireDate;
            if (a.TerminationDate == DateTime.MinValue)
            {
                insert.CommandText += "',NULL,";
            }
            else
            {
                insert.CommandText += "','" + a.TerminationDate + "',";
            }
            
            insert.CommandText += a.Salary;

            if (a.ManagerID == -1)
            {
                insert.CommandText += ",NULL,'";
            }
            else
            {
                insert.CommandText += "," + a.ManagerID + ",'";
            }
            insert.CommandText += a.LastUpdatedBy + "','" + a.LastUpdated + "')";

            
            insert.ExecuteNonQuery();

            sqlc.Close();

        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 2";
            resultMessage.Text += c.Message;
        }


    }

    private void selectFromDB()
    {
        try
        {
            //Connect to the DB
            System.Data.SqlClient.SqlConnection sqlc = connectToDB();

            //Creates a new sql select command to select the data from the skills table
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.Connection = sqlc;
            select.CommandText = "select SKILLNAME from [dbo].[SKILL]";
            System.Data.SqlClient.SqlDataReader reader;

            reader = select.ExecuteReader();
            
            
            while (reader.Read())
            {                
                dropDownSkills.Items.Add(reader.GetString(0));
                
            }
            sqlc.Close();
        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 3";
            resultMessage.Text += c.Message;
        }
    }

    protected Boolean checkName(string firstName, string lastName)
    {
        if (count == 0)
        {
            return false;
        }

            //this checks whether the name already exists in the array
            string arrayName = "";
            string txtBoxName = "";
            txtBoxName = firstName.ToUpper() + lastName.ToUpper();
            Boolean result;

            for (int i = 0; i < count; i++)
            {
                arrayName = employeeArray[i].FirstName.ToUpper() + employeeArray[i].LastName.ToUpper();
                if (arrayName == txtBoxName)
                {
                    result = true;
                    return result;
                }

            }

            return false;
        
        
    }

    private Boolean checkID(int id)
    {
        //This checks whether the ID number exists in the array
        for (int i = 0; i < count; i++)
        {
            if(id == employeeArray[i].EmployeeID)
            {
                return true;
            }
        }
        return false;
    }

    private void clearFields()
    {
        //Clear the text fields
        txtFirstName.Value = "";
        txtLastName.Value = "";
        txtMI.Value = "";
        txtDOB.Value = "";
        txtHouseNum.Value = "";
        txtStreet.Value = "";
        txtState.Value = "";
        txtCounty.Value = "";
        txtCountry.Value = "";
        txtZip.Value = "";
        txtHireDate.Value = "";
        txtTerminationDate.Value = "";
        txtSalary.Value = "";
        txtManagerID.Value = "";
        txtEmployeeID.Value = "";

        txtFirstName.Focus();
    }

    private Boolean checkDate(DateTime firstDate, DateTime secondDate)
    {
        int i = secondDate.CompareTo(firstDate);
        //Is the second date past the first date
        if (i < 0)
        {
            return false;
        }
        else if (i == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private Boolean checkAge(DateTime dateOfBirth)
    {
        if ((dateOfBirth.AddYears(18) <= DateTime.Now))
        {
            if (dateOfBirth.AddYears(18) <= DateTime.Parse(txtHireDate.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        else 
        {
            return false;
        }
    }

    

    

    private Boolean checkManagerID(int managerID)
    {
        if (count != 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (managerID != employeeArray[i].EmployeeID)
                {
                    continue;
                }
                else
                {
                    return false;
                }

            }
        }
        else if (count == 0)
        {
            if (int.Parse(txtEmployeeID.Value) == int.Parse(txtManagerID.Value))
            {
                return false;
            }
            else if(txtManagerID.Value == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        return true;

        
    }

    private Boolean checkEntries()
    {
        try
        {
            DateTime.Parse(txtDOB.Value);
            DateTime.Parse(txtHireDate.Value);
            if (txtTerminationDate.Value != "")
            {
                DateTime.Parse(txtTerminationDate.Value);
            }
            
            Double.Parse(txtSalary.Value);
            if (txtManagerID.Value != "")
            {
                Int32.Parse(txtManagerID.Value);
            }
            Int32.Parse(txtEmployeeID.Value);
            
        }
        catch (Exception)
        {
            
            return false;
        }
        return true;

        
    }

    private Boolean checkState(string stateAbb)
    {
        string[] stateArray = new string[] {"AL","AK","AZ","AR","CA","CO","CT","DE","FL","GA",
            "HI","ID","IL","IN","IA","KS","KY","LA","ME","MD","MA","MI","MN","MS","MO","MT","NE",
            "NV","NH","NJ","NM","NY","NC","ND","OH","OK","OR","PA","RI","SC","SD","TN","TX","UT",
            "VT","VA","WA","WV","WI","WY"};

        for (int i = 0; i < stateArray.Length; i++)
        {
            if(stateAbb.ToUpper() == stateArray[i])
            {
                return true;
            }
            
        }

        return false;
    }
    

    private void validationSelect(string a, string table)
    {
        Array.Clear(returnArray, 0, returnArray.Length);
        int i = 0;
        try
        {
            //Connect to the DB
            System.Data.SqlClient.SqlConnection sqlc = connectToDB();

            //Creates a new sql select command to select the data from the skills table
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.Connection = sqlc;
            select.CommandText = "select " + a.ToUpper() + " from [dbo].[" + table + "]";
            System.Data.SqlClient.SqlDataReader reader;

            reader = select.ExecuteReader();

            
            while (reader.Read())
            {
                returnArray[i,0] = reader.GetString(0);
                i++;
            }
            sqlc.Close();
        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 3";
            resultMessage.Text += c.Message;
        }
        
    }
    
    private void validationSelect(string a, string b, string table)
    {
        Array.Clear(returnArray, 0, returnArray.Length);
        int i = 0;
        try
        {
            //Connect to the DB
            System.Data.SqlClient.SqlConnection sqlc = connectToDB();

            //Creates a new sql select command to select the data from the skills table
            System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand();
            select.Connection = sqlc;
            select.CommandText = "select " + a.ToUpper + "," + b.ToUpper + " from [dbo].[" + table.ToUpper + "]";
            System.Data.SqlClient.SqlDataReader reader;

            reader = select.ExecuteReader();


            while (reader.Read())
            {
                returnArray[i,0] = reader.GetString(0);
                returnArray[i,1] = reader.GetString(1);
                i++;
            }
            sqlc.Close();
        }
        catch (Exception c)
        {
            //Shows an error message if there is a problem connecting to the database
            resultMessage.Text += "Database Error 3";
            resultMessage.Text += c.Message;
        }
    }
    


}