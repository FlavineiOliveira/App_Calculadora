using App_Calc.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace App_Calc.ViewModels
{
    [Preserve(AllMembers = true)]
    public class ViewModelBase<T> : INotifyPropertyChanged
     where T : class, new()
    {
        private T _entidade;

        public IMessage Message { get; set; }
        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isEnable;
        private bool _isRefreshing;
        private bool _isVisible;
        private double _Opacity;

        public bool isEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable = value;
                RaisePropertyChanged("isEnable");
            }
        }

        public bool isVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                RaisePropertyChanged("isVisible");
            }
        }

        public bool isRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged("isRefreshing");
            }
        }

        public double Opacity
        {
            get
            {
                return _Opacity;
            }
            set
            {
                _Opacity = value;
                RaisePropertyChanged("Opacity");
            }
        }

        public ViewModelBase()
        {
            Entidade = new T();
            isEnable = true;
        }

        public T Entidade
        {
            get
            {
                return _entidade;
            }
            set
            {
                _entidade = value;
                RaisePropertyChanged("Entidade");
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        protected void RaisedPropertyChanged<TT>(Expression<Func<TT>> expression)
        {
            var member = expression.Body as MemberExpression;
            var propertyInfo = member.Member as PropertyInfo;

            if (propertyInfo != null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyInfo.Name));
            }
        }
    }
}
