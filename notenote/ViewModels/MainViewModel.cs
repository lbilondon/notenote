using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using System.Xml.Serialization;

namespace notenote
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Notes = new ObservableCollection<NoteViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<NoteViewModel> Notes { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public NoteViewModel AddNew(string Title, string Body)
        {
            NoteViewModel note = new NoteViewModel();
            DateTime date = DateTime.Now;

            note.ID = date.ToString();
            note.DateCreated = date;
            note.DateUpdated = date;
            note.Title = Title;
            note.Body = Body;

            this.Notes.Add(note);

            return note;
        }

        public void Remove(NoteViewModel Note)
        {
            this.Notes.Remove(Note);
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            try
            {

                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication()) 
                { 
                    using(IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Notes.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<notenote.NoteViewModel>));
                        ObservableCollection<notenote.NoteViewModel> data = (ObservableCollection<notenote.NoteViewModel>)serializer.Deserialize(stream);
                        this.Notes = data;
                    }
                }

            }
            catch { }

            this.IsDataLoaded = true;
        }

        public void SaveData()
        {
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = myIsolatedStorage.OpenFile("Notes.xml", FileMode.Create))
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;

                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<notenote.NoteViewModel>));
                    using (XmlWriter writer = XmlWriter.Create(isoStream, settings)) 
                    {
                        serializer.Serialize(writer, this.Notes);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
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