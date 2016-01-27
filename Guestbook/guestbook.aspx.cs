using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Guestbook
{
    public partial class guestbook : System.Web.UI.Page
    {
        private GuestbookRepository _guestbookRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            _guestbookRepository = new GuestbookRepository();

            ValidateForNullOrWhitespace.Visible = false;
            ValidateForHacks.Visible = false;

            NoMoreFuture();
            GoToPast();

            var guestbookName = _guestbookRepository.GetTheGuestbook();
            Label1.Text = guestbookName.ToString();
            if (!IsPostBack)
            {
                CommentsRepeater.DataSource = _guestbookRepository.GetComments(guestbookName.ToString(), "");
                CommentsRepeater.DataBind();
            }
        }
        
        protected void Button_Click(object sender, EventArgs e)
        {
            using (var dbCtx = new GuestbookContext())
            {
                bool ok = true;

                if (string.IsNullOrWhiteSpace(NicknameInput.Text) || string.IsNullOrWhiteSpace(EmailInput.Text) || string.IsNullOrWhiteSpace(ContentInput.Text))
                {
                    ok = false;
                    ValidateForNullOrWhitespace.Visible = true;
                }
                if ((NicknameInput.Text.Contains("<script") && NicknameInput.Text.EndsWith(">")) &&
                    (EmailInput.Text.Contains("<script") && NicknameInput.Text.EndsWith(">")) &&
                    (ContentInput.Text.Contains("<script") && NicknameInput.Text.EndsWith(">")))
                {
                    ok = false;
                    ValidateForHacks.Visible = true;
                    ValidateForNullOrWhitespace.Visible = false;
                }
                if (ok)
                {
                    var comment = new Comment
                    {
                        Nickname = NicknameInput.Text,
                        Email = EmailInput.Text,
                        Content = ContentInput.Text,
                        TimeOfComment = DateTime.Now
                    };

                    dbCtx.Comments.Add(comment);
                    dbCtx.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                }

            }

        }

        protected void Delete_Comment(object sender, EventArgs e)
        {
            var idStr = (sender as LinkButton).CommandArgument;
            var id = int.Parse(idStr);

            using (var dbCtx = new GuestbookContext())
            {
                var commentToDelete = (
                    from c in dbCtx.Comments
                    where c.ID == id
                    select c).FirstOrDefault();

                dbCtx.Comments.Remove(commentToDelete);
                dbCtx.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void PastOrFuture(object sender, EventArgs e)
        {
            LinkButton clickedButton = (LinkButton)sender;
            clickedButton.ID.ToString();
            var theGuestbook = _guestbookRepository.GetTheGuestbook();
            
            if (clickedButton.ID == "NextPaginationLink")
            {
                var comments = _guestbookRepository.GetComments(theGuestbook.GuestbookName, "-");
                FutureLabe();
                CommentsRepeater.DataSource = comments;
            }
            else if (clickedButton.ID == "PreviusPaginationLink")
            {
                var comments = _guestbookRepository.GetComments(theGuestbook.GuestbookName, "+");
                PastLabe();
                CommentsRepeater.DataSource = comments;
            }
            CommentsRepeater.DataBind();
        }

        protected void FutureLabe()
        {
            if (_guestbookRepository.EndOfpagination)
            {
                NoMoreFuture();
            }
            else
            {
                GoToFuture();
            }
        }
        
        protected void PastLabe()
        {
            if (_guestbookRepository.EndOfpagination)
            {
                GoToFuture();
                NoMorePast();
            }
            else
            {
                GoToFuture();
            }
        }

        private void GoToFuture()
        {
            NextPaginationLink.Text = "< To the future";
            NextPaginationLink.Enabled = true;
            NextPaginationLink.ForeColor = Color.White;
        }
        private void GoToPast()
        {
            PreviusPaginationLink.Text = "Into The Past >";
            PreviusPaginationLink.Enabled = true;
            PreviusPaginationLink.ForeColor = Color.White;
        }

        private void NoMoreFuture()
        {
            NextPaginationLink.Text = "There's no future";
            NextPaginationLink.Enabled = false;
            NextPaginationLink.ForeColor = Color.Red;
        }
        private void NoMorePast()
        {
            PreviusPaginationLink.Text = "No more to tell";
            PreviusPaginationLink.Enabled = false;
            PreviusPaginationLink.ForeColor = Color.Red;
        }
        
    }
}