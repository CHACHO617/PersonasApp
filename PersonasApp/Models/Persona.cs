
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonasApp.Models
{
    public class Persona : INotifyPropertyChanged
    {
        int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value)
                    return;

                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre == value)
                    return;

                _nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nombre)));
            }
        }

        string _cedula;
        public string Cedula
        {
            get => _cedula;
            set
            {
                if (_cedula == value)
                    return;

                _cedula = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cedula)));
            }
        }

        string _telefono;
        public string Telefono
        {
            get => _telefono;
            set
            {
                if (_telefono == value)
                    return;

                _telefono = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Telefono)));
            }
        }

        string _direccion;
        public string Direccion
        {
            get => _direccion;
            set
            {
                if (_direccion == value)
                    return;

                _direccion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Direccion)));
            }
        }

        string _imagen;
        public string Imagen
        {
            get => _imagen;
            set
            {
                if (_imagen == value)
                    return;

                _imagen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Imagen)));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
