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
using WpfCrud.BLL;
using WpfCrud.Models;

namespace WpfCrud
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gridCategories.ItemsSource = CategoryBLL.GetAll();
        }
        bool newCategory = false;
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            newCategory = true;
            //txtCategoryName.Text = "";
            //txtDescription.Text = "";
            txtCategoryName.Clear();
            txtDescription.Clear();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(newCategory)
            {
                //Ekleme yapılıyor
                CategoryBLL.AddCategory(new Category
                {
                    Name=txtCategoryName.Text,
                    Description=txtDescription.Text
                });
                newCategory = false;
                gridCategories.ItemsSource = CategoryBLL.GetAll();
                MessageBox.Show("Kategori başarıyla eklendi.");
            }
            else
            {
                //Güncelleme yapılıyor
                //kategorinin eski hali
                Category oldCategory = gridCategories.SelectedItem as Category;
                //kategori modelini güncelle
                oldCategory.Description = txtDescription.Text;
                oldCategory.Name = txtCategoryName.Text;
                CategoryBLL.UpdateCategory(oldCategory);
                gridCategories.ItemsSource = CategoryBLL.GetAll();
                MessageBox.Show("Kategori başarıyla güncellendi.");

            }
        }

        private void deleteCategory_Click(object sender, RoutedEventArgs e)
        {
            Category oldCategory = gridCategories.SelectedItem as Category;
            CategoryBLL.DeleteCategory(oldCategory);
            gridCategories.ItemsSource = CategoryBLL.GetAll();
            MessageBox.Show("Kategori başarıyla silindi.");
        }
    }

    public class SelectedIndexToBool:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int selectedIndex = System.Convert.ToInt32(value);
            return selectedIndex >= 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
