using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;



namespace TestCalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    public static bool IsIdValid(int id)
    {
        foreach (var variable in Events)
        {
            if (variable.Id == id) { return true; }
        }
        return false;
        // var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
        //throw new HttpResponseException(notFoundResponse);
    }
    
    private static readonly List<Event> Events = new () 
    {
        new ()
        {
            Id = 0, 
            Name = "Cycling",
            Date = "01.11.2022",
            EventValue = 6,
            TimeStart = "16.00",
            TimeSpent = 2
        }, 
        new ()
        {
            Id = 1, 
            Name = "Running",
            Date = "02.11.2022",
            EventValue = 4,
            TimeStart = "20.00",
            TimeSpent = 1.5
        }
    };
    
    [HttpGet()]
    [Route("{id}")]
    public Event GetById(int id)
    {
        if (IsIdValid(id))
        {return Events[id];}
        else
        {
             //Console.WriteLine();
             BadRequest("fghjkl");
             return Events[0];
        }
    }

    [HttpGet()]
    public List<Event> GetAll()
    {
        return Events;   
    }
    
    [HttpDelete()]
    [Route("{id}")]
    public void DeleteById(int id)
    {
        Events.RemoveAt(id); 
    }
    
    [HttpPatch()]
    [Route("{id}")]
    public void UpdateById(int id)
    {
        foreach (var thing in Events.Where(w => w.Id == id))
        {
            //
        }
    }
    
    [HttpPost()]
    public void Post(string name, string date, string timeStart, double timeSpent, int eventValue)
    {
        Events.Add(new Event(Events.Count, name,date,timeStart, timeSpent,eventValue));
    }
}