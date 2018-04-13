using System;
using Xamarin.Forms;

namespace TestProjectXamarin.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Color BackgroundColor { get; set; }

        public Type TargetType { get; set; }

        public MasterMenuItem(string title, string iconSource, Color backgroundColor, Type targetType)
        {
            this.Title = title;
            this.IconSource = iconSource;
            this.BackgroundColor = backgroundColor;
            this.TargetType = targetType;
        }

    }
}