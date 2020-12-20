using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ_6
{
    abstract class Weapon
    {
        public string Model { get; set; }
        public double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if(value > 0)
                {
                    radius = value;
                }
                else
                {
                    throw new Exception("Радиус поражения должен быть положительным.");
                }
            }
        }
        public string Type { get; set; }
    }
    //Холодное оружие
    class Melee : Weapon
    {
        public double bladeLength;
        public double BladeLength
        {
            get
            {
                return bladeLength;
            }
            set
            {
                if (value > 0)
                {
                    bladeLength = value;
                }
                else
                {
                    throw new Exception("Длина клинка должна быть положительной.");
                }
            }
        }
        public double bladeWidth;
        public double BladeWidth
        {
            get
            {
                return bladeWidth;
            }
            set
            {
                if (value > 0)
                {
                    bladeWidth = value;
                }
                else
                {
                    throw new Exception("Ширина клинка должна быть положительной.");
                }
            }
        }
    }
    class Knife : Melee
    {
        public Knife() { Type = "Холодное оружие"; }
        public Knife(string model, double radius, double bladeLength, double bladeWidth)
        {
            Model = model;
            Radius = radius;
            BladeLength = bladeLength;
            BladeWidth = bladeWidth;
            Type = "Холодное оружие";
        }
        public override string ToString()
        {
            return $"{Model}. Тип: {Type}. Радиус поражения: {Radius} м. Длина клинка: {BladeLength} мм. Ширина клинка: {BladeWidth} мм";
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || (obj.GetType() != GetType()))
            {
                return false;
            }
            else
            {
                Melee m = (Melee)obj;
                return (Model == m.Model) && (Radius == m.Radius) && (BladeLength == m.BladeLength) && (BladeWidth == m.BladeWidth);
            }
        }
    }
    //Огнестрельное оружие
    class Firearm : Weapon
    {
        public double bulletDiameter;
        public double BulletDiameter
        {
            get
            {
                return bulletDiameter;
            }
            set
            {
                if (value > 0)
                {
                    bulletDiameter = value;
                }
                else
                {
                    throw new Exception("Диаметр пули должен быть положительным.");
                }
            }
        }
        public double bulletLength;
        public double BulletLength
        {
            get
            {
                return bulletLength;
            }
            set
            {
                if (value > 0)
                {
                    bulletLength = value;
                }
                else
                {
                    throw new Exception("Длина пули должна быть положительной.");
                }
            }
        }
        public double firingRate;
        public double FiringRate
        {
            get
            {
                return firingRate;
            }
            set
            {
                if (value > 0)
                {
                    firingRate = value;
                }
                else
                {
                    throw new Exception("Скорострельность должна быть положительной.");
                }
            }
        }
        public double reloadRate;
        public double ReloadRate
        {
            get
            {
                return reloadRate;
            }
            set
            {
                if (value > 0)
                {
                    reloadRate = value;
                }
                else
                {
                    throw new Exception("Скорость перезарядки должна быть положительной.");
                }
            }
        }
    }
    class Rifle : Firearm
    {
        public Rifle() { Type = "Огнестрельное оружие"; }
        public Rifle(string model, double radius, double bulletDiameter, double bulletLength, double firingRate, double reloadRate)
        {
            Model = model;
            Radius = radius;
            BulletDiameter = bulletDiameter;
            BulletLength = bulletLength;
            FiringRate = firingRate;
            ReloadRate = reloadRate;
            Type = "Огнестрельное оружие";
        }

        public override string ToString()
        {
            return $"{Model}. Тип: {Type}. Радиус поражения: {Radius} м. Патрон: {BulletDiameter}x{BulletLength} мм. Скорострельность: {FiringRate} выс./мин.. Скорость перезарядки: {ReloadRate} сек..";
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            else
            {
                Rifle m = (Rifle)obj;
                return (Model == m.Model) && (Radius == m.Radius) && (BulletDiameter == m.BulletDiameter) && (BulletLength == m.BulletLength) && (FiringRate == m.FiringRate) && (ReloadRate == m.ReloadRate);
            }
        }
    }
    //Термоядерное оружие
    class Thermonuclear : Weapon
    {
        public double power;
        public double Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value > 0)
                {
                    power = value;
                }
                else
                {
                    throw new Exception("Мощность должна быть положительной.");
                }
            }
        }
    }
    class ICBM : Thermonuclear
    {
        public ICBM() { Type = "Термоядерное оружие"; }
        public ICBM(string model, double radius, double power)
        {
            Model = model;
            Radius = radius;
            Power = power;
            Type = "Термоядерное оружие";
        }
        public override string ToString()
        {
            return $"{Model}. Тип: {Type}. Радиус поражения: {Radius} м. Мощность взрыва: {Power} мегатонн.";
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || (obj.GetType() != GetType()))
            {
                return false;
            }
            else
            {
                Thermonuclear m = (Thermonuclear)obj;
                return (Model == m.Model) && (Radius == m.Radius) && (Power == m.Power);
            }
        }
    }

    public partial class MainWindow : Window
    {
        List<Weapon> weapons = new List<Weapon>
        {
            new Knife { Model = "Штык-нож 6X4", Radius = 1, BladeLength = 150, BladeWidth = 30},
            new Rifle { Model = "Автомат АК-74", Radius = 1000, BulletDiameter = 5.45, BulletLength = 39, FiringRate = 600, ReloadRate = 2.5},
            new ICBM { Model = "МБР SM-65 Atlas", Radius = 10200, Power = 4.45},
            new Knife { Model = "Штык-нож M9", Radius = 1, BladeLength = 180, BladeWidth = 32.7},
            new Rifle { Model = "Автомат M4", Radius = 500, BulletDiameter = 5.56, BulletLength = 45, FiringRate = 835, ReloadRate = 3.1},
            new ICBM { Model = "МБР Р-12", Radius = 6000, Power = 2.3},
            new Knife { Model = "Cтилет V42", Radius = 1, BladeLength = 18.42, BladeWidth = 26.2},
            new Rifle { Model = "Famas F1", Radius = 300, BulletDiameter = 5.56, BulletLength = 45, FiringRate = 950, ReloadRate = 3.3},
            new ICBM { Model = "МБР Р-7", Radius = 5500, Power = 3}
        };

        public void UpdateWeaponList()
        {
            ListTB.Text = "";
            DefaultOrderRB.IsChecked = true;
            int i = 1;
            foreach (var weapon in weapons)
            {
                ListTB.Text += $"{i}. " + weapon.ToString() + "\r\n";
                i++;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            UpdateWeaponList();
        }

        private void СreateWeaponBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KnifeRB.IsChecked == true)
                {
                    Knife knife = new Knife { Model = ModelTB.Text, Radius = double.Parse(RadiusTB.Text), BladeLength = double.Parse(LengthTB.Text), BladeWidth = double.Parse(WidthTB.Text)};
                    foreach (var weapon in weapons)
                    {
                        if (knife.Equals(weapon))
                        {
                            throw new Exception("Такой экземпляр оружия уже существует");
                        }
                    }
                    weapons.Add(knife);
                    UpdateWeaponList();
                }
                else if (RifleRB.IsChecked == true)
                {
                    Rifle rifle = new Rifle { Model = ModelTB.Text, Radius = double.Parse(RadiusTB.Text), BulletLength = double.Parse(LengthTB.Text), BulletDiameter = double.Parse(WidthTB.Text), ReloadRate = double.Parse(ReloadRateTB.Text), FiringRate = double.Parse(FiringRateTB.Text) };
                    foreach (var weapon in weapons)
                    {
                        if (rifle.Equals(weapon))
                        {
                            throw new Exception("Такой экземпляр оружия уже существует");
                        }
                    }
                    weapons.Add(rifle);
                    UpdateWeaponList();
                }
                else if (ICBMRB.IsChecked == true)
                {
                    ICBM iCBM= new ICBM { Model = ModelTB.Text, Radius = double.Parse(RadiusTB.Text), Power = double.Parse(PowerTB.Text)};
                    foreach (var weapon in weapons)
                    {
                        if (iCBM.Equals(weapon))
                        {
                            throw new Exception("Такой экземпляр оружия уже существует");
                        }
                    }
                    weapons.Add(iCBM);
                    UpdateWeaponList();
                }
                else
                {
                    throw new Exception("Не был выбран тип создаваемого оружия!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Тип(ы) заданных данных не совпадает с предписанным(и).", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки:\r\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void KnifeDataTransform(object sender, RoutedEventArgs e)
        {
            LengthTB.Visibility = Visibility.Visible;
            BladeLengthLb.Visibility = Visibility.Visible;
            BulletLengthLb.Visibility = Visibility.Hidden;

            WidthTB.Visibility = Visibility.Visible;
            BladeWidthLb.Visibility = Visibility.Visible;            
            BulletDiameterLb.Visibility = Visibility.Hidden;
            
            ReloadRateLb.Visibility = Visibility.Hidden;
            ReloadRateTB.Visibility = Visibility.Hidden;
            
            FiringRateLb.Visibility = Visibility.Hidden;
            FiringRateTB.Visibility = Visibility.Hidden;

            PowerLb.Visibility = Visibility.Hidden;
            PowerTB.Visibility = Visibility.Hidden;
        }

        private void RifleDataTransform(object sender, RoutedEventArgs e)
        {
            LengthTB.Visibility = Visibility.Visible;
            BladeLengthLb.Visibility = Visibility.Hidden;
            BulletLengthLb.Visibility = Visibility.Visible;

            WidthTB.Visibility = Visibility.Visible;
            BladeWidthLb.Visibility = Visibility.Hidden;
            BulletDiameterLb.Visibility = Visibility.Visible;

            ReloadRateLb.Visibility = Visibility.Visible;
            ReloadRateTB.Visibility = Visibility.Visible;

            FiringRateLb.Visibility = Visibility.Visible;
            FiringRateTB.Visibility = Visibility.Visible;

            PowerLb.Visibility = Visibility.Hidden;
            PowerTB.Visibility = Visibility.Hidden;
        }

        private void ICBMDataTransform(object sender, RoutedEventArgs e)
        {
            LengthTB.Visibility = Visibility.Hidden;
            BladeLengthLb.Visibility = Visibility.Hidden;
            BulletLengthLb.Visibility = Visibility.Hidden;

            WidthTB.Visibility = Visibility.Hidden;
            BladeWidthLb.Visibility = Visibility.Hidden;
            BulletDiameterLb.Visibility = Visibility.Hidden;

            ReloadRateLb.Visibility = Visibility.Hidden;
            ReloadRateTB.Visibility = Visibility.Hidden;

            FiringRateLb.Visibility = Visibility.Hidden;
            FiringRateTB.Visibility = Visibility.Hidden;

            PowerLb.Visibility = Visibility.Visible;
            PowerTB.Visibility = Visibility.Visible;
        }

        private void DeleteWeaponBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(DeleteIndexTB.Text);
                if (n <= 0)
                {
                    throw new Exception("Номер оружия не может быть отрицательным.");
                }
                else if (n > weapons.Count)
                {
                    throw new Exception("Оружия под данным номером не существует");
                }
                else
                {
                    weapons.RemoveAt(n-1);
                    UpdateWeaponList();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректно введён номер оружия.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки:\r\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DefaultOrderRB.IsChecked == true)
                {
                    UpdateWeaponList();
                }
                else if (DescendingRadiusOrderRB.IsChecked == true)
                {
                    ListTB.Text = "";
                    int i = 1;
                    var orderedWeapons = from weapon in weapons orderby weapon.Radius descending select weapon;
                    foreach (var o in orderedWeapons)
                    {
                        ListTB.Text += $"{i}. " + o.ToString() + "\r\n";
                        i++;
                    }
                }
                else if (AscendingRadiusOrderRB.IsChecked == true)
                {
                    ListTB.Text = "";
                    int i = 1;
                    var orderedWeapons = from weapon in weapons orderby weapon.Radius ascending select weapon;
                    foreach (var o in orderedWeapons)
                    {
                        ListTB.Text += $"{i}. " + o.ToString() + "\r\n";
                        i++;
                    }
                }
                else if (WeaponTypeOrderRB.IsChecked == true)
                {
                    ListTB.Text = "";
                    int k;
                    List<string> Types = new List<string> { "Холодное оружие", "Огнестрельное оружие", "Термоядерное оружие" };
                    for (int i = 0; i < Types.Count; i++)
                    {
                        k = 1;
                        ListTB.Text += Types[i] + ":\r\n";
                        var orderedWeapons = weapons.Where(t => t.Type == Types[i]);
                        foreach (var o in orderedWeapons)
                        {
                            ListTB.Text += $"{k}. " + o.ToString() + "\r\n";
                            k++;
                        }
                        ListTB.Text += "\r\n";
                    }
                }
                else
                {
                    throw new Exception("Не был выбран тип сортировки!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст ошибки:\r\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateListForDelete(object sender, TextChangedEventArgs e)
        {
            UpdateWeaponList();
        }
    }
}
