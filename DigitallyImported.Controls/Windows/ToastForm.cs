using System;
using System.ComponentModel;
using DigitallyImported.Components;
using VbPowerPack;

namespace DigitallyImported.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract partial class ToastForm<T> : NotificationWindow where T: IContent
    {
        private T _content = default(T);

        /// <summary>
        /// 
        /// </summary>
        protected readonly string TextFormat = "{0}{1}{1}{2}";

        /// <summary>
        /// 
        /// </summary>
        protected ToastForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        protected ToastForm(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        protected ToastForm(T content)
        {
            _content = content;

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract T Content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string BodyText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string TitleText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // return string.Format(TextFormat, TitleText, Environment.NewLine, Text);
            return TitleText;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected internal virtual string GetFormattedBody()
        {
            if (BodyText == null || TitleText == null) throw new InvalidOperationException("Properties 'Text' and 'TitleText' must be set. ");

            return string.Format(TextFormat, TitleText, Environment.NewLine, BodyText);
        }

        
    }
}
