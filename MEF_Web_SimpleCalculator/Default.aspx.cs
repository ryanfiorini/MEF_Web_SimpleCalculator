using MEFF_Web_Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MEF_Web_SimpleCalculator
{
    public partial class Default : System.Web.UI.Page
    {
        private CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator calculator;

        public Default()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new DirectoryCatalog(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin")));

            // user relative path in production environment
            catalog.Catalogs.Add(new DirectoryCatalog(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Extensions")));

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            answer.InnerHtml += "3+5=" + this.calculator.Calculate("3+5") + "<br />";
            answer.InnerHtml += "4+5=" + this.calculator.Calculate("4+5") + "<br />";
            answer.InnerHtml += "5-4=" + this.calculator.Calculate("5-4") + "<br />";
            answer.InnerHtml += "100%22=" + this.calculator.Calculate("100%22") + "<br />";
        }
    }
}