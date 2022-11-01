namespace TestCalendar;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Date { get; set; }
    
    public string TimeStart { get; set; }
    
    public double TimeSpent { get; set; }
    
    public int EventValue { get; set; }

    public Event() { }

    public Event(int id, string name, string date, string timeStart, double timeSpent, int eventValue)
    {
        Id = id;
        Name = name;
        Date = date;
        TimeStart = timeStart;
        TimeSpent = timeSpent;
        EventValue = eventValue;
    }
}