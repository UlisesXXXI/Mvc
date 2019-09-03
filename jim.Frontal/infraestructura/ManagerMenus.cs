using jim.Frontal.Controllers;
using jim.Frontal.infraestructura.Comun.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace jim.Frontal.infraestructura
{
    public class ManagerMenus
    {
        public static List<Controlador> GenerarListaControladores()
        {
           
            var projectName = Assembly.GetExecutingAssembly().GetName().Name;
            var controlleractionlist = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => typeof(Controller).IsAssignableFrom(type))
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)/*.Where(c=>c.CustomAttributes.All(x=>x.AttributeType.Name!="HttpPostAttribute")*/)
            .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
            .Select(x => new Controlador()
            {
                Area = x.DeclaringType.Namespace.ToString().Replace(projectName + ".", "").Replace("Areas.", "").Replace(".Controllers", "").Replace("Controllers", ""),
                Control = x.DeclaringType.Name.Replace("Controler",""),
                Accion = x.Name
                
                
            }).Distinct()
            .OrderBy(x => (x.Area,x.Control)).ThenBy(x => x.Accion).ToList();

            


            return controlleractionlist;
        }
    }
}