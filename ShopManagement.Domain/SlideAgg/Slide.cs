using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide:EntityBase
    {
        public string Heading{ get; private set; }
        public string Title{ get; private set; }
        public string Text{ get; private set; }
        public string BtnText { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Link { get; private set; }

        public Slide(string heading, string title, string text, string btnText, string picture, string pictureAlt, string pictureTitle, string link)
        {
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Link = link;
        }
        public void Edit(string heading, string title, string text, string btnText, string picture, string pictureAlt, string pictureTitle,string link)
        {
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Link = link;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;

        }
    }
}
