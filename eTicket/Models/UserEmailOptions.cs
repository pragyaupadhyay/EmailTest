using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class UserEmailOptions
    {
        public List<string> ToEmail { get; set; }
        public string EmailBody { get; set; }
        public string Subject { get; set; }
        public List<KeyValuePair<string, string>> PlaceHolders { get; set; }

       /* public static implicit operator UserEmailOptions(UserEmailOptions v)
        {
            throw new NotImplementedException();
        }*/
        //public string EmailText { get; set; }

        //  public List<string> ccEmailAddress { get; set; }
        // public List<string> bccEmailAddress { get; set; }

        // public int Id { get; set; }
        // public string key_name { get; set; }



        // public bool status { get; set; }



    }
}
