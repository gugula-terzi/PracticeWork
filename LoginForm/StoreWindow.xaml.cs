using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoginForm
{
    /// <summary>
    /// Interaction logic for StoreWindow.xaml
    /// </summary>
    public partial class StoreWindow : Window
    {
        public DataTable table = new DataTable();
        static string connectionString = ConfigurationManager.ConnectionStrings["HerokuDB"].ConnectionString;
        
        public class GraphicsCard
        {
            public string Image { get; set; }
            public string ProductName { get; set; }
            public string VRAMType { get; set; }
            public string VRAMCapacity { get; set; }
            public string BusWidth { get; set; }
            public string Connectors { get; set; }
            public string Price { get; set; }
        }

        public class Processor
        {
            public string Image { get; set; }
            public string ProductName { get; set; }
            public string CPUSocket { get; set; }
            public string CPUCores { get; set; }
            public string Threads { get; set; }
            public string CPUSpeed { get; set; }
            public string IntegratedGraphics { get; set; }
            public string Price { get; set; }
        }

        public class RAM
        {
            public string Image { get; set; }
            public string ProductName { get; set; }
            public string DDRType { get; set; }
            public string Frequency { get; set; }
            public string Capacity { get; set; }
            public string NumOfModules { get; set; }
            public string Type { get; set; }
            public string Price { get; set; }
        }

        public class HDD_Drive
        {
            public string Image { get; set; }
            public string ProductName { get; set; }
            public string InterfaceType { get; set; }
            public string Capacity { get; set; }
            public string FormFactor { get; set; }
            public string SpindleSpeed { get; set; }
            public string CacheCapacity { get; set; }
            public string Price { get; set; }
        }

        public class SSD_Drive
        {
            public string Image { get; set; }
            public string ProductName { get; set; }
            public string InterfaceType { get; set; }
            public string Capacity { get; set; }
            public string FormFactor { get; set; }
            public string NVMe { get; set; }            
            public string ReadingSpeed { get; set; }
            public string WritingSpeed { get; set; }
            public string Price { get; set; }
        }

        public class PowerSupply
        {
            public string Image { get; set; }
            public string ProductName { get; set; }
            public string Power { get; set; }
            public string CableManagement { get; set; }
            public string SataConnectors { get; set; }
            public string FormFactor { get; set; }            
            public string PCI_8pin { get; set; }
            public string PCI_6pin { get; set; }
            public string Molex { get; set; }
            public string Price { get; set; }
        }

        public class TowerCooling
        {
            public string Image { get; set; }
            public string ProductName { get; set; }
            public string SpeedRange { get; set; }
            public string Height { get; set; }
            public string Weight { get; set; }
            public string FanSize { get; set; }            
            public string CoolerType { get; set; }
            public string CPU_Socket { get; set; }
            public string MaxVolume { get; set; }
            public string Price { get; set; }
        }

        public class WaterCooling
        {
            public string Image { get; set; }
            public string ProductName { get; set; }
            public string FanSize { get; set; }        
            public string CPU_Socket { get; set; }
            public string CoolerType { get; set; }
            public string InstalledFans  { get; set; }
            public string MaxVolume { get; set; }
            public string Price { get; set; }
        }

        public StoreWindow()
        {
            InitializeComponent();
        }


        private void InfoGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        public ObservableCollection<GraphicsCard> GraphicsCards { get; set; }
        private void GraphicsCardTableBtn_Click(object sender, RoutedEventArgs e)
        {

            ProductsList.ItemTemplate = (DataTemplate)ProductsList.FindResource("GraphicsCardsItemTemplate");
            string sql_query = "SELECT product_name, vram_type, vram_capacity, bus_width, connectors, price FROM graphics_card;";

            GraphicsCards = new ObservableCollection<GraphicsCard>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GraphicsCards.Add(
                                new GraphicsCard
                                {
                                    Image = "Images/background/graphics-card.png",
                                    ProductName = reader.GetString(0),                                    
                                    VRAMType = reader.GetString(1),
                                    VRAMCapacity = reader.GetString(2),
                                    BusWidth = reader.GetString(3),
                                    Connectors = reader.GetString(4),
                                    Price = reader.GetValue(5).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            ProductsList.ItemsSource = GraphicsCards;
        }


        public ObservableCollection<Processor> Processors { get; set; }
        private void ProcessorTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsList.ItemTemplate = (DataTemplate)ProductsList.FindResource("ProcessorsItemTemplate");
            string sql_query = "SELECT product_name, cpu_socket, cpu_cores, threads, cpu_speed, integrated_graphics, price FROM processor;";

            Processors = new ObservableCollection<Processor>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Processors.Add(
                                new Processor
                                {
                                    Image = "Images/background/chip.png",
                                    ProductName = reader.GetString(0),
                                    CPUSocket = reader.GetString(1),
                                    CPUCores = reader.GetString(2),
                                    Threads = reader.GetString(3),
                                    CPUSpeed = reader.GetString(4),
                                    IntegratedGraphics = reader.GetString(5),
                                    Price = reader.GetValue(6).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            ProductsList.ItemsSource = Processors;
        }


        public ObservableCollection<RAM> RAMs { get; set; }
        private void RAMTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsList.ItemTemplate = (DataTemplate)ProductsList.FindResource("RAMItemTemplate");
            string sql_query = "SELECT product_name, ddr_type, frequency, capacity, num_of_modules, type, price FROM ram;";
            RAMs = new ObservableCollection<RAM>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            RAMs.Add(
                                new RAM
                                {
                                    Image = "Images/background/ram.png",
                                    ProductName = reader.GetString(0),
                                    DDRType = reader.GetString(1),
                                    Frequency = reader.GetString(2),
                                    Capacity = reader.GetString(3),
                                    NumOfModules = reader.GetString(4),
                                    Type = reader.GetString(5),
                                    Price = reader.GetValue(6).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            ProductsList.ItemsSource = RAMs;
        }

        private void NavPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        public void Save()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM " + table.TableName, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);


                    adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                    adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                    adapter.Update(table);
                    table.AcceptChanges();
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("Duplicate entry"))
                    {
                        MessageWindow message = new MessageWindow("This id is already exists", "error");
                        message.Show();
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public object GetScalar(string scalar_query)
        {
            object scalar_value = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(scalar_query, connection);
                    scalar_value = command.ExecuteScalar();
                    return scalar_value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
            return scalar_value;
        }

        MessageWindow messageWindow;

        private void AVGBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.ItemsSource == GraphicsCards)
            {
                string sql_query = "SELECT AVG(price) FROM graphics_card";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Average price: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == RAMs)
            {
                string sql_query = "SELECT AVG(price) FROM ram";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Average price: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == Processors)
            {
                string sql_query = "SELECT AVG(price) FROM processor";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Average price: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
        }

        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.ItemsSource == GraphicsCards)
            {
                string sql_query = "SELECT MAX(price) FROM graphics_card";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Maximum price: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == RAMs)
            {
                string sql_query = "SELECT MAX(price) FROM ram";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Maximum price: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == Processors)
            {
                string sql_query = "SELECT MAX(price) FROM processor";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Maximum price: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
        }

        private void TotalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.ItemsSource == GraphicsCards)
            {
                string sql_query = "SELECT COUNT(price) FROM graphics_card";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Total count of products: " + value.ToString(), "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == RAMs)
            {
                string sql_query = "SELECT COUNT(price) FROM ram";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Total count of products: " + value.ToString(), "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == Processors)
            {
                string sql_query = "SELECT COUNT(price) FROM processor";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Total count of products: " + value.ToString(), "information");
                messageWindow.ShowDialog();
            }
        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.ItemsSource == GraphicsCards)
            {
                string sql_query = "SELECT MIN(price) FROM graphics_card";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Minimum price: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == RAMs)
            {
                string sql_query = "SELECT MIN(price) FROM ram";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Minimum price: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == Processors)
            {
                string sql_query = "SELECT MIN(price) FROM processor";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Minimum price: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
        }

        private void SUMBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsList.ItemsSource == GraphicsCards)
            {
                string sql_query = "SELECT SUM(price) FROM graphics_card";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Total sum of products: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == RAMs)
            {
                string sql_query = "SELECT SUM(price) FROM ram";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Total sum of products: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
            if (ProductsList.ItemsSource == Processors)
            {
                string sql_query = "SELECT SUM(price) FROM processor";
                var value = Math.Round(double.Parse(GetScalar(sql_query).ToString()), 2, MidpointRounding.ToEven);
                messageWindow = new MessageWindow("Total sum of products: " + value.ToString() + "$", "information");
                messageWindow.ShowDialog();
            }
        }

        public ObservableCollection<SSD_Drive> SSD_Drives { get; set; }
        private void SSDTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsList.ItemTemplate = (DataTemplate)ProductsList.FindResource("SSDItemTemplate");
            string sql_query = "SELECT product_name, interface_type, capacity, form_factor, nvme, reading_speed, writing_speed, price FROM ssd_drives;";
            SSD_Drives = new ObservableCollection<SSD_Drive>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(sql_query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SSD_Drives.Add(
                                new SSD_Drive
                                {
                                    Image = "Images/background/ssd-storage.png",
                                    ProductName = reader.GetString(0),
                                    InterfaceType = reader.GetString(1),
                                    Capacity = reader.GetString(2),
                                    FormFactor = reader.GetString(3),
                                    NVMe = reader.GetBoolean(4)==true? "Yes" : "No",
                                    ReadingSpeed = reader.GetString(5),
                                    WritingSpeed = reader.GetString(6),
                                    Price = reader.GetValue(7).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            ProductsList.ItemsSource = SSD_Drives;
        }
    }
}
