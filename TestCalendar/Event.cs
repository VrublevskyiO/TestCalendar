namespace TestCalendar;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string? Notes { get; set; }

    public DateTime Date { get; set; }

    public DateTime TimeStart { get; set; }

    public TimeSpan TimeSpent { get; set; }

    public int EventValue { get; set; }

    public string? Category { get; set; }

    public bool Status { get; set; }

    public Event() { }

    public Event( string name, DateTime date, DateTime timeStart, TimeSpan timeSpent, int eventValue)
    {
        Name = name;
        Date = date;
        TimeStart = timeStart;
        TimeSpent = timeSpent;
        EventValue = eventValue;
    }
}