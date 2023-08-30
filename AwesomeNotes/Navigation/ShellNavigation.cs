using AwesomeNotes.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeNotes.Navigation 
{
    public static class ShellNavigation
    {
        public static Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
        public static async Task GoToDetailAsync(string route)
        {
            var location = Shell.Current.CurrentState.Location.ToString();
            await Shell.Current.GoToAsync($"{location}/{route}",true);
        }
        //public static async Task GoToDetailParamAsync(string route, string param)
        //{
        //    var location = Shell.Current.CurrentState.Location.ToString();
        //    //var navigationParameter = new Dictionary<string, object>
        //    //{
        //    //    { "param", param }
        //    //};
        //    await Shell.Current.GoToAsync($"{location}/{route}?param={param}");
        //}
        public static async Task GoToPageAsync(string route)
        {
            await Shell.Current.GoToAsync($"//{route}",true);
        }
        public static async Task Pop()
        {
            await Shell.Current.GoToAsync("..");
        }
        private static void GetRoutes()
        {

            Routes.Add("EditNotePage", typeof(EditNotePage));
            Routes.Add("AddNotePage", typeof(AddNotePage));
            //Routes.Add("smallview", typeof(SmallMultiplicationTablesPage));
            //Routes.Add("easytaskview", typeof(EasyTaskPage));
            //Routes.Add("advandcedtaskview", typeof(AdvandcedTaskPage));
        }
        public static void RegisterRoutes()
        {
            GetRoutes();

            foreach (var item in Routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
        public static void UnRegisterRoutes()
        {
            foreach (var item in Routes)
            {
                Routing.UnRegisterRoute(item.Key);
            }
            Routes.Clear();
        }
    }
}
