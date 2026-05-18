using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSC403.Models;

namespace TSC403.Functions
{
    internal class Registryz
    {
        /// SMRS6808015
        private string PathRegistry { get; } = "SOFTWARE\\TSC";
        public string Err { get; set; }

        /// <summary>
        /// สำหรับสร้างไฟล์ Registry ในกรณีที่ยังไม่มีการสร้างขึ้นมา โดยจะมีการกำหนดค่าเริ่มต้นเป็นค่าว่างทั้งหมด
        /// </summary>
        /// <returns></returns>
        public bool createRegistry()
        {
            try
            {
                using (RegistryKey Patch = Registry.CurrentUser.CreateSubKey(PathRegistry))
                {
                    // scale
                    AESEncrystion aESEncryption = new AESEncrystion();
                    Patch.SetValue("key_scaleCapacity", aESEncryption.Encrypt("0"));
                    Patch.SetValue("key_scaleName", "");

                    //PublicKey
                    Patch.SetValue("key_keyId", "");
                    Patch.SetValue("key_publicKey", "");

                    // system
                    Patch.SetValue("key_systemDate", "");
                    Patch.SetValue("key_systemDateExpire", "");
                    Patch.SetValue("key_systemID", "");
                    Patch.SetValue("key_systemStationName", "");


                    // tickets
                    Patch.SetValue("key_ticketAddress", "");
                    Patch.SetValue("key_ticketTAX", "");
                    Patch.SetValue("key_ticketCompany", "");
                    Patch.SetValue("key_ticketPhone", "");
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// สำหรับดึงค่าต่างๆ จากไฟล์ Registry ที่ถูกสร้างขึ้นมาแล้ว โดยจะมีการนำค่าที่ได้ไปเก็บไว้ใน SystemModels เพื่อให้สามารถนำไปใช้งานต่อได้
        /// </summary>
        /// <returns></returns>
        public bool getParameterRegistry()
        {
            try
            {
                using (RegistryKey Patch = Registry.CurrentUser.OpenSubKey(PathRegistry))
                {
                    AESEncrystion aESEncryption = new AESEncrystion();
                    // scale
                    SystemModels.ScaleName = aESEncryption.Decrypt(Convert.ToString(Patch.GetValue("key_scaleName")));
                    SystemModels.CapacityScale = int.Parse(aESEncryption.Decrypt(Patch.GetValue("key_scaleCapacity").ToString()));


                    // system
                    SystemModels.DateCurrent = aESEncryption.Decrypt(Convert.ToString(Patch.GetValue("key_systemDate")));
                    SystemModels.DateExpire = aESEncryption.Decrypt(Convert.ToString(Patch.GetValue("key_systemDateExpire")));
                    SystemModels.ProgramId = aESEncryption.Decrypt(Convert.ToString(Patch.GetValue("key_systemID")));
                    SystemModels.StationName = aESEncryption.Decrypt(Convert.ToString(Patch.GetValue("key_systemStationName")));

                    // Ticket
                    SystemModels.TicketAddress = aESEncryption.Decrypt(Patch.GetValue("key_ticketAddress").ToString());

                    SystemModels.TicketCompany = aESEncryption.Decrypt(Patch.GetValue("key_ticketCompany").ToString());
                    SystemModels.TicketPhone = aESEncryption.Decrypt(Patch.GetValue("key_ticketPhone").ToString());

                    // KeyPublic
                    SystemModels.PublicId = aESEncryption.Decrypt(Patch.GetValue("key_keyId").ToString());
                    SystemModels.PublicKey = aESEncryption.Decrypt(Patch.GetValue("key_publicKey").ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดผลาด", "FuncMain CREATE KEY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return false;
            }
            Console.WriteLine("FuncRegister GET_REGISTRY : SUCCESS");
            return true;
        }


        /// <summary>
        /// สำหรับบันทึกค่าต่างๆ ที่อยู่ใน SystemModels ลงไปในไฟล์ Registry โดยจะมีการเข้ารหัสค่าต่างๆ ก่อนที่จะนำไปเก็บไว้ในไฟล์ Registry เพื่อเพิ่มความปลอดภัยในการจัดเก็บข้อมูล
        /// </summary>
        /// <returns></returns>
        public bool setParameterRegistry()
        {
            try
            {
                using (RegistryKey Patch = Registry.CurrentUser.CreateSubKey(PathRegistry))
                {
                    // scale
                    AESEncrystion aESEncryption = new AESEncrystion();
                    Patch.SetValue("key_scaleName", aESEncryption.Encrypt(SystemModels.ScaleName));
                    Patch.SetValue("key_scaleCapacity", aESEncryption.Encrypt(SystemModels.CapacityScale.ToString()));

                    // system
                    Patch.SetValue("key_systemDate", aESEncryption.Encrypt(SystemModels.DateCurrent));
                    Patch.SetValue("key_systemDateExpire", aESEncryption.Encrypt(SystemModels.DateExpire));
                    Patch.SetValue("key_systemID", aESEncryption.Encrypt(SystemModels.ProgramId));
                    Patch.SetValue("key_systemStationName", aESEncryption.Encrypt(SystemModels.StationName));


                    // tickets
                    Patch.SetValue("key_ticketAddress", aESEncryption.Encrypt(SystemModels.TicketAddress));
                    Patch.SetValue("key_ticketCompany", aESEncryption.Encrypt(SystemModels.TicketCompany));
                    Patch.SetValue("key_ticketPhone", aESEncryption.Encrypt(SystemModels.TicketPhone));
                    // Publicket
                    Patch.SetValue("key_keyId", aESEncryption.Encrypt(SystemModels.PublicId));
                    Patch.SetValue("key_publicKey", aESEncryption.Encrypt(SystemModels.PublicKey));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FuncRegister SET_REGISTRY : " + ex.Message);
                MessageBox.Show("เกิดข้อผิดผลาด", "FuncRegister SET KEY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Console.WriteLine("FuncRegister SET_REGISTRY : SUCCESS");
            return true;
        }


        /// <summary>
        /// สำหรับเช็คว่าไฟล์ Registry ที่ถูกสร้างขึ้นมาแล้วมีการกำหนดค่าไว้แล้วหรือยัง โดยจะมีการเช็คค่าต่างๆ ที่อยู่ใน SystemModels ว่ามีการกำหนดค่าไว้แล้วหรือยัง ถ้ายังไม่มีการกำหนดค่าไว้จะถือว่าไฟล์ Registry ยังไม่มีการใช้งาน และจะต้องทำการสร้างไฟล์ Registry ใหม่ขึ้นมาเพื่อให้สามารถใช้งานได้ต่อไป
        /// </summary>
        /// <returns></returns>
        public bool checkRegistryFile()
        {
            try
            {
                RegistryKey path = Registry.CurrentUser.OpenSubKey(PathRegistry);
                if (path == null)
                {
                    // create registry
                    if (!createRegistry())
                        return false;

                    // เช็คว่าไฟล์ที่สร้างมีการกำหนดค่าไว้แล้วหรือยัง
                    if (!getParameterRegistry())
                        return false;

                    if (SystemModels.ProgramId == null || SystemModels.ProgramId == "")
                        return false;
                }
                else
                {
                    // เช็คว่าไฟล์ที่สร้างมีการกำหนดค่าไว้แล้วหรือยัง
                    if (!getParameterRegistry())
                        return false;

                    if (SystemModels.ProgramId == null || SystemModels.ProgramId == "")
                        return false;
                }
            }
            catch (Exception ex)
            {
                Err = ex.Message;
                return false;
            }
            return true;
        }

        public void updateDateCurrent()
        {
            try
            {
                using (RegistryKey Patch = Registry.CurrentUser.CreateSubKey(PathRegistry))
                {
                    // system
                    AESEncrystion aESEncryption = new AESEncrystion();
                    Patch.SetValue("key_systemDate", aESEncryption.Encrypt(DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"))));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FuncRegister UPDATE_DATE_CURRENT : " + ex.Message);
                MessageBox.Show("เกิดข้อผิดผลาด", "FuncRegister UPDATE_DATE_CURRENT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
