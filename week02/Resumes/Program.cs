using System;
using System.Collections.Generic;


public class Job
{

    public string Company { get; set; }
    public string JobTitle { get; set; }
    public int StartYear { get; set; }
    public int EndYear { get; set; }

    
    public Job(string company, string jobTitle, int startYear, int endYear)
    {
        Company = company;
        JobTitle = jobTitle;
        StartYear = startYear;
        EndYear = endYear;
    }

    
    public string Display()
    {
        Console.WriteLine $"{JobTitle} ({Company}) {StartYear} {EndYear}";
    }
}



