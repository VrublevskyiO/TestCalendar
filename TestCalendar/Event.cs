namespace TestCalendar;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string? Notes { get; set; }

    public string Date { get; set; }

    public string TimeStart { get; set; }

    public string TimeSpent { get; set; }

    public int EventValue { get; set; }

    public string? Category { get; set; }

    public bool Status { get; set; }

    public Event() { }

    public Event( string name, string date, string timeStart, string timeSpent, int eventValue)
    {
        Name = name;
        Date = date;
        TimeStart = timeStart;
        TimeSpent = timeSpent;
        EventValue = eventValue;
    }
}