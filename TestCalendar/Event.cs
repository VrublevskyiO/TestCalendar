namespace TestCalendar;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string? Notes { get; set; }
    
    public Date? Date  { get; set; }
    
    public Time? TimeStart { get; set; }
    
    public TimeSpan TimeSpent { get; set; }
    
    public int EventValue { get; set; }
    
    public string? Category { get; set; }
    
    public bool Status { get; set; }

    public Event() { }

    public Event( string name, Date date, Time timeStart, TimeSpan timeSpent, int eventValue)
    {
        Name = name;
        Date = date;
        TimeStart = List<int>[
            timeStart.Hours, 
            timeStart.Minutes ];
        TimeSpent = timeSpent;
        EventValue = eventValue;
    }
}