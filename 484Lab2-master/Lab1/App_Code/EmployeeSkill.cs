using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Class file for 
/// </summary>
public class Class1
{
    private int employeeID;
    private int skillID;
    private string lastUpdatedBy;
    private DateTime lastUpdated;
    private static int employeeSkillCount = 0;

    public Class1(int employeeID, int skillID, string lastUpdatedBy, DateTime lastUpdated)
    {
        EmployeeID = employeeID;
        SkillID = skillID;
        LastUpdatedBy = lastUpdatedBy;
        LastUpdated = lastUpdated;

        employeeSkillCount++;
    }
    public int EmployeeID
    {
        get
        {
            return employeeID;
        }
        private set
        {
            employeeID = value;
        }
    }
    public int SkillID
    {
        get
        {
            return skillID;
        }
        private set
        {
            skillID = value;
        }
    }
    public string LastUpdatedBy
    {
        get
        {
            return lastUpdatedBy;
        }
        private set
        {
            lastUpdatedBy = value;
        }
    }
    public DateTime LastUpdated
    {
        get
        {
            return lastUpdated;
        }
        private set
        {
            lastUpdated = value;
        }
    }

}