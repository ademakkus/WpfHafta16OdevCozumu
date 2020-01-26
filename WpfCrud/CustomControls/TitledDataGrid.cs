using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfCrud.Models;

namespace WpfCrud.CustomControls
{
    public class TitledDataGrid : DataGrid
    {
        bool isHeaderOk = false;
        protected override void OnLoadingRow(DataGridRowEventArgs e)
        {
            if (!isHeaderOk)
            {
                Type type = e.Row.Item.GetType();
                var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                for (int i = 0; i < properties.Length; i++)
                {
                    Attribute attribute = properties[i].GetCustomAttribute(typeof(DisplayAttribute));
                    if (attribute != null)
                    {
                        //this.Columns[i].Header = (attribute as DisplayAttribute).Name;
                        this.Columns[i].Header = ((DisplayAttribute)attribute).Name;
                    }

                    Attribute colorAttribute = properties[i].GetCustomAttribute(typeof(ColumnColorAttribute));
                    if (colorAttribute != null)
                    {
                        ColumnColorAttribute colorAtt = colorAttribute as ColumnColorAttribute;
                        Color columnColor = Color.FromArgb(255, colorAtt.Red, colorAtt.Green, colorAtt.Blue);

                        this.Columns[i].CellStyle = new Style(typeof(DataGridCell));
                        this.Columns[i].CellStyle.Setters.Add(
                            new Setter(DataGridCell.BackgroundProperty,
                                new SolidColorBrush(columnColor)
                        ));
                    }
                }
                isHeaderOk = true;
            }
            base.OnLoadingRow(e);
        }
    }
}
