using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


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
        foreach (var variable in GetAll())
        {
            if (variable.Id == id)
            { return true; }
        }
        return false;
    }

    private string IntoStringDate(DateOnly date)
    {
        var stringDate = date.ToString();
        return stringDate;
    }
    
    private DateOnly IntoDateOnly(string stringDate)
    {
        var date = DateOnly.Parse(stringDate);
        return date;
    }
    
    private string IntoStringTime(TimeOnly time)
    {
        var stringTime = time.ToString();
        return stringTime;
    }
    
    private TimeOnly IntoTimeOnly(string stringTime)
    {
        var time = TimeOnly.Parse(stringTime);
        return time;
    }
    
    [HttpPost("~/Post")]
    public IActionResult Post( Event eve)
    {
        using var db = new ApplicationContext();
        db.Events.AddRange(eve);
        db.SaveChanges();
        return Ok();
    }
    
    [HttpDelete()]
    [Route("{id}")]
    public void DeleteById(int id)
    {
        GetAll().RemoveAt(id); 
    }
    
    //[HttpPatch()]
    //[Route("{id}")]
    //public void UpdateById(int id, DbSet<Event> rte)
    //{
    //    
    //    var context = new ApplicationContext();
    //
    //    var eve = context.Events
    //        .FirstOrDefault(c => c.Id == id);
    //    
    //    
    //    // Внести изменения
    //    eve.evente = "Сидоров";
    //
    //    // Сохранить изменения
    //    context.SaveChanges();
    //    
    //    foreach (var thing in GetAll().Where(w => w.Id == id))
    //    {
    //        context.Entry(thing).Property(rte
    //    }
    //}

    //[HttpPatch()]
    //[Route("{id}")]
    //public void Update<TEntity>(TEntity entity, DbContext context)
    //    where TEntity : class
    //{
    //    // Настройки контекста
    //    
    //    context.Entry<TEntity>(entity).State = EntityState.Modified;
    //    context.SaveChanges();
    //}

    [HttpGet()]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        if (IsIdValid(id))    
        {return Ok(GetAll()[id-1]);}
        
        return BadRequest("ID not found");
    }
    
    [HttpGet("~/GetAll")]
    public List<Event> GetAll()
    {
        using var db = new ApplicationContext();
        var events = db.Events.ToList();
        foreach (var VARIABLE in events)
        {
            //VARIABLE.Date = intoDateTime(VARIABLE.Date);
        }
        return events;
    }
    
    [HttpGet("~/GetAllDayEvents")]
    public List<Event> GetAllDayEvents()
    {
        var todayEvents = new List<Event>();
        foreach (var variable in GetAll())
        {
            if (IntoDateOnly(variable.Date).Day.Equals(DateTime.Now.Day))
            {
                todayEvents.Add(variable);
            }
        }
    
        if (todayEvents.Count > 0)
        { 
            return todayEvents;
        }

        return null;
    }
    
    [HttpGet("~/GetActualEvent")]
    public IActionResult GetActualEvent()
    {
        var timeNow = TimeOnly.FromDateTime(DateTime.Now);
        if (GetAllDayEvents() != null)
        {
            foreach (var variable in GetAllDayEvents())
            {
                if (timeNow.IsBetween(IntoTimeOnly(variable.TimeStart),
                        IntoTimeOnly(variable.TimeStart).Add(TimeSpan.Parse(variable.TimeSpent))))
                {
                    return Ok(variable);
                }
            }
        }

        return NotFound("Free time");
    }
}