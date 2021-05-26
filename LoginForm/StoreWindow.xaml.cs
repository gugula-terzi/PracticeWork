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
            string sql_query = "SELECT image, product_name, vram_type, vram_capacity, bus_width, connectors, price FROM graphics_card;";

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
                                    Image = reader.IsDBNull(reader.GetOrdinal("image")) ? "Images/background/graphics-card.png" : @reader.GetString(0),
                                    ProductName = reader.GetString(1),                                    
                                    VRAMType = reader.GetString(2),
                                    VRAMCapacity = reader.GetString(3),
                                    BusWidth = reader.GetString(4),
                                    Connectors = reader.GetString(5),
                                    Price = reader.GetValue(6).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageWindow message = new MessageWindow(ex.Message, "error");
                    message.Show();
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
            string sql_query = "SELECT image, product_name, cpu_socket, cpu_cores, threads, cpu_speed, integrated_graphics, price FROM processor;";

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
                                    Image = reader.IsDBNull(reader.GetOrdinal("image")) ? "Images/background/chip.png" : @reader.GetString(0),
                                    ProductName = reader.GetString(1),
                                    CPUSocket = reader.GetString(2),
                                    CPUCores = reader.GetString(3),
                                    Threads = reader.GetString(4),
                                    CPUSpeed = reader.GetString(5),
                                    IntegratedGraphics = reader.GetString(6),
                                    Price = reader.GetValue(7).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageWindow message = new MessageWindow(ex.Message, "error");
                    message.Show();
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
            string sql_query = "SELECT image, product_name, ddr_type, frequency, capacity, num_of_modules, type, price FROM ram;";
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
                                    Image = reader.IsDBNull(reader.GetOrdinal("image"))? "Images/background/ram.png" : @reader.GetString(0),
                                    ProductName = reader.GetString(1),
                                    DDRType = reader.GetString(2),
                                    Frequency = reader.GetString(3),
                                    Capacity = reader.GetString(4),
                                    NumOfModules = reader.GetString(5),
                                    Type = reader.GetString(6),
                                    Price = reader.GetValue(7).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageWindow message = new MessageWindow(ex.Message, "error");
                    message.Show();
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
                        MessageWindow message = new MessageWindow(ex.Message, "error");
                        message.Show();
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
                    MessageWindow message = new MessageWindow(ex.Message, "error");
                    message.Show();
                }
                finally
                {
                    connection.Close();
                }
            }
            return scalar_value;
        }

        MessageWindow messageWindow;


        public ObservableCollection<SSD_Drive> SSD_Drives { get; set; }
        private void SSDTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsList.ItemTemplate = (DataTemplate)ProductsList.FindResource("SSDItemTemplate");
            string sql_query = "SELECT image, product_name, interface_type, capacity, form_factor, nvme, reading_speed, writing_speed, price FROM ssd_drives;";
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
                                    Image = reader.IsDBNull(reader.GetOrdinal("image")) ? "Images/background/ssd-storage.png" : @reader.GetString(0),
                                    ProductName = reader.GetString(1),
                                    InterfaceType = reader.GetString(2),
                                    Capacity = reader.GetString(3),
                                    FormFactor = reader.GetString(4),
                                    NVMe = reader.GetBoolean(5)==true? "Yes" : "No",
                                    ReadingSpeed = reader.GetString(6),
                                    WritingSpeed = reader.GetString(7),
                                    Price = reader.GetValue(8).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageWindow message = new MessageWindow(ex.Message, "error");
                    message.Show();
                }
                finally
                {
                    connection.Close();
                }
            }

            ProductsList.ItemsSource = SSD_Drives;
        }


        public ObservableCollection<HDD_Drive> HDD_Drives { get; set; }
        private void HDDTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsList.ItemTemplate = (DataTemplate)ProductsList.FindResource("HDDItemTemplate");
            string sql_query = "SELECT image, product_name, interface_type, capacity, form_factor, spindle_speed, cache_capacity, price FROM hdd_drives;";
            HDD_Drives = new ObservableCollection<HDD_Drive>();

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
                            HDD_Drives.Add(
                                new HDD_Drive
                                {
                                    Image = reader.IsDBNull(reader.GetOrdinal("image")) ? "Images/background/hdd.png" : @reader.GetString(0),
                                    ProductName = reader.GetString(1),
                                    InterfaceType = reader.GetString(2),
                                    Capacity = reader.GetString(3),
                                    FormFactor = reader.GetString(4),
                                    SpindleSpeed = reader.GetString(5),
                                    CacheCapacity = reader.GetString(6),
                                    Price = reader.GetValue(7).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageWindow message = new MessageWindow(ex.Message, "error");
                    message.Show();
                }
                finally
                {
                    connection.Close();
                }
            }

            ProductsList.ItemsSource = HDD_Drives;
        }

        public ObservableCollection<WaterCooling> WaterCoolings { get; set; }
        private void WaterCoolingTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsList.ItemTemplate = (DataTemplate)ProductsList.FindResource("WaterCoolingItemTemplate");
            string sql_query = "SELECT image, product_name, fan_size, cpu_socket, cooler_type, installed_fans, max_volume, price FROM water_cooling;";
            WaterCoolings = new ObservableCollection<WaterCooling>();

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
                            WaterCoolings.Add(
                                new WaterCooling
                                {
                                    Image = reader.IsDBNull(reader.GetOrdinal("image")) ? "Images/background/fan_water.png" : @reader.GetString(0),
                                    ProductName = reader.GetString(1),
                                    FanSize = reader.GetString(2),
                                    CPU_Socket = reader.GetString(3),
                                    CoolerType = reader.GetString(4),
                                    InstalledFans = reader.GetString(5),
                                    MaxVolume = reader.GetString(6),
                                    Price = reader.GetValue(7).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageWindow message = new MessageWindow(ex.Message, "error");
                    message.Show();
                }
                finally
                {
                    connection.Close();
                }
            }

            ProductsList.ItemsSource = WaterCoolings;
        }

        public ObservableCollection<TowerCooling> TowerCoolings { get; set; }
        private void TowerCoolingTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsList.ItemTemplate = (DataTemplate)ProductsList.FindResource("TowerCoolingItemTemplate");
            string sql_query = "SELECT image, product_name, speed_range, height, weight, fan_size, cooler_type, cpu_socket, max_volume, price FROM tower_cooling;";
            TowerCoolings = new ObservableCollection<TowerCooling>();

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
                            TowerCoolings.Add(
                                new TowerCooling
                                {
                                    Image = reader.IsDBNull(reader.GetOrdinal("image")) ? "Images/background/fan.png" : @reader.GetString(0),
                                    ProductName = reader.GetString(1),
                                    SpeedRange = reader.GetString(2),
                                    Height = reader.GetString(3),
                                    Weight = reader.GetString(4),
                                    FanSize = reader.GetString(5),
                                    CoolerType = reader.GetString(6),
                                    CPU_Socket = reader.GetString(7),
                                    MaxVolume = reader.GetString(8),
                                    Price = reader.GetValue(9).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageWindow message = new MessageWindow(ex.Message, "error");
                    message.Show();
                }
                finally
                {
                    connection.Close();
                }
            }

            ProductsList.ItemsSource = TowerCoolings;
        }

        public ObservableCollection<PowerSupply> PowerSupplies { get; set; }
        private void PowerSupplyTableBtn_Click(object sender, RoutedEventArgs e)
        {
            ProductsList.ItemTemplate = (DataTemplate)ProductsList.FindResource("PowerSupplyItemTemplate");
            string sql_query = "SELECT image, product_name, power, cable_management, sata_connectors, form_factor, pcie_8pin_connectors, pcie_6pin_connectors, molex_connectors, price FROM power_supply;";
            PowerSupplies = new ObservableCollection<PowerSupply>();

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
                            PowerSupplies.Add(
                                new PowerSupply
                                {
                                    Image = reader.IsDBNull(reader.GetOrdinal("image")) ? "Images/background/fan.png" : @reader.GetString(0),
                                    ProductName = reader.GetString(1),
                                    Power = reader.GetString(2),
                                    CableManagement = reader.GetBoolean(3) == true ? "Yes" : "No",
                                    SataConnectors = reader.GetString(4),
                                    FormFactor = reader.GetString(5),
                                    PCI_8pin = reader.GetString(6),
                                    PCI_6pin = reader.GetString(7),
                                    Molex = reader.GetString(8),
                                    Price = reader.GetValue(9).ToString()
                                }
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageWindow message = new MessageWindow(ex.Message, "error");
                    message.Show();
                }
                finally
                {
                    connection.Close();
                }
            }

            ProductsList.ItemsSource = PowerSupplies;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
