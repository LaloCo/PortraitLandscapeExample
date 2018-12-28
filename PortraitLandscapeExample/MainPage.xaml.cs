using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PortraitLandscapeExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);

            PopulateCategories();

            SizeChanged += MainPage_SizeChanged;
        }

        void MainPage_SizeChanged(object sender, EventArgs e)
        {
            string visualState = Width > Height ? "Landscape" : "Portrait";

            VisualStateManager.GoToState(titleLabel, visualState);
        }

        private void PopulateCategories()
        {
            Random rnd = new Random();
            List<Category> categories = new List<Category>();
            string[] importanceValues = { "Low priority", "Important", "High priority" };
            for (int i = 0; i < 30; i++)
            {
                int importance = rnd.Next(0, 3);
                Category newCategory = new Category
                {
                    Importance = importanceValues[importance],
                    Name = $"Category {i}"
                };
                categories.Add(newCategory);
            }

            mainListView.ItemsSource = categories;
        }
    }

    public class Category
    {
        public string Name { get; set; }
        public string Importance { get; set; }
    }
}
