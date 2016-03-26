namespace guidgen
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const string style1 = "N";
        private const string style2 = "D";
        private const string style3 = "B";
        private const string style4 = "P";
        private const string style5 = "X";

        private Guid currentGuid = Guid.NewGuid();

        private string guidConverterStyle = style1;

        private bool isUppercase = false;

        private ICommand newGuidCommand;
        private ICommand copyGuidCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public GuidViewModel GuidViewModel
        {
            get
            {
                return new GuidViewModel { Guid = this.currentGuid, IsUppercase = this.isUppercase };
            }

            set
            {
                this.RaisePropertyChanged();
            }
        }

        public string CurrentGuid
        {
            get
            {
                var result = this.currentGuid.ToString(this.guidConverterStyle);

                if (this.isUppercase)
                {
                    result = result.ToUpperInvariant();
                }

                return result;
            }

            set
            {
                this.GuidViewModel = this.GuidViewModel;
                this.RaisePropertyChanged();
            }
        }

        public bool Style1
        {
            get { return this.guidConverterStyle == style1; }
            set { if (value) this.GuidConverterStyle(style1); this.RaisePropertyChanged(); }
        }

        public bool Style2
        {
            get { return this.guidConverterStyle == style2; }
            set { if (value) this.GuidConverterStyle(style2); this.RaisePropertyChanged(); }
        }

        public bool Style3
        {
            get { return this.guidConverterStyle == style3; }
            set { if (value) this.GuidConverterStyle(style3); this.RaisePropertyChanged(); }
        }

        public bool Style4
        {
            get { return this.guidConverterStyle == style4; }
            set { if (value) this.GuidConverterStyle(style4); this.RaisePropertyChanged(); }
        }

        public bool Style5
        {
            get { return this.guidConverterStyle == style5; }
            set { if (value) this.GuidConverterStyle(style5); this.RaisePropertyChanged(); }
        }

        public bool IsUppercase
        {
            get { return this.isUppercase; }
            set { this.isUppercase = value; this.CurrentGuid = this.CurrentGuid; this.RaisePropertyChanged(); }
        }

        public ICommand NewGuidCommand
        {
            get { return this.newGuidCommand ?? (this.newGuidCommand = new SimpleCommand(() => this.NewGuid())); }
        }

        public ICommand CopyGuidCommand
        {
            get { return this.copyGuidCommand ?? (this.copyGuidCommand = new SimpleCommand(() => Clipboard.SetText(this.CurrentGuid))); }
        }

        private void NewGuid()
        {
            this.currentGuid = Guid.NewGuid();
            this.CurrentGuid = this.CurrentGuid;
        }

        private void GuidConverterStyle(string style)
        {
            this.guidConverterStyle = style;
            if (style != style1) this.Style1 = false;
            if (style != style2) this.Style2 = false;
            if (style != style3) this.Style3 = false;
            if (style != style4) this.Style4 = false;
            if (style != style5) this.Style5 = false;
            this.CurrentGuid = this.CurrentGuid;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}