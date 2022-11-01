using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;



namespace TestCalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
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
    
    public IActionResult IsIdValid(int id)
    {
        foreach (var variable in Events)
        {
            if (variable.Id == id)
            {
                return Ok();
            }
        }
        return BadRequest("ID not found");
    }
    
    [HttpGet()]
    [Route("{id}")]
    public dynamic GetById(int id)
    {
        if (IsIdValid(id) == OkResult) 
        {return Events[id];}
        
        
        //Нижня стрічка взагалі зайва, але компілятор без неї не пропускає
        return BadRequest("ID not found");;
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