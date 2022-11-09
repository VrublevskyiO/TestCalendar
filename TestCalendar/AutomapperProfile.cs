using AutoMapper;
//using Data.Entities;
//using Service.DataTransferObjects;


namespace TestCalendar;

//Переробити!

//public class EventProfile : Profile
//{
//    public EventProfile()
//    {
//        CreateMap<long, DateTime>().ForMember(dest => dest.Date, opt => opt.MapFrom<long>((unixTime, dateTime) =>
//        {
//            unixTime = ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
//                return unixTime;
//            
//        }));
//        CreateMap<DateTime, long>().ForMember(dest => dest, opt => opt.MapFrom<DateTime>((dateTime, unixTime) =>
//        {
//            dateTime = dateTime.AddSeconds(unixTime).ToLocalTime();
//                return dateTime;
//        }));
//    }
//}