using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet_5780_03_6789_0947
{

    public partial class MainWindow : Window
    {
        List<Host> hostsList = new List<Host>()
            {
                new Host()
                {
                    HostName = "david citadel",
                    Units = new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {

                             UnitName = "suite Royal",
                             Rooms=3,
                             IsSwimmimgPool=true,
                             AllOrders=new List<DateTime>(),
                             Uris=new List<string>{ "https://images.app.goo.gl/4uWJ3RaYZPr2bErN7",
                                              "https://images.app.goo.gl/Sq8yB2ZVT8wFrxGo8",
                                                "https://images.app.goo.gl/StEVA3NYZzsUMt2Z6"}
                        },
                        new HostingUnit()
                        {
                             UnitName = "chambre classic",
                             Rooms=2,
                             IsSwimmimgPool=false,
                             AllOrders=new List<DateTime>(),
                             Uris=new List<string>{ "https://images.app.goo.gl/4uWJ3RaYZPr2bErN7",
                                              "https://images.app.goo.gl/Sq8yB2ZVT8wFrxGo8",
                                                "https://images.app.goo.gl/StEVA3NYZzsUMt2Z6"}
                        },
                        new HostingUnit()
                        {
                            UnitName = "penthouse",
                            Rooms=4,
                            IsSwimmimgPool=true,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>{ "https://images.app.goo.gl/4uWJ3RaYZPr2bErN7",
                                              "https://images.app.goo.gl/Sq8yB2ZVT8wFrxGo8",
                                                "https://images.app.goo.gl/StEVA3NYZzsUMt2Z6"}
                        }
                    }
                }
            };
        private Host currentHost;
        public MainWindow()
        {
            InitializeComponent();
            cbHostList.ItemsSource = hostsList;
            cbHostList.DisplayMemberPath = "HostName";
            cbHostList.SelectedIndex = 0;
            InitializeHost(0);
            /////////////////////////////////////////////////
        }
        private void cbHostList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InitializeHost(cbHostList.SelectedIndex);
        }
        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            currentHost = hostsList[index];
            UpGrid.DataContext = currentHost;

            for (int i = 0; i < currentHost.Units.Count; i++)
            {
                HostingUnitUserControl a = new HostingUnitUserControl(currentHost.Units[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }

    }
}
