using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        [Display(Name ="Date Of Birth")]
        [DataType(DataType.DateTime)]
         public DateTime Birthdate {  get; set; }
        [Key]
        [StringLength(7)]
        public string PassporitNumber {  get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }
        //[MinLength(3, ErrorMessage ="Longueur minimal non respecte") ]
        //[MaxLength(25, ErrorMessage = "Longueur maximal non respecte") ]
        //public string FirstName { get; set; }   
        //public string LastName { get; set; }

        public FullName FullName { get; set; }

        [RegularExpression("^[0-9]{8}$")]
        public string TelNumber { get; set; }

        public virtual ICollection<Ticket> Tickets {  get; set; }



        //public override string ToString()
        //{
        //    return "FirstName: "+FirstName+" LastName: "+LastName+" BirthDate "+Birthdate;
        //}

        public bool CheckProfile(string FirstName,string LastName, string? EmailAdress)
        {
            if(FirstName == this.FullName.FirstName && LastName == this.FullName.LastName && EmailAdress==this.EmailAdress)
            {
                return true;
            }
            if (FirstName == this.FullName.FirstName && LastName == this.FullName.LastName && EmailAdress == null)
            {
                return true;
            }
            return false;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I'am a passenger");
        }


    }
}
