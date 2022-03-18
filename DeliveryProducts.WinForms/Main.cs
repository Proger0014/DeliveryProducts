using DeliveryProducts.BusinessLogic;
using DeliveryProducts.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryProducts.WinForms
{
    public partial class Main : Form
    {
        private readonly ProductsService _productsService;
        private readonly DeliveriesService _deliveriesService;
        private readonly CitiesService _citiesService;

        private readonly SeedDatabase _seedDatabase;

        private EasyProducts _easyProducts;
        private HeavyProducts _heavyProducts;
        private ExtraProducts _extraProducts;

        private readonly List<Core.Models.Product> _products;
        private readonly List<Core.Models.City> _cities;
        private readonly List<Core.Models.Delivery> _deliveries;

        private bool IsHaveWeight { get; set; } = true;

        private int Count { get; set; }

        public Main(ProductsService productsService, DeliveriesService deliveriesService, CitiesService citiesService, SeedDatabase seedDatabase)
        {
            _productsService = productsService;
            _deliveriesService = deliveriesService;
            _citiesService = citiesService;

            _seedDatabase = seedDatabase;
            _seedDatabase.InitData();

            _products = _productsService.GetAll().ToList();
            _cities = _citiesService.GetAll().ToList();
            _deliveries = deliveriesService.GetAll().ToList();

            _easyProducts = new EasyProducts();
            _heavyProducts = new HeavyProducts();
            _extraProducts = new ExtraProducts();

            Count = 1;

            InitializeComponent();

            DeleteWeight();
        }

        delegate decimal Price(Core.Models.Product product, Core.Models.Delivery delivery);

        private decimal? GetAmount(Core.Models.Product product, Core.Models.Delivery delivery, Core.Models.City city)
        {
            Price getPrice = null;

            if (delivery.TypeCity != city.Type)
            {
                return null;
            }

            switch (product.Category.Name)
            {
                case "easy":
                    getPrice = _easyProducts.GetPrice;
                    break;

                case "heavy":
                    getPrice = _heavyProducts.GetPrice;
                    break;

                case "extra":
                    getPrice = _extraProducts.GetPrice;
                    break;
            }

            return getPrice(product, delivery);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SetDateInCombobox();
        }

        private void SetDateInCombobox()
        {
            var products = _productsService.GetAll().Select(prod => prod.Name).ToList();
            var categories = _productsService.GetAll().Select(prod => prod.Category.Name).ToList();
            var cities = _citiesService.GetAll().Select(prod => prod.Name).ToList();

            AddCategories(categories);
            AddProducts(products);
            AddCities(cities);
        }

        private void AddCategories(List<string> categories)
        {
            var formattedCategories = new List<string>();

            foreach (var category in categories)
            {
                formattedCategories.Add(StringFormater.FormatCategoryNameRus(category));
            }

            comboBox1.DataSource = formattedCategories;
            comboBox1.SelectedIndex = -1;
        }

        private void AddProducts(List<string> products)
        {
            comboBox2.DataSource = products;
            comboBox2.SelectedIndex = -1;
        }

        private void AddCities(List<string> cities)
        {
            var formatedCities = new List<string>();

            foreach (var city in cities)
            {
                formatedCities.Add(StringFormater.FormatCityNameRus(city));
            }


            comboBox3.DataSource = formatedCities;
            comboBox3.SelectedIndex = -1;
        }

        

        private void ChangeProductsList(string categoryName)
        {
            comboBox2.DataSource = _products.Where(c => c.Category.Name == categoryName).Select(c => c.Name).ToList();
        }

        private void AddWeight()
        {
            if (IsHaveWeight)
            {
                return;
            }

            IsHaveWeight = true;

            label6.Visible = true;
            textBox1.Visible = true;

            ChangeLocation(Locations.Plus);
        }

        private void ChangeLocation(Locations location)
        {
            int ySizeCoef = 0;

            switch (location)
            {
                case Locations.Minus:
                    ySizeCoef = -40;
                    break;

                case Locations.Plus:
                    ySizeCoef = 40;
                    break;
            }

            comboBox2.Location = new Point(comboBox2.Location.X, comboBox2.Location.Y + ySizeCoef);
            label2.Location = new Point(label2.Location.X, label2.Location.Y + ySizeCoef);

            label3.Location = new Point(label3.Location.X, label3.Location.Y + ySizeCoef);
            comboBox3.Location = new Point(comboBox3.Location.X, comboBox3.Location.Y + ySizeCoef);
        }

        private void DeleteWeight()
        {
            if (!IsHaveWeight)
            {
                return;
            }

            IsHaveWeight = false;

            label6.Visible = false;
            textBox1.Visible = false;

            ChangeLocation(Locations.Minus);
        }

        private void ChangeProductsListFormCategory(string category)
        {
            switch (category)
            {
                case "heavy":
                    ChangeProductsList("heavy");
                    AddWeight();
                    break;

                case "extra":
                    ChangeProductsList("extra");
                    DeleteWeight();
                    break;

                case "easy":
                    ChangeProductsList("easy");
                    DeleteWeight();
                    break;
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label5.Text = String.Empty;
            comboBox3.SelectedIndex = -1;

            ChangeProductsListFormCategory(StringFormater.FormatCategoryNameEng(comboBox1.SelectedItem.ToString()));
            comboBox2.SelectedIndex = -1;

            SetAmount();
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label5.Text = String.Empty;

            if (comboBox3.SelectedIndex <= -1)
            {
                return;
            }

            SetAmount();
        }

        private void SetAmount()
        {
            bool isHeavy = int.TryParse(textBox1.Text, out int weight);
            
            if (comboBox1.SelectedItem != null && StringFormater.FormatCategoryNameEng(comboBox1.SelectedItem.ToString()) == "heavy")
            {
                if (!isHeavy)
                {
                    return;
                }
            }
            

            if (comboBox1.SelectedIndex <= -1 || comboBox2.SelectedIndex <= -1 || comboBox3.SelectedIndex <= -1)
            {
                return;
            }

            var product = _products.Where(p => p.Name == comboBox2.SelectedItem.ToString()).Single();
            var city = _cities.Where(c => c.Name == StringFormater.FormatCityNameEng(comboBox3.SelectedItem.ToString())).Single();
            var delivery = _deliveries.Where(d => d.TypeCity == city.Type).Single();

            if (isHeavy)
            {
                product.Weight = weight;
            }


            label5.Text = GetAmount(product, delivery, city).ToString();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            label5.Text = String.Empty;

            if (comboBox2.SelectedIndex <= -1)
            {
                return;
            }

            if (comboBox1.SelectedIndex <= -1)
            {
                ChangeDeliveryLocation();
            }

            SetAmount();
        }

        private void ChangeDeliveryLocation()
        {
            var checkedProduct = comboBox2.SelectedItem.ToString();
            var product = _products.Where(p => p.Name == checkedProduct).Single();

            SelectCategory(product.Category.Name);
        }

        private void SelectCategory(string categoryName)
        {
            switch (categoryName)
            {
                case "heavy":
                    comboBox1.SelectedIndex = 1;
                    break;

                case "easy":
                    comboBox1.SelectedIndex = 2;
                    break;

                case "extra":
                    comboBox1.SelectedIndex = 0;
                    break;
            }

            ChangeProductsListFormCategory(categoryName);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SetAmount();
        }
    }
}
