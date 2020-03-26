using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportStaffData
{
    class Program
    {

        static char GetSeparator(string source)
        {
            return source.Replace(" ", string.Empty).First(x => !char.IsLetter(x));
        }

        static void Main(string[] args)
        {
            var context = new MarathonStaff();
            using (var reader = new StreamReader(@"staff_data.csv"))
            {
                var columnNames = reader.ReadLine().Split(';').Where(x => x != string.Empty).ToList();

                while (!reader.EndOfStream)
                {
                    /*
                        Staff ID Num
                        Full Name
                        Date of Birth
                        Gender
                        Position ID
                        Position Name
                        Position Description
                        Pay Period
                        Pay Rate
                        Email Address
                     */
                    var rows = reader.ReadLine().Split(';');

                    if (string.IsNullOrEmpty(rows[0]))
                        continue;
                    
                    var staffID = int.Parse(rows[0]);
                    var separator = GetSeparator(rows[1]);
                    var firstName = rows[1].Split(separator)[0];
                    var lastName = rows[1].Split(separator)[1];
                    var dateOfBirth = DateTime.Parse(rows[2]);
                    var gender = rows[3][0].ToString();
                    var posID = byte.Parse(rows[4]);
                    var posName = rows[5];
                    var posDescr = rows[6];
                    var payRate = decimal.Parse(rows[8].Replace("$", "").Replace(" ", ""));
                    var email = rows[9].Replace("@@", "@");

                    var findedPos = context.Positions.SingleOrDefault(x => x.PositionId == posID);
                    var findedStaff = context.Staffs.SingleOrDefault(x => x.StaffId == staffID);
                    
                    if (findedStaff != null)
                    {
                        Console.WriteLine($"Staff is finded {findedStaff.StaffId}");
                        continue;
                    }

                    if (findedPos is null)
                    {
                        //Create new
                        var newPos = new Position
                        {
                            PositionId = posID,
                            PositionName = posName,
                            PositionDescription = posDescr,
                            Payrate = payRate
                        };
                        
                        context.Positions.Add(newPos);
                        findedPos = newPos;
                        Console.WriteLine($"Added new position {findedPos.PositionId}");
                    }
                    else
                        Console.WriteLine($"Finded position {findedPos.PositionId}");
                    var newStaff = new Staff
                    {
                        StaffId = staffID,
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth,
                        Gender = gender,
                        PostionId = findedPos.PositionId,
                        Email = email
                    };
                    context.Staffs.Add(newStaff);
                    context.SaveChanges();
                    Console.WriteLine($"Added new staff {newStaff.StaffId}");
                }
            }
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
