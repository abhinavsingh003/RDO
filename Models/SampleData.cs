/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                                   RDO CALL DATA LOGGER (RCDL)
*  			
*                                       RDO Equipment Co.                      
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: Solution.cs
*     Creation Date: 2/14/2012
*            Author: Md Hossain
*  
*       Description: SampleData automatically seeds a newly created database after changes 
*                    to a model is introduced and old database is droped.
*  
* 
*	    Code Review: Code reviewed 3/3/2012 Abhinavh Singh, Md Hossain, Munmun Gupta, Nimish Gupta 
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RdoCallLogger.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<RdoEntities>
    {
        protected override void Seed(RdoEntities context)
        {
            Subscription sampleSub = new Subscription { Count = 20, StartDate = new DateTime(2012, 3, 3), ExpirationDate = new DateTime(2013, 3, 3) };

            var farms = new List<Farm>
            {
                new Farm { Name = "Abercrombie", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Stanley", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Edmore", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Martin", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Tuttle", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Esmond", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Killdeer", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Butte", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Pisek", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Forest River", Location = "North Dakota", Subscription = sampleSub },
                new Farm { Name = "Medora", Location = "North Dakota", Subscription = sampleSub }
            };

            new List<Customer>
            {
                new Customer { FirstName = "Md", LastName = "Hossain", Position = "Supervisor", Farm = farms.Single(m => m.Name == "Abercrombie"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Abhinav", LastName = "Sing", Position = "Supervisor", Farm = farms.Single(m => m.Name == "Medora"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Nimish", LastName = "Gupta", Position = "Supervisor", Farm = farms.Single(m => m.Name == "Stanley"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Munmun", LastName = "Gupta", Position = "Supervisor", Farm = farms.Single(m => m.Name == "Edmore"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Ellis", LastName = "Miller", Position = "Farmer", Farm = farms.Single(m => m.Name == "Martin"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Mathias", LastName = "Miller", Position = "Farmer", Farm = farms.Single(m => m.Name == "Tuttle"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Dan", LastName = "Daniels", Position = "Supervisor", Farm = farms.Single(m => m.Name == "Esmond"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Brandon", LastName = "Cane", Position = "Farm technician", Farm = farms.Single(m => m.Name == "Killdeer"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Michel", LastName = "Gleason", Position = "Supervisor", Farm = farms.Single(m => m.Name == "Butte"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Dan", LastName = "Brown", Position = "Supervisor", Farm = farms.Single(m => m.Name == "Pisek"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" },
                new Customer { FirstName = "Tom", LastName = "Cruise", Position = "Farm technician", Farm = farms.Single(m => m.Name == "Forest River"), Location = "North Dakota", CellPhone = "7013061198", WorkPhone = "7013061198", Email = "md.i.hossain@ndsu.edu" }
            }.ForEach(a => context.Customers.Add(a));

            var solutions = new List<Solution>
            {
                new Solution { SolutionTitle = "GPS restart", SolutionDescription = "Sometimes GPS device hangs after long time of uses. Try restarting the device." },
                new Solution { SolutionTitle = "Motor oil", SolutionDescription = "The oil should be changed for motors, if motor stops after five minutes." },
                new Solution { SolutionTitle = "Display fixed", SolutionDescription = "The display of the tractor can be blurred with dust. Clean it using the prescribed material." },
                new Solution { SolutionTitle = "Wheel alignment", SolutionDescription = "The tractor wheel alignment should be checked regularly using the prescribed tools." },
                new Solution { SolutionTitle = "Harvester issue", SolutionDescription = "The harvester may not work after long time of operation. Try to cool the engine after 8 hours of usage." },
                new Solution { SolutionTitle = "Tractor brake padel", SolutionDescription = "If brake padel of tractor is stuck, don't push it hard." },
                new Solution { SolutionTitle = "Tractor front blade", SolutionDescription = "The front blade of the tractor can be changed if unexpected harvesting happens." },
                new Solution { SolutionTitle = "Line not straight", SolutionDescription = "If the anchor is broken the line can be slanted." }
            };
            
            solutions.ForEach(a => context.Solutions.Add(a));

            new List<Case>
            {
                new Case { CaseTitle = "GPS problem", CaseDescription = "After working for 5-6 hours, the GPS device is not working. The display becomes white.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Abercrombie"), Solutions = new List<Solution>{solutions.ElementAt(0)} },
                new Case { CaseTitle = "Motor stopped", CaseDescription = "The motor is suddenly stopped in the middle of plantation.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Abercrombie"), Solutions = new List<Solution>{solutions.ElementAt(1)} },
                new Case { CaseTitle = "Display blurred", CaseDescription = "The display of the tractor control panel is blurred often after working for 2 hours.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Abercrombie"), Solutions = new List<Solution>{solutions.ElementAt(2)} },
                new Case { CaseTitle = "Wheel alignment", CaseDescription = "The tractor wheel alignment is changed and creating serious problem.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Abercrombie"), Solutions = new List<Solution>{solutions.ElementAt(4)} },
                new Case { CaseTitle = "Test data", CaseDescription = "Test data description. Test data description. Test data description. Test data description.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Stanley"), Solutions = new List<Solution>{solutions.ElementAt(4)} },
                new Case { CaseTitle = "Test data", CaseDescription = "Test data description. Test data description. Test data description. Test data description.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Abercrombie"), Solutions = new List<Solution>{solutions.ElementAt(4)} },
                new Case { CaseTitle = "Test data", CaseDescription = "Test data description. Test data description. Test data description. Test data description.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Stanley"), Solutions = new List<Solution>{solutions.ElementAt(5)} },
                new Case { CaseTitle = "Test data", CaseDescription = "Test data description. Test data description. Test data description. Test data description.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Stanley"), Solutions = new List<Solution>{solutions.ElementAt(6)} },
                new Case { CaseTitle = "Test data", CaseDescription = "Test data description. Test data description. Test data description. Test data description.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Abercrombie"), Solutions = new List<Solution>{solutions.ElementAt(7)} },
                new Case { CaseTitle = "Test data", CaseDescription = "Test data description. Test data description. Test data description. Test data description.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Stanley"), Solutions = new List<Solution>{solutions.ElementAt(7)} },
                new Case { CaseTitle = "Test data", CaseDescription = "Test data description. Test data description. Test data description. Test data description.", CloseStatus = false, Farm = farms.Single(m => m.Name == "Abercrombie"), Solutions = new List<Solution>{solutions.ElementAt(7)} }
            }.ForEach(a => context.Cases.Add(a));
        }
    }
}