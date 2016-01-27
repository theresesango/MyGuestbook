using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Comment
    {
        public int ID { get; set; }
        public  string Nickname { get; set; }
        public  string Email { get; set; }
        public  string Content { get; set; }
        public DateTime TimeOfComment { get; set; }

        public virtual Guestbook Guestbook { get; set; }

        public Comment()
        {
            
        }

        public Comment(string nickname, string email, string content, DateTime timeOfComment)
        {
            Nickname = nickname;
            Email = email;
            Content = content;
            TimeOfComment = timeOfComment;
        }


        public override string ToString()
        {
            return string.Format("Nickname: {0}, Email: {1} \r\nComment: {2}", Nickname, Email, Content);
        }
    }
}
