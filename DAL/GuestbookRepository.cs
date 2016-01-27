using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GuestbookRepository
    {
        private GuestbookContext _guestbookContext;
        private static int _counter;
        public int Pages;
        public bool EndOfpagination;

        public GuestbookRepository()
        {
            _guestbookContext = new GuestbookContext();
        }

        public List<Guestbook> GetGuestbook()
        {
            var query =
                (from g in _guestbookContext.Guestbooks
                 select g).ToList();
            return query;
        }

        public List<Comment> GetComments(string guestbook, string mode)
        {
            var query = (
             from g in _guestbookContext.Guestbooks
             from c in _guestbookContext.Comments
             where g.GuestbookName == guestbook
             orderby c.TimeOfComment descending
             select c);

            if (mode == "+")
            {
                _counter++;
            }
            else if (mode == "-")
            {
                _counter--;
            }
            else
            {
                _counter = 0;
            }

            int itemsPerPage = 5;
            double count = query.ToList().Count;
            Pages = (int)Math.Ceiling(count / itemsPerPage);

            query = query.Skip((itemsPerPage * (Pages - Pages + _counter))).Take(itemsPerPage);

            if (_counter <= 0 || _counter >= Pages - 1)
            {
                EndOfpagination = true;
            }

            return query.ToList();
        }

        public Guestbook GetTheGuestbook()
        {
            var query = (
                from g in _guestbookContext.Guestbooks
                select g).FirstOrDefault();
            return query;
        }


        public Comment GetTheComment(int Id)
        {
            var query = (
                from c in _guestbookContext.Comments
                where c.ID == Id
                select c).FirstOrDefault();
            return query;
        }

        public Comment GetTheCommentWithLambda(int Id)
        {
            var query = (
                _guestbookContext.Comments.Where(c => c.ID == Id)).FirstOrDefault();
            return query;
        }
    }
}
