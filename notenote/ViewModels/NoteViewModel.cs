using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization;

namespace notenote
{
    [DataContract]
    public class NoteViewModel : INotifyPropertyChanged
    {
        
        private string _ID;
        private DateTime _dateCreated;
        private DateTime _dateUpdated;
        private string _title;
        private string _body;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        [DataMember]
        public String ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (value != _ID)
                {
                    _ID = value;
                    this._dateUpdated = DateTime.Now;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        [DataMember]
        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }
            set
            {
                if (value != _dateCreated)
                {
                    _dateCreated = value;
                    NotifyPropertyChanged("DateCreated");
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        [DataMember]
        public DateTime DateUpdated
        {
            get
            {
                return _dateUpdated;
            }
            set
            {
                if (value != _dateUpdated)
                {
                    _dateUpdated = value;
                    NotifyPropertyChanged("DateUpdated");
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        [DataMember]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    this._dateUpdated = DateTime.Now;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        [DataMember]
        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                if (value != _body)
                {
                    _body = value;
                    this._dateUpdated = DateTime.Now;
                    NotifyPropertyChanged("Body");
                }
            }
        }

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}