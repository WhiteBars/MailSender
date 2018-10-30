using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSenderLib;

namespace MailSender.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public WpfMailSenderViewModel WpfMailSender =>
            ServiceLocator.Current.GetInstance<WpfMailSenderViewModel>();

        public CustomToolBarControlViewModel CustomToolBar =>
            ServiceLocator.Current.GetInstance<CustomToolBarControlViewModel>();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<IDataAccessService, DataAccessServiceFormDB>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WpfMailSenderViewModel>();
            SimpleIoc.Default.Register<CustomToolBarControlViewModel>();
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}