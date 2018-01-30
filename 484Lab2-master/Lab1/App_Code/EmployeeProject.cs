using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Class file for EmployeeProject bridge table
/// </summary>
public class EmployeeProject
{
    private int employeeID;
    private int projectID;
    private DateTime startDate;
    private DateTime endDate;
    private string lastUpdatedBy;
    private DateTime lastUpdated;
    private static int employeeProjectCount = 0;

    public EmployeeProject(int employeeID, int projectID, DateTime startDate, DateTime endDate, string lastUpdatedBy, DateTime lastUpdated)
    {
        EmployeeID = employeeID;
        ProjectID = projectID;
        StartDate = startDate;
        EndDate = endDate;
        LastUpdatedBy = lastUpdatedBy;
        LastUpdated = lastUpdated;
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
    public int ProjectID
    {
        get
        {
            return projectID;
        }
        private set
        {
            projectID = value;
        }
    }
    public DateTime StartDate
    {
        get
        {
            return startDate;
        }
        private set
        {
            startDate = value;
        }
    }
    public DateTime EndDate
    {
        get
        {
            return endDate;
        }
        private set
        {
            endDate = value;
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