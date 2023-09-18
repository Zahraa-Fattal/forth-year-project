using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OurProject.Dto.StudentDto;
using OurProject.Dto.UnitRoomDto;
using OurProject.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static GetAllUserDto CurrentUser;
        public static string JavascriptToRun { get; set; } = "";
        public static List<GetAllUnRecordedStudentsDto> Studentlist { get; set; }
        public static List<GetAllRecorderStudentsDto> RecordedStudentlist { get; set; }
       public  static DisplayRoomDto RoomListDto = new DisplayRoomDto()
        {
            getRoomsInUnitDtos = new List<GetRoomsInUnitDto>(),
            getStudentInRoomDtos = new List<List<GetStudentInRoomDto>>()
        };
        public static bool IsFilterd { get; set; } = false;
        public static bool IsDateFilterd { get; set; } = false;
        public static bool IsDeleteBegin { get; set; } = false;


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
