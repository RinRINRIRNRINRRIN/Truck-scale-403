using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC403.Models
{
    internal class SystemModels
    {
        /// <summary>
        /// ชื่อเครื่องชั่ง
        /// </summary>
        public static string ScaleName { get; set; }

        /// <summary>
        /// พิกัดสูงสุดของเครื่องชั่ง
        /// </summary>
        public static int CapacityScale { get; set; } = 0;


        /// <summary>
        /// key ที่ได้จาก ชตว
        /// </summary>
        public static string PublicId { get; set; } = "";

        /// <summary>
        /// key ที่ได้จาก ชตว
        /// </summary>
        public static string PublicKey { get; set; } = "";


        /// <summary>
        /// วันที่ปัจจุบันของระบบ 
        /// </summary>
        public static string DateCurrent { get; set; }

        /// <summary>
        /// วันหมดอายุของระบบ
        /// </summary>
        public static string DateExpire { get; set; }

        /// <summary>
        /// ชื่อสถานีชั่ง
        /// </summary>
        public static string StationName { get; set; }

        /// <summary>
        /// ที่อยู่ตั๋ว
        /// </summary>
        public static string TicketAddress { get; set; }

        /// <summary>
        /// ชื่อบริษัทที่ออกตั๋ว
        /// </summary>
        public static string TicketCompany { get; set; }

        /// <summary>
        /// เบอร์โทรศัพท์ที่ออกตั๋ว
        /// </summary>
        public static string TicketPhone { get; set; }


        /// <summary>
        /// เลขที่โปรแกรม
        /// </summary>
        public static string ProgramId { get; set; }
    }
}
