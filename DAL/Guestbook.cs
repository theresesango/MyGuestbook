using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Guestbook
    {
        public int ID { get; set; }
        public string GuestbookName { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public Guestbook()
        {

        }

        public Guestbook(string guestbookName, List<Comment> comments)
        {
            GuestbookName = guestbookName;
            Comments = comments;
        }

        public override string ToString()
        {
            return string.Format("{0}", GuestbookName);
        }
    }
}
