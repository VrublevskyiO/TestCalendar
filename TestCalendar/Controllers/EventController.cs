using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using Microsoft.AspNetCore.Identity;


namespace TestCalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private static readonly List<Event> Events = new () 
    {
        //new ()
        //{
        //    Name = "Cycling",
        //    Date = "2022, 01, 11",
        //    EventValue = 6,
        //    TimeStart = "8, 30, 52",
        //    //TimeSpent = new TimeSpan(hours: 1, minutes: 30, seconds:0)
        //}, 
        //new ()
        //{
        //    Name = "Running",
        //    Date = "2022, 04, 16",
        //    EventValue = 4,
        //    TimeStart = "8, 30, 52",
        //    //TimeSpent = new TimeSpan(hours: 1, minutes: 0, seconds:0)
        //}
    };
    
    private bool IsIdValid(int id)
    {
        foreach (var variable in Events)
        {
            if (variable.Id == id)
            { return true; }
        }
        return false;
    }
    
    [HttpGet()]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        if (IsIdValid(id)) 
        {return Ok(Events[id]);}
        
        return BadRequest("ID not found");
    }

    [HttpGet()]
    public List<Event> GetAll()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var events = db.Events.ToList();
            return events;
        }
    }
    
    //[HttpGet()]
    //public IActionResult GetAllDayEvents()
    //{
    //    var todayEvents = new List<Event>();
    //    foreach (var variable in Events)
    //    {
    //        if (variable.Date.Day.Equals(DateTime.Now.Day))
    //        {
    //            todayEvents.Add(variable);
    //        }
    //    }
    //
    //    if (todayEvents.Count > 0)
    //    { 
    //        return Ok(todayEvents);
    //    }
    //    return BadRequest("pizdos");
    //}
    
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
    public void Post(string name, Date date, Time timeStart, TimeSpan timeSpent, int eventValue)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var eve = new Event( name, date, timeStart, timeSpent,eventValue);
            db.Events.AddRange(eve);
            db.SaveChanges();
        }
        
      
    }

    //[HttpGet()]
    //public IActionResult GetActualEvent()
    //{
    //    var timeNow = TimeOnly.FromDateTime(DateTime.Now);
    //    foreach (var variable in GetAllDayEvents())
    //    {
    //        if (variable.TimeStart > timeNow && variable.TimeStart.Add(variable.TimeSpent) < timeNow)
    //        {
    //            return Ok(variable);
    //        }
    //    }
    //
    //    return NotFound("Free time");
    //}
    
}