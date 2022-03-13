using DeliveryProducts.BusinessLogic;
using DeliveryProducts.DAL;
using System;
using System.Collections.Generic;
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

        private int Count { get; set; }

        public Main(ProductsService productsService, DeliveriesService deliveriesService, CitiesService citiesService, SeedDatabase seedDatabase)
        {
            _productsService = productsService;
            _deliveriesService = deliveriesService;
            _citiesService = citiesService;

            _seedDatabase = seedDatabase;

            _easyProducts = new EasyProducts();
            _heavyProducts = new HeavyProducts();
            _extraProducts = new ExtraProducts();

            Count = 1;

            InitializeComponent();
        }

        delegate decimal Price(Core.Models.Product product, Core.Models.Delivery delivery);

        private Models.Product GetFinalProducts(string category, Core.Models.Product product, Core.Models.Delivery delivery, Core.Models.City city)
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

            return new Models.Product(
                Count++, product.Name, product.Category.Name,
                city.Name, city.Type, product.Price, delivery.Price, getPrice(product, delivery)
                );
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _seedDatabase.InitData();
            var products = GetNewProducts();
            AddGrid(products);
        }

        private List<Models.Product> GetNewProducts()
        {
            var products = _productsService.GetAll();
            var deliveries = _deliveriesService.GetAll();
            var cities = _citiesService.GetAll();

            var result = new List<WinForms.Models.Product>();

            foreach (var product in products)
            {
                foreach (var deliver in deliveries)
                {
                    foreach (var city in cities)
                    {
                        var newProduct = GetFinalProducts(product.Category.Name, product, deliver, city);

                        if (newProduct is null)
                        {
                            continue;
                        }

                        result.Add(newProduct);
                    }
                }
            }

            return result;
        }
        private void AddGrid(List<Models.Product> products)
        {
            foreach (var product in products)
            {
                StringFormater.FormatProductNames(product);
            }

            dataGridView1.DataSource = products;

            dataGridView1.Columns[0].HeaderText = "№";
            dataGridView1.Columns[1].HeaderText = "Товар";
            dataGridView1.Columns[2].HeaderText = "Категория товара";
            dataGridView1.Columns[3].HeaderText = "Пункт назначения";
            dataGridView1.Columns[4].HeaderText = "Тип пункта назначения";
            dataGridView1.Columns[5].HeaderText = "Цена товара";
            dataGridView1.Columns[6].HeaderText = "Цена доставки";
            dataGridView1.Columns[7].HeaderText = "Итого";
            dataGridView1.Columns.Remove(dataGridView1.Columns[8].Name);
        }
    }
}
